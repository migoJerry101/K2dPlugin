using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;

namespace K2dPlugin.Services
{
    internal class TextNoteService
    {
        public TextNote CreateTextNote(Document doc, XYZ position, string text)
        {
            var textNoteType = new FilteredElementCollector(doc)
                .OfClass(typeof(TextNoteType))
                .Cast<TextNoteType>()
                .FirstOrDefault();

            var textNote = TextNote.Create(doc, doc.ActiveView.Id, position, text, textNoteType.Id);

            return textNote;
        }
    }
}
