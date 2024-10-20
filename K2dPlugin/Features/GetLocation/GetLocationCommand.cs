using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;

namespace K2dPlugin.Features.GetLocattion
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    public class GetLocationCommand : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            // Get the current Revit application and UI document
            UIApplication uiApp = commandData.Application;
            UIDocument uiDoc = uiApp.ActiveUIDocument;
            Document doc = uiDoc.Document;

            try
            {
                // Prompt user to pick a text element in the legend view
                Reference pickedRef = uiDoc.Selection.PickObject(ObjectType.Element, "Select a text element in the legend view");
                if (pickedRef == null)
                {
                    message = "No element selected.";
                    return Result.Cancelled;
                }

                // Get the selected element
                Element pickedElement = doc.GetElement(pickedRef);

                // Ensure the element is a TextNote (which is used for text elements in Revit)
                if (pickedElement is TextNote textNote)
                {
                    // Get the location of the text element
                    XYZ location = textNote.Coord;

                    if (location != null)
                    {
                        Clipboard.SetText(location.ToString());
                        // Display the location or use it in your process
                        TaskDialog.Show("Text Location", $"Location of the text: \n\n  X={location.X}, \n\n Y={location.Y}, \n\n Z={location.Z}, \n\n {location.ToString()}");

                        return Result.Succeeded;
                    }
                    else
                    {
                        message = "Unable to get location of the text element.";
                        return Result.Failed;
                    }
                }
                else
                {
                    message = "The selected element is not a text element.";
                    return Result.Failed;
                }
            }
            catch (Autodesk.Revit.Exceptions.OperationCanceledException)
            {
                return Result.Cancelled;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return Result.Failed;
            }
            try
            {
                // Prompt the user to pick an element (either a TextNote or a line)
                //TaskDialog dialog = new TaskDialog("Select Element Type")
                //{
                //    MainInstruction = "Select an element type to pick",
                //    MainContent = "Choose to pick a text element or a line element.",
                //    CommonButtons = TaskDialogCommonButtons.Close
                //};
                //dialog.AddCommandLink(TaskDialogCommandLinkId.CommandLink1, "Pick a Text Element");
                //dialog.AddCommandLink(TaskDialogCommandLinkId.CommandLink2, "Pick a Line Element");

                //TaskDialogResult result = dialog.Show();

                Reference pickedRef = null;
                Element pickedElement = null;

                //if (result == TaskDialogResult.CommandLink1)
                //{
                //    // Prompt user to pick a text element
                //    pickedRef = uiDoc.Selection.PickObject(ObjectType.Element, "Select a text element in the legend view");

                //    if (pickedRef == null)
                //    {
                //        message = "No element selected.";
                //        return Result.Cancelled;
                //    }

                //    // Get the selected element
                //    pickedElement = doc.GetElement(pickedRef);

                //    // Ensure the element is a TextNote (which is used for text elements in Revit)
                //    if (pickedElement is TextNote textNote)
                //    {
                //        // Get the location of the text element
                //        XYZ location = textNote.Coord;

                //        if (location != null)
                //        {
                //            Clipboard.SetText(location.ToString());
                //            // Display the location or use it in your process
                //            TaskDialog.Show("Text Location", $"Location of the text: \n\n  X={location.X}, \n\n Y={location.Y}, \n\n Z={location.Z}");

                //            return Result.Succeeded;
                //        }
                //        else
                //        {
                //            message = "Unable to get location of the text element.";
                //            return Result.Failed;
                //        }
                //    }
                //    else
                //    {
                //        message = "The selected element is not a text element.";
                //        return Result.Failed;
                //    }
                //}
                //else if (result == TaskDialogResult.CommandLink2)
                //{
                    // Prompt user to pick a line element
                    pickedRef = uiDoc.Selection.PickObject(ObjectType.Element, "Select a line element");

                    if (pickedRef == null)
                    {
                        message = "No element selected.";
                        return Result.Cancelled;
                    }

                    // Get the selected element
                    pickedElement = doc.GetElement(pickedRef);

                    // Ensure the element is a Line (Model Line or Detail Line)
                    LocationCurve locCurve = pickedElement.Location as LocationCurve;

                    if (locCurve != null && locCurve.Curve is Line line)
                    {
                        // Get the start and end points of the line
                        XYZ startPoint = line.GetEndPoint(0);
                        XYZ endPoint = line.GetEndPoint(1);

                        // Display the start and end points
                        Clipboard.SetText($"new XYZ {startPoint.ToString()}, new XYZ{endPoint.ToString()}");
                        TaskDialog.Show("Line Location", $"Start Point: \n\n  X={startPoint.X}, Y={startPoint.Y}, Z={startPoint.Z} \n\n End Point: \n\n  X={endPoint.X}, Y={endPoint.Y}, Z={endPoint.Z}");

                        return Result.Succeeded;
                    }
                    else
                    {
                        message = "The selected element is not a valid line.";
                        return Result.Failed;
                    }
                //}

                message = "No valid option selected.";
                return Result.Cancelled;
            }
            catch (Autodesk.Revit.Exceptions.OperationCanceledException)
            {
                return Result.Cancelled;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return Result.Failed;
            }
        }
    }
}
