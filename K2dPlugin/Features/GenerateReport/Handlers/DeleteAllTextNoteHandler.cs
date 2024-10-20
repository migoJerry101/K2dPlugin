using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace K2dPlugin.Features.GenerateReport.Handlers
{
    internal class DeleteAllTextNoteHandler : IExternalEventHandler
    {
        public IList<Element> Elements { get; set; }
        public void Execute(UIApplication app)
        {
            UIDocument uiDoc = app.ActiveUIDocument;
            Document doc = uiDoc.Document;

            try
            {
                using (Transaction transaction = new Transaction(doc))
                {
                    transaction.Start("delete text");

                    foreach (var element in Elements)
                    {
                        doc.Delete(element.Id);
                    }

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
            return "DeleteAllTextNoteHandler";
        }
    }
}
