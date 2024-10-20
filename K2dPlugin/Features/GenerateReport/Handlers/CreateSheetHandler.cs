using System;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Documents;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace K2dPlugin.Features.GenerateReport.Handlers
{
    public class CreateSheetHandler : IExternalEventHandler
    {
        public Document Document { get; set; }

        public CreateSheetHandler(Document document)
        {
            Document = document;
        }

        private void AddProjectParameter(Document doc)
        {
            using (Transaction trans = new Transaction(doc, "Add Project Parameter"))
            {
                trans.Start();

                // Create a new SharedParameterElement
                CategorySet categories = new CategorySet();
                categories.Insert(doc.Settings.Categories.get_Item(BuiltInCategory.OST_Sheets));

                // Define the new parameter
                ExternalDefinitionCreationOptions options = new ExternalDefinitionCreationOptions("TextNoteId", ParameterType.Text);
                Definition newDefinition = doc.Application.OpenSharedParameterFile().Groups.Create("TextNoteGroup").Definitions.Create(options);

                // Create an instance binding
                InstanceBinding instanceBinding = doc.Application.Create.NewInstanceBinding(categories);

                // Add the parameter to the project
                doc.ParameterBindings.Insert(newDefinition, instanceBinding, BuiltInParameterGroup.PG_TEXT);

                trans.Commit();
            }
        }

        public void Execute(UIApplication app)
        {
            try
            {
                using (Transaction tansaction = new Transaction(Document, "Create Sheet"))
                {
                    tansaction.Start();

                    var documentFromUi = app.ActiveUIDocument.Document;

                    var collector = new FilteredElementCollector(Document)
                        .OfCategory(BuiltInCategory.OST_TitleBlocks);

                    FamilySymbol titleBlock = collector.FirstElement() as FamilySymbol;

                    if (titleBlock == null)
                    {
                        throw new InvalidOperationException("No title block family found.");
                    }

                    ViewSheet newSheet = ViewSheet.Create(Document, titleBlock.Id);

                    newSheet.Name = "water Calculation";
                    newSheet.SheetNumber = "A101";

                    var headerText = CreateTextNoteType(documentFromUi, "headerText", 0.25/12, false);
                    var normalText = CreateTextNoteType(documentFromUi, "normalText", 0.125/12, false);
                    var normalTextUnderline = CreateTextNoteType(documentFromUi, "normalTextUnderline", 0.125/12, false);




                    //Document.Delete(headerText.Id);
                    //Document.Delete(normalText.Id);
                    //Document.Delete(normalTextUnderline.Id);

                    tansaction.Commit();
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error creating sheet: {ex.Message}", ex);
            }
        }

        public string GetName()
        {
            return "CreateSheetHandler";
        }

        private void AddTextNote(Document doc, ViewSheet sheet, TextNoteType textNoteType, XYZ position, string text)
        {
            TextNote textNote = TextNote.Create(doc, sheet.Id, position, text, textNoteType.Id);

        }

        private TextNoteType CreateTextNoteType(Document doc, string newTypeName, double textSize, bool underline)
        {
            var textTypeExist = new FilteredElementCollector(doc)
                .OfClass(typeof(TextNoteType)).Cast<TextNoteType>()
                .SingleOrDefault(x => x.Name == newTypeName);

            if (textTypeExist != null) return textTypeExist;


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

            if (paramTextFont != null && newTypeName == "headerText")
            {
                paramTextFont.Set("Arial-BoldMT");
            }

            if (underline)
            {
                duplicateTextNote.LookupParameter("Underline").Set(0);
            }

            return originalTextNoteType;
        }

        private void DeleteTextType(Document doc, string name)
        {
            var textTypeExist = new FilteredElementCollector(doc)
                .OfClass(typeof(TextNoteType)).Cast<TextNoteType>()
                .SingleOrDefault(x => x.Name == name);

            if (textTypeExist != null)
            {
                doc.Delete(textTypeExist.Id);
            }

        }
    }
}
