using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace K2dPlugin.Features.GenerateReport.Handlers
{
    internal class CreateLineCopperHandler : IExternalEventHandler
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


                    View legendCopper = views
                        .Cast<View>()
                        .FirstOrDefault(view => view.ViewType == ViewType.Legend && view.Name == "Copper Type");

                    if (legendCopper != null)
                    {
                        InsertLine(doc, legendCopper,
                            new XYZ(0.094121140, 10.204275534, 0.000000000),
                            new XYZ(88.425113601, 10.204275534, 0.000000000)
                            );

                        InsertLine(doc, legendCopper,
                            new XYZ(88.425113601, 4.278672484, 0.000000000),
                            new XYZ(0.094121140, 4.278672484, 0.000000000)
                        );

                        InsertLine(doc, legendCopper,
                            new XYZ(86.425113601, -3.512438297, 0.000000000),
                            new XYZ(2.094121140, -3.512438297, 0.000000000)
                        );

                        InsertLine(doc, legendCopper,
                            new XYZ(2.094121140, -9.512438297, 0.000000000),
                            new XYZ(86.425113601, -9.512438297, 0.000000000)
                        );

                        InsertLine(doc, legendCopper,
                            new XYZ(2.094121140, -14.512438297, 0.000000000),
                            new XYZ(86.425113601, -14.512438297, 0.000000000)
                        );

                        InsertLine(doc, legendCopper,
                            new XYZ(2.094121140, -19.512438297, 0.000000000),
                            new XYZ(86.425113601, -19.512438297, 0.000000000)
                        );

                        InsertLine(doc, legendCopper,
                            new XYZ(2.094121140, -24.512438297, 0.000000000),
                            new XYZ(86.425113601, -24.512438297, 0.000000000)

                        );

                        InsertLine(doc, legendCopper,
                            new XYZ(2.094121140, -29.512438297, 0.000000000),
                            new XYZ(86.425113601, -29.512438297, 0.000000000)
                        );

                        InsertLine(doc, legendCopper,
                            new XYZ(2.094121140, -34.512438297, 0.000000000),
                            new XYZ(86.425113601, -34.512438297, 0.000000000)
                        );


                        InsertLine(doc, legendCopper,
                            new XYZ(86.425113601, -42.012438297, 0.000000000),
                            new XYZ(2.094121140, -42.012438297, 0.000000000)
                        );

                        InsertLine(doc, legendCopper,
                            new XYZ(2.094121140, -48.012438297, 0.000000000),
                            new XYZ(86.425113601, -48.012438297, 0.000000000)
                        );

                        InsertLine(doc, legendCopper,
                            new XYZ(2.094121140, -53.012438297, 0.000000000),
                            new XYZ(86.425113601, -53.012438297, 0.000000000)
                        );

                        InsertLine(doc, legendCopper,
                            new XYZ(2.094121140, -58.012438297, 0.000000000),
                            new XYZ(86.425113601, -58.012438297, 0.000000000)
                        );

                        InsertLine(doc, legendCopper,
                            new XYZ(2.094121140, -63.012438297, 0.000000000),
                            new XYZ(86.425113601, -63.012438297, 0.000000000)
                        );


                        InsertLine(doc, legendCopper,
                            new XYZ(2.094121140, -68.012438297, 0.000000000),
                            new XYZ(86.425113601, -68.012438297, 0.000000000)
                        );

                        InsertLine(doc, legendCopper,
                            new XYZ(2.094121140, -73.012438297, 0.000000000),
                            new XYZ(86.425113601, -73.012438297, 0.000000000)
                        );

                        InsertLine(doc, legendCopper,
                            new XYZ(0.094121140, -75.012438297, 0.000000000),
                            new XYZ(88.425113601, -75.012438297, 0.000000000)
                        );

                        //Vertical


                        InsertLine(doc, legendCopper,
                            new XYZ(65.425113601, -34.512438297, 0.000000000),
                            new XYZ(65.425113601, -3.512438297, 0.000000000)
                        );

                        InsertLine(doc, legendCopper,
                            new XYZ(0.094121140, 10.204275534, 0.000000000),
                            new XYZ(0.094121140, -75.012438297, 0.000000000)
                        );

                        InsertLine(doc, legendCopper,
                            new XYZ(2.094121140, -3.512438297, 0.000000000),
                            new XYZ(2.094121140, -34.512438297, 0.000000000)
                        );

                        InsertLine(doc, legendCopper,
                            new XYZ(9.425113601, -34.512438297, 0.000000000),
                            new XYZ(9.425113601, -3.512438297, 0.000000000)
                        );

                        InsertLine(doc, legendCopper,
                            new XYZ(16.425113601, -34.512438297, 0.000000000),
                            new XYZ(16.425113601, -3.512438297, 0.000000000)
                        );


                        InsertLine(doc, legendCopper,
                            new XYZ(23.425113601, -34.512438297, 0.000000000),
                            new XYZ(23.425113601, -3.512438297, 0.000000000)
                        );

                        InsertLine(doc, legendCopper,
                            new XYZ(30.425113601, -34.512438297, 0.000000000),
                            new XYZ(30.425113601, -3.512438297, 0.000000000)

                        );

                        InsertLine(doc, legendCopper,
                            new XYZ(37.425113601, -34.512438297, 0.000000000),
                            new XYZ(37.425113601, -3.512438297, 0.000000000)
                        );

                        InsertLine(doc, legendCopper,
                            new XYZ(44.425113601, -34.512438297, 0.000000000),
                            new XYZ(44.425113601, -3.512438297, 0.000000000)
                        );

                        InsertLine(doc, legendCopper,
                            new XYZ(51.425113601, -34.512438297, 0.000000000),
                            new XYZ(51.425113601, -3.512438297, 0.000000000)
                        );

                        InsertLine(doc, legendCopper,
                            new XYZ(58.425113601, -34.512438297, 0.000000000),
                            new XYZ(58.425113601, -3.512438297, 0.000000000)
                        );

                        InsertLine(doc, legendCopper,
                            new XYZ(72.425113601, -34.512438297, 0.000000000),
                            new XYZ(72.425113601, -3.512438297, 0.000000000)
                        );

                        InsertLine(doc, legendCopper,
                            new XYZ(79.425113601, -34.512438297, 0.000000000),
                            new XYZ(79.425113601, -3.512438297, 0.000000000)
                        );

                        InsertLine(doc, legendCopper,
                            new XYZ(86.425113601, -34.512438297, 0.000000000),
                            new XYZ(86.425113601, -3.512438297, 0.000000000)
                        );

                        InsertLine(doc, legendCopper,
                            new XYZ(88.425113601, -75.012438297, 0.000000000),
                            new XYZ(88.425113601, 10.204275534, 0.000000000)

                        );

                        ////////////////////

                        InsertLine(doc, legendCopper,
                            new XYZ(2.094121140, -42.012438297, 0.000000000),
                            new XYZ(2.094121140, -73.012438297, 0.000000000)

                        );

                        InsertLine(doc, legendCopper,
                            new XYZ(9.425113601, -73.012438297, 0.000000000),
                            new XYZ(9.425113601, -42.012438297, 0.000000000)

                        );

                        InsertLine(doc, legendCopper,
                            new XYZ(16.425113601, -73.012438297, 0.000000000),
                            new XYZ(16.425113601, -42.012438297, 0.000000000)

                        );

                        InsertLine(doc, legendCopper,
                            new XYZ(23.425113601, -73.012438297, 0.000000000),
                            new XYZ(23.425113601, -42.012438297, 0.000000000)

                        );

                        InsertLine(doc, legendCopper,
                            new XYZ(30.425113601, -73.012438297, 0.000000000),
                            new XYZ(30.425113601, -42.012438297, 0.000000000)

                        );

                        InsertLine(doc, legendCopper,
                            new XYZ(37.425113601, -73.012438297, 0.000000000),
                            new XYZ(37.425113601, -42.012438297, 0.000000000)

                        );

                        InsertLine(doc, legendCopper,
                            new XYZ(44.425113601, -73.012438297, 0.000000000),
                            new XYZ(44.425113601, -42.012438297, 0.000000000)

                        );

                        InsertLine(doc, legendCopper,
                            new XYZ(51.425113601, -73.012438297, 0.000000000),
                            new XYZ(51.425113601, -42.012438297, 0.000000000)

                        );


                        InsertLine(doc, legendCopper,
                            new XYZ(58.425113601, -73.012438297, 0.000000000),
                            new XYZ(58.425113601, -42.012438297, 0.000000000)
                        );


                        InsertLine(doc, legendCopper,
                            new XYZ(65.425113601, -73.012438297, 0.000000000),
                            new XYZ(65.425113601, -42.012438297, 0.000000000)
                        );

                        InsertLine(doc, legendCopper,
                            new XYZ(72.425113601, -73.012438297, 0.000000000),
                            new XYZ(72.425113601, -42.012438297, 0.000000000)
                        );

                        InsertLine(doc, legendCopper,
                            new XYZ(79.425113601, -73.012438297, 0.000000000),
                            new XYZ(79.425113601, -42.012438297, 0.000000000)
                        );

                        InsertLine(doc, legendCopper,
                            new XYZ(86.425113601, -73.012438297, 0.000000000),
                            new XYZ(86.425113601, -42.012438297, 0.000000000)
                        );
                    }

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
            return "CreateLineCopperHandler";
        }
    }
}
