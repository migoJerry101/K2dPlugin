using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using K2dPlugin.Features.GenerateReport.Dto;

namespace K2dPlugin.Features.GenerateReport.Handlers
{
    public class CreateTextNoteTypeHandler : IExternalEventHandler
    {
        public List<TextNoteDto> NoteTypes { get; set; }
        public Document Document { get; set; }

        public CreateTextNoteTypeHandler(Document document)
        {
            Document = document;
        }

        public void Execute(UIApplication app)
        {
            try
            {
                var documentFromUi = app.ActiveUIDocument.Document;

                using (Transaction transaction = new Transaction(Document, "Create Note Type"))
                {
                    CreateTextNoteType(documentFromUi, "headerText", 0.25);
                    CreateTextNoteType(documentFromUi, "normalText", 0.125);



                    transaction.Commit();
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public string GetName()
        {
            return "CreateTextNoteTypeHandler";
        }

        private void CreateTextNoteType(Document doc, string newTypeName, double textSize)
        {
            var textTypeExist = new FilteredElementCollector(doc)
                .OfClass(typeof(TextNoteType)).Cast<TextNoteType>()
                .SingleOrDefault(x => x.Name == newTypeName);

            if (textTypeExist != null)
            {
                doc.Delete(textTypeExist.Id);
            };

            if (textTypeExist != null) return;

            var originalTextNoteType = new FilteredElementCollector(doc)
                .OfClass(typeof(TextNoteType))
                .ToElements()
                .FirstOrDefault() as TextNoteType;

            if (originalTextNoteType == null) throw new InvalidOperationException("No text note type found.");


            var duplicateTextNote = originalTextNoteType.Duplicate(newTypeName) as TextNoteType;

            if (duplicateTextNote == null) throw new InvalidOperationException("No text note type found.");

            var paramTextSize = duplicateTextNote.get_Parameter(BuiltInParameter.TEXT_SIZE);

            if (paramTextSize != null)
            {
                paramTextSize.Set(textSize);
            }

            var paramTextFont = duplicateTextNote.get_Parameter(BuiltInParameter.TEXT_FONT);

            if (paramTextFont != null && newTypeName == "normalText")
            {
                paramTextFont.Set("Arial Narrow");
            }

            if (paramTextFont != null && newTypeName == "headerText")
            {
                paramTextFont.Set("Arial-BoldMT");
            }
        }

    }
}
