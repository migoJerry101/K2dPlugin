using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using K2dPlugin.Features.PipeSum.Form;
using K2dPlugin.Interface;

namespace K2dPlugin.Features.PipeSum
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    internal class PipeSumCommand : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            var uiApp = commandData.Application;
            var doc = uiApp.ActiveUIDocument.Document;

            /*using (var form = new PipeSumForm(doc, uiApp))
            {
                return form.ShowDialog() == DialogResult.OK ? Result.Succeeded : Result.Cancelled;
            }*/

            // Create an instance of the form
            var form = new PipeSumForm(doc, uiApp);

            // Show the form modelessly
            form.Show();

            return Result.Succeeded;
        }
    }
}
