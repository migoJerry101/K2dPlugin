using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using K2dPlugin.Features.CopyElementFromLink.CopyElementForm;

namespace K2dPlugin.Features.CopyElementFromLink
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    internal class CopyElementFromLinkCommand : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            var uiApp = commandData.Application;
            var doc = uiApp.ActiveUIDocument.Document;
            var form = new CopyElementFromLinkForm(commandData, doc, uiApp);

            form.Show();

            return Result.Succeeded;
        }
    }
}
