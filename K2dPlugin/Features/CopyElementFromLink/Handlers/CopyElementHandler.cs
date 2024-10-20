using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace K2dPlugin.Features.CopyElementFromLink.Handlers
{
    public class CopyElementHandler : IExternalEventHandler
    {
        public Document Document { get; set; }
        public Document LinkedDocument { get; set; }
        public List<ElementId> ElementIds { get; set; }
        //public XYZ Location { get; set; }
        public void Execute(UIApplication app)
        {
            try
            {

                using (var transaction = new Transaction(Document, "Copy Elements from Linked Document"))
                {
                    transaction.Start();

                    var copyPasteOptions = new CopyPasteOptions();
                    copyPasteOptions.SetDuplicateTypeNamesHandler(new MyCopyHandler());

                    var copiedElementIds = ElementTransformUtils.CopyElements(
                        LinkedDocument,
                        ElementIds,
                        Document,
                        Transform.Identity,
                        copyPasteOptions
                    );

                    //if (Location != null)
                    //{
                    //    AdjustElementLocations(copiedElementIds);
                    //}

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
            return "CopyElementHandler";
        }

        //private void AdjustElementLocations(ICollection<ElementId> copiedElementIds)
        //{
        //    foreach (var elementId in copiedElementIds)
        //    {
        //        var element = Document.GetElement(elementId);

        //        if (element is FamilyInstance familyInstance)
        //        {
        //            // Adjust the location of the family instance
        //            var locationPoint = familyInstance.Location as LocationPoint;
        //            if (locationPoint != null)
        //            {
        //                // Move the element to the new location
        //                XYZ oldLocation = locationPoint.Point;
        //                XYZ translationVector = Location - oldLocation;
        //                ElementTransformUtils.MoveElement(Document, elementId, translationVector);
        //            }
        //        }
        //        else if (element is FamilySymbol familySymbol)
        //        {
        //            // Handle family symbols if necessary
        //            // Family symbols generally do not have locations themselves
        //        }
        //        else
        //        {
        //            // Handle other types of elements if necessary
        //            // For example, you might need to handle LocationCurve or other locations
        //        }
        //    }
        //}
    }
}
