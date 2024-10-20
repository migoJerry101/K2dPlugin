using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace K2dPlugin.Features.GenerateReport.Handlers
{
    internal class CreateLineCpvcHandler : IExternalEventHandler
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


                    View legendCpvc = views
                        .Cast<View>()
                        .FirstOrDefault(view => view.ViewType == ViewType.Legend && view.Name == "Cpvc");

                    if (legendCpvc != null)
                    {
                        //horizontal
                        InsertLine(doc, legendCpvc,
                            new XYZ(0.089188167, 10.223587349, 0.000000000),
                            new XYZ(88.420180628, 10.223587349, 0.000000000)
                        );

                        InsertLine(doc, legendCpvc,
                            new XYZ(88.420180628, 4.297984298, 0.000000000),
                            new XYZ(0.089188167, 4.297984298, 0.000000000)
                        );

                        InsertLine(doc, legendCpvc,
                            new XYZ(86.420180628, -3.493126483, 0.000000000),
                            new XYZ(2.089188167, -3.493126483, 0.000000000)
                        );


                        InsertLine(doc, legendCpvc,
                            new XYZ(2.089188167, -9.493126483, 0.000000000),
                            new XYZ(86.420180628, -9.493126483, 0.000000000)
                        );

                        InsertLine(doc, legendCpvc,
                            new XYZ(2.089188167, -14.493126483, 0.000000000),
                            new XYZ(86.420180628, -14.493126483, 0.000000000)
                        );

                        InsertLine(doc, legendCpvc,
                            new XYZ(2.089188167, -19.493126483, 0.000000000),
                            new XYZ(86.420180628, -19.493126483, 0.000000000)
                        );

                        InsertLine(doc, legendCpvc,
                            new XYZ(2.089188167, -24.493126483, 0.000000000),
                            new XYZ(86.420180628, -24.493126483, 0.000000000)
                        );

                        InsertLine(doc, legendCpvc,
                            new XYZ(2.089188167, -29.493126483, 0.000000000),
                            new XYZ(86.420180628, -29.493126483, 0.000000000)
                        );

                        InsertLine(doc, legendCpvc,
                            new XYZ(2.089188167, -34.493126483, 0.000000000),
                            new XYZ(86.420180628, -34.493126483, 0.000000000)
                        );


                        InsertLine(doc, legendCpvc,
                            new XYZ(86.420180628, -42.493126483, 0.000000000),
                            new XYZ(2.089188167, -42.493126483, 0.000000000)
                        );

                        InsertLine(doc, legendCpvc,
                            new XYZ(2.089188167, -48.493126483, 0.000000000),
                            new XYZ(86.420180628, -48.493126483, 0.000000000)
                        );

                        InsertLine(doc, legendCpvc,
                            new XYZ(2.089188167, -53.493126483, 0.000000000),
                            new XYZ(86.420180628, -53.493126483, 0.000000000)
                        );

                        InsertLine(doc, legendCpvc,
                            new XYZ(2.089188167, -58.493126483, 0.000000000),
                            new XYZ(86.420180628, -58.493126483, 0.000000000)
                        );

                        InsertLine(doc, legendCpvc,
                            new XYZ(2.089188167, -63.493126483, 0.000000000),
                            new XYZ(86.420180628, -63.493126483, 0.000000000)
                        );

                        InsertLine(doc, legendCpvc,
                            new XYZ(2.089188167, -68.493126483, 0.000000000),
                            new XYZ(86.420180628, -68.493126483, 0.000000000)
                        );


                        InsertLine(doc, legendCpvc,
                            new XYZ(2.089188167, -73.493126483, 0.000000000),
                            new XYZ(86.420180628, -73.493126483, 0.000000000)
                        );


                        InsertLine(doc, legendCpvc,
                            new XYZ(0.089188167, -75.493126483, 0.000000000),
                            new XYZ(88.420180628, -75.493126483, 0.000000000)
                        );

                        //vertical



                        InsertLine(doc, legendCpvc,
                            new XYZ(0.089188167, 10.223587349, 0.000000000),
                            new XYZ(0.089188167, -75.493126483, 0.000000000)
                        );


                        InsertLine(doc, legendCpvc,
                            new XYZ(72.420180628, -34.493126483, 0.000000000),
                            new XYZ(72.420180628, -3.493126483, 0.000000000)
                        );


                        InsertLine(doc, legendCpvc,
                            new XYZ(2.089188167, -3.493126483, 0.000000000),
                            new XYZ(2.089188167, -34.493126483, 0.000000000)
                        );


                        InsertLine(doc, legendCpvc,
                            new XYZ(9.420180628, -34.493126483, 0.000000000),
                            new XYZ(9.420180628, -3.493126483, 0.000000000)
                        );

                        InsertLine(doc, legendCpvc,
                            new XYZ(16.420180628, -34.493126483, 0.000000000),
                            new XYZ(16.420180628, -3.493126483, 0.000000000)
                        );


                        InsertLine(doc, legendCpvc,
                            new XYZ(23.420180628, -34.493126483, 0.000000000),
                            new XYZ(23.420180628, -3.493126483, 0.000000000)
                        );


                        InsertLine(doc, legendCpvc,
                            new XYZ(30.420180628, -34.493126483, 0.000000000),
                            new XYZ(30.420180628, -3.493126483, 0.000000000)
                        );


                        InsertLine(doc, legendCpvc,
                            new XYZ(37.420180628, -34.493126483, 0.000000000),
                            new XYZ(37.420180628, -3.493126483, 0.000000000)
                        );

                        InsertLine(doc, legendCpvc,
                            new XYZ(44.420180628, -34.493126483, 0.000000000),
                            new XYZ(44.420180628, -3.493126483, 0.000000000)
                        );

                        InsertLine(doc, legendCpvc,
                            new XYZ(51.420180628, -34.493126483, 0.000000000),
                            new XYZ(51.420180628, -3.493126483, 0.000000000)
                        );


                        InsertLine(doc, legendCpvc,
                            new XYZ(58.420180628, -34.493126483, 0.000000000),
                            new XYZ(58.420180628, -3.493126483, 0.000000000)
                        );

                        InsertLine(doc, legendCpvc,
                            new XYZ(65.420180628, -34.493126483, 0.000000000),
                            new XYZ(65.420180628, -3.493126483, 0.000000000)
                        );

                        InsertLine(doc, legendCpvc,
                            new XYZ(79.420180628, -34.493126483, 0.000000000),
                            new XYZ(79.420180628, -3.493126483, 0.000000000)
                        );

                        InsertLine(doc, legendCpvc,
                            new XYZ(86.420180628, -34.493126483, 0.000000000),
                            new XYZ(86.420180628, -3.493126483, 0.000000000)
                        );

                        InsertLine(doc, legendCpvc,
                            new XYZ(88.420180628, -75.493126483, 0.000000000),
                            new XYZ(88.420180628, 10.223587349, 0.000000000)
                        );

                        InsertLine(doc, legendCpvc,
                            new XYZ(2.089188167, -42.493126483, 0.000000000),
                            new XYZ(2.089188167, -73.493126483, 0.000000000)
                        );


                        InsertLine(doc, legendCpvc,
                            new XYZ(9.420180628, -73.493126483, 0.000000000),
                            new XYZ(9.420180628, -42.493126483, 0.000000000)
                        );

                        InsertLine(doc, legendCpvc,
                            new XYZ(16.420180628, -73.493126483, 0.000000000),
                            new XYZ(16.420180628, -42.493126483, 0.000000000)
                        );




                        InsertLine(doc, legendCpvc,
                            new XYZ(23.420180628, -73.493126483, 0.000000000),
                            new XYZ(23.420180628, -42.493126483, 0.000000000)
                        );


                        InsertLine(doc, legendCpvc,
                            new XYZ(30.420180628, -73.493126483, 0.000000000),
                            new XYZ(30.420180628, -42.493126483, 0.000000000)
                        );

                        InsertLine(doc, legendCpvc,
                            new XYZ(37.420180628, -73.493126483, 0.000000000),
                            new XYZ(37.420180628, -42.493126483, 0.000000000)
                        );

                        InsertLine(doc, legendCpvc,
                            new XYZ(44.420180628, -73.493126483, 0.000000000),
                            new XYZ(44.420180628, -42.493126483, 0.000000000)
                        );


                        InsertLine(doc, legendCpvc,
                            new XYZ(51.420180628, -73.493126483, 0.000000000),
                            new XYZ(51.420180628, -42.493126483, 0.000000000)
                        );


                        InsertLine(doc, legendCpvc,
                            new XYZ(58.420180628, -73.493126483, 0.000000000),
                            new XYZ(58.420180628, -42.493126483, 0.000000000)
                        );

                        InsertLine(doc, legendCpvc,
                            new XYZ(65.420180628, -73.493126483, 0.000000000),
                            new XYZ(65.420180628, -42.493126483, 0.000000000)
                        );


                        InsertLine(doc, legendCpvc,
                            new XYZ(72.420180628, -73.493126483, 0.000000000),
                            new XYZ(72.420180628, -42.493126483, 0.000000000)
                        );


                        InsertLine(doc, legendCpvc,
                            new XYZ(79.420180628, -73.493126483, 0.000000000),
                            new XYZ(79.420180628, -42.493126483, 0.000000000)
                        );


                        InsertLine(doc, legendCpvc,
                            new XYZ(86.420180628, -73.493126483, 0.000000000),
                            new XYZ(86.420180628, -42.493126483, 0.000000000)
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
            return "CreateLineCpvcHandler";
        }
    }
}
