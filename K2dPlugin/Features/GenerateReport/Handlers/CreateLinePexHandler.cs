using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace K2dPlugin.Features.GenerateReport.Handlers
{
    internal class CreateLinePexHandler : IExternalEventHandler
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



                    View legendPex = views
                        .Cast<View>()
                        .FirstOrDefault(view => view.ViewType == ViewType.Legend && view.Name == "Pex");

                    if (legendPex != null)
                    {
  
                        InsertLine(doc, legendPex,
                            new XYZ(0.098033697, 9.809679022, 0.000000000), new XYZ(88.429026158, 9.809679022, 0.000000000)
                        );

                        InsertLine(doc, legendPex,
                            new XYZ(88.429026158, 3.884075972, 0.000000000), new XYZ(0.098033697, 3.884075972, 0.000000000)
                        );

                        InsertLine(doc, legendPex,
                            new XYZ(86.429026158, -3.907034809, 0.000000000), new XYZ(2.098033697, -3.907034809, 0.000000000)

                        );

                        InsertLine(doc, legendPex,
                            new XYZ(2.098033697, -9.907034809, 0.000000000), new XYZ(86.429026158, -9.907034809, 0.000000000)
                        );

                        InsertLine(doc, legendPex,
                            new XYZ(2.098033697, -14.907034809, 0.000000000), new XYZ(86.429026158, -14.907034809, 0.000000000)
                        );

                        InsertLine(doc, legendPex,
                            new XYZ(2.098033697, -19.907034809, 0.000000000), new XYZ(86.429026158, -19.907034809, 0.000000000)

                        );

                        InsertLine(doc, legendPex,
                            new XYZ(2.098033697, -24.907034809, 0.000000000), new XYZ(86.429026158, -24.907034809, 0.000000000)


                        );


                        InsertLine(doc, legendPex,
                            new XYZ(2.098033697, -29.907034809, 0.000000000), new XYZ(86.429026158, -29.907034809, 0.000000000)
                        );

                        InsertLine(doc, legendPex,
                            new XYZ(2.098033697, -34.907034809, 0.000000000), new XYZ(86.429026158, -34.907034809, 0.000000000)
                        );

                        InsertLine(doc, legendPex,
                            new XYZ(0.098033697, -36.907034809, 0.000000000), new XYZ(88.429026158, -36.907034809, 0.000000000)
                        );


                        //vertical

                        InsertLine(doc, legendPex,
                            new XYZ(0.098033697, 9.809679022, 0.000000000),
                            new XYZ(0.098033697, -36.907034809, 0.000000000)
                        );

                        InsertLine(doc, legendPex,
                            new XYZ(2.098033697, -3.907034809, 0.000000000), new XYZ(2.098033697, -34.907034809, 0.000000000)
                        );


                        InsertLine(doc, legendPex,
                            new XYZ(9.429026158, -34.907034809, 0.000000000), new XYZ(9.429026158, -3.907034809, 0.000000000)
                        );

                        InsertLine(doc, legendPex,
                            new XYZ(16.429026158, -34.907034809, 0.000000000), new XYZ(16.429026158, -3.907034809, 0.000000000)
                        );


                        InsertLine(doc, legendPex,

                            new XYZ(23.429026158, -34.907034809, 0.000000000), new XYZ(23.429026158, -3.907034809, 0.000000000)
                        );
                        InsertLine(doc, legendPex,
                            new XYZ(30.429026158, -34.907034809, 0.000000000), new XYZ(30.429026158, -3.907034809, 0.000000000)

                        );

                        InsertLine(doc, legendPex,
                            new XYZ(37.429026158, -34.907034809, 0.000000000), new XYZ(37.429026158, -3.907034809, 0.000000000)

                        );

                        InsertLine(doc, legendPex,
                            new XYZ(44.429026158, -34.907034809, 0.000000000), new XYZ(44.429026158, -3.907034809, 0.000000000)
                        );

                        InsertLine(doc, legendPex,
                            new XYZ(51.429026158, -34.907034809, 0.000000000), new XYZ(51.429026158, -3.907034809, 0.000000000)

                        );

                        InsertLine(doc, legendPex,
                            new XYZ(58.429026158, -34.907034809, 0.000000000), new XYZ(58.429026158, -3.907034809, 0.000000000)
                        );

                        InsertLine(doc, legendPex,
                            new XYZ(65.429026158, -34.907034809, 0.000000000), new XYZ(65.429026158, -3.907034809, 0.000000000)
                        );

                        InsertLine(doc, legendPex,
                            new XYZ(72.429026158, -34.907034809, 0.000000000), new XYZ(72.429026158, -3.907034809, 0.000000000)
                        );

                        InsertLine(doc, legendPex,
                            new XYZ(72.429026158, -34.907034809, 0.000000000), new XYZ(72.429026158, -3.907034809, 0.000000000)
                        );

                        InsertLine(doc, legendPex,
                            new XYZ(79.429026158, -34.907034809, 0.000000000), new XYZ(79.429026158, -3.907034809, 0.000000000)
                        );

                        InsertLine(doc, legendPex,
                            new XYZ(86.429026158, -34.907034809, 0.000000000), new XYZ(86.429026158, -3.907034809, 0.000000000)
                        );

                        InsertLine(doc, legendPex,
                            new XYZ(88.429026158, -36.907034809, 0.000000000), new XYZ(88.429026158, 9.809679022, 0.000000000)
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
            return "CreateLinePexHandler";
        }
    }
}
