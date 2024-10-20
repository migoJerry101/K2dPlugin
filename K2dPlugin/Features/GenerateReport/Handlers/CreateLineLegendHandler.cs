using System;
using System.Collections.Generic;
using System.Linq;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace K2dPlugin.Features.GenerateReport.Handlers
{
    internal class CreateLineLegendHandler : IExternalEventHandler
    {
        public void Execute(UIApplication app)
        {
            var uiDoc = app.ActiveUIDocument;
            var doc = uiDoc.Document;

            using (Transaction tx = new Transaction(doc))
            {
                try
                {
                    tx.Start("Create Legend Lines");

                    // Find the "water Calculation" legend view
                    FilteredElementCollector collector = new FilteredElementCollector(doc);
                    ICollection<Element> views = collector.OfClass(typeof(View)).ToElements();

                    View legend = views
                        .Cast<View>()
                        .FirstOrDefault(view => view.ViewType == ViewType.Legend && view.Name == "Water Calculation");

                    if (legend == null)
                    {
                        TaskDialog.Show("Error", "Legend view 'water Calculation' not found.");
                        tx.RollBack();
                        return;
                    }


                    InsertLine(doc, legend,
                        new XYZ(-18.586555673, 27.434721343, 0.000000000),
                        new XYZ(-18.586555673, -75.065278657, 0.000000000)
                        );

                    InsertLine(doc, legend,
                        new XYZ(-18.586555673, 27.434721343, 0.000000000),
                        new XYZ(69.744436788, 27.434721343, 0.000000000)
                    );

                    InsertLine(doc, legend,
                        new XYZ(69.744436788, 21.434721343, 0.000000000),
                        new XYZ(-18.586555673, 21.434721343, 0.000000000)
                    );

                    InsertLine(doc, legend,
                        new XYZ(69.744436788, -75.065278657, 0.000000000),
                        new XYZ(69.744436788, 27.434721343, 0.000000000)
                    );

                    InsertLine(doc, legend,
                        new XYZ(-18.586555673, -75.065278657, 0.000000000),
                        new XYZ(69.744436788, -75.065278657, 0.000000000)
                    );


                    View legendWaterDemand = views
                        .Cast<View>()
                        .FirstOrDefault(view => view.ViewType == ViewType.Legend && view.Name == "Water Demand");

                    if (legendWaterDemand == null)
                    {
                        TaskDialog.Show("Error", "Legend view 'water Calculation' not found.");
                        tx.RollBack();
                        return;
                    }


                    InsertLine(doc, legendWaterDemand,
                        new XYZ(0.128233721, 103.915676960, 0.000000000),
                        new XYZ(78.772438054, 103.915676960, 0.000000000)
                    );

                    InsertLine(doc, legendWaterDemand,
                        new XYZ(0.128233721, 97.915676960, 0.000000000),
                        new XYZ(78.772438054, 97.915676960, 0.000000000)
                    );

                    InsertLine(doc, legendWaterDemand,
                        new XYZ(28.772438054, 94.915676960, 0.000000000),
                        new XYZ(68.772438054, 94.915676960, 0.000000000)
                    );

                    InsertLine(doc, legendWaterDemand,
                        new XYZ(0.128233721, 91.915676960, 0.000000000),
                        new XYZ(78.772438054, 91.915676960, 0.000000000)
                    );

                    InsertLine(doc, legendWaterDemand,
                        new XYZ(0.128233721, 88.915676960, 0.000000000),
                        new XYZ(78.772438054, 88.915676960, 0.000000000)
                    );

                    InsertLine(doc, legendWaterDemand,
                        new XYZ(0.128233721, 82.915676960, 0.000000000),
                        new XYZ(78.772438054, 82.915676960, 0.000000000)
                    );

                    InsertLine(doc, legendWaterDemand,
                        new XYZ(0.128233721, 79.915676960, 0.000000000),
                        new XYZ(78.772438054, 79.915676960, 0.000000000)
                    );

                    InsertLine(doc, legendWaterDemand,
                        new XYZ(0.128233721, 76.915676960, 0.000000000),
                        new XYZ(78.772438054, 76.915676960, 0.000000000)
                    );

                    InsertLine(doc, legendWaterDemand,
                        new XYZ(0.128233721, 73.915676960, 0.000000000),
                        new XYZ(78.772438054, 73.915676960, 0.000000000)
                    );

                    InsertLine(doc, legendWaterDemand,
                        new XYZ(0.128233721, 70.915676960, 0.000000000),
                        new XYZ(78.772438054, 70.915676960, 0.000000000)
                    );

                    InsertLine(doc, legendWaterDemand,
                        new XYZ(0.128233721, 67.915676960, 0.000000000),
                        new XYZ(78.772438054, 67.915676960, 0.000000000)
                    );


                    InsertLine(doc, legendWaterDemand,
                        new XYZ(0.128233721, 61.915676960, 0.000000000),
                        new XYZ(78.772438054, 61.915676960, 0.000000000)
                    );

                    InsertLine(doc, legendWaterDemand,
                        new XYZ(0.128233721, 85.915676960, 0.000000000),
                        new XYZ(78.772438054, 85.915676960, 0.000000000)
                    );

                    InsertLine(doc, legendWaterDemand,
                        new XYZ(0.128233721, 58.915676960, 0.000000000),
                        new XYZ(78.772438054, 58.915676960, 0.000000000)
                    );

                    InsertLine(doc, legendWaterDemand,
                        new XYZ(0.128233721, 64.915676960, 0.000000000),
                        new XYZ(78.772438054, 64.915676960, 0.000000000)
                    );

                    InsertLine(doc, legendWaterDemand,
                        new XYZ(0.128233721, 55.915676960, 0.000000000),
                        new XYZ(78.772438054, 55.915676960, 0.000000000)
                    );

                    InsertLine(doc, legendWaterDemand,
                        new XYZ(0.128233721, 52.915676960, 0.000000000),
                        new XYZ(78.772438054, 52.915676960, 0.000000000)
                    );

                    InsertLine(doc, legendWaterDemand,
                        new XYZ(0.128233721, 49.915676960, 0.000000000),
                        new XYZ(78.772438054, 49.915676960, 0.000000000)
                    );

                    InsertLine(doc, legendWaterDemand,
                        new XYZ(0.128233721, 46.915676960, 0.000000000),
                        new XYZ(78.772438054, 46.915676960, 0.000000000)
                    );

                    InsertLine(doc, legendWaterDemand,
                        new XYZ(0.128233721, 43.915676960, 0.000000000),
                        new XYZ(78.772438054, 43.915676960, 0.000000000)
                    );

                    InsertLine(doc, legendWaterDemand,
                        new XYZ(0.128233721, 40.915676960, 0.000000000),
                        new XYZ(78.772438054, 40.915676960, 0.000000000)
                    );

                    InsertLine(doc, legendWaterDemand,
                        new XYZ(0.128233721, 37.915676960, 0.000000000),
                        new XYZ(78.772438054, 37.915676960, 0.000000000)
                    );

                    InsertLine(doc, legendWaterDemand,
                        new XYZ(0.128233721, 34.915676960, 0.000000000),
                        new XYZ(78.772438054, 34.915676960, 0.000000000)
                    );


                    InsertLine(doc, legendWaterDemand,
                        new XYZ(0.128233721, 31.915676960, 0.000000000),
                        new XYZ(78.772438054, 31.915676960, 0.000000000)
                    );

                    InsertLine(doc, legendWaterDemand,
                        new XYZ(0.128233721, 28.915676960, 0.000000000),
                        new XYZ(78.772438054, 28.915676960, 0.000000000)
                    );

                    InsertLine(doc, legendWaterDemand,
                        new XYZ(0.128233721, 25.915676960, 0.000000000),
                        new XYZ(78.772438054, 25.915676960, 0.000000000)
                    );

                    InsertLine(doc, legendWaterDemand,
                        new XYZ(0.128233721, 19.915676960, 0.000000000),
                        new XYZ(78.772438054, 19.915676960, 0.000000000)
                    );

                    InsertLine(doc, legendWaterDemand,
                        new XYZ(0.128233721, 103.915676960, 0.000000000),
                        new XYZ(0.128233721, 19.915676960, 0.000000000)
                    );

                    InsertLine(doc, legendWaterDemand,
                        new XYZ(28.772438054, 34.915676960, 0.000000000),
                        new XYZ(28.772438054, 97.915676960, 0.000000000)
                    );

                    InsertLine(doc, legendWaterDemand,
                        new XYZ(38.772438054, 34.915676960, 0.000000000),
                        new XYZ(38.772438054, 94.915676960, 0.000000000)
                    );

                    InsertLine(doc, legendWaterDemand,
                        new XYZ(48.772438054, 34.915676960, 0.000000000),
                        new XYZ(48.772438054, 97.915676960, 0.000000000)
                    );

                    InsertLine(doc, legendWaterDemand,
                        new XYZ(58.772438054, 34.915676960, 0.000000000),
                        new XYZ(58.772438054, 94.915676960, 0.000000000)
                    );

                    InsertLine(doc, legendWaterDemand,
                        new XYZ(68.772438054, 31.915676960, 0.000000000),
                        new XYZ(68.772438054, 97.915676960, 0.000000000)
                    );

                    InsertLine(doc, legendWaterDemand,
                        new XYZ(78.772438054, 19.915676960, 0.000000000),
                        new XYZ(78.772438054, 103.915676960, 0.000000000)
                    );

                    InsertLine(doc, legendWaterDemand,
                        new XYZ(0.128233721, 22.915676960, 0.000000000),
                        new XYZ(78.772438054, 22.915676960, 0.000000000)
                    );











                    tx.Commit();
                }
                catch (Exception e)
                {
                    if (tx.HasStarted())
                    {
                        tx.RollBack();
                    }

                    TaskDialog.Show("Error", e.Message);
                }
            }
        }

        private static void InsertLine(Document doc, View legend, XYZ point1, XYZ point2)
        {
            Line line = Line.CreateBound(point1, point2);

            DetailCurve detailLine = doc.Create.NewDetailCurve(legend, line);
        }

        public string GetName()
        {
            return "CreateLineLegendHandler";
        }
    }
}
