using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using K2dPlugin.Features.GenerateReport.GenerateReportForms;


namespace K2dPlugin.Features.GenerateReport
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    public class GenerateReportCommand : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            var uiApp = commandData.Application;
            var doc = uiApp.ActiveUIDocument.Document;
            var form = new Test(commandData, doc, uiApp);
                
            form.Show();

            return Result.Succeeded;
        }
    }
}
