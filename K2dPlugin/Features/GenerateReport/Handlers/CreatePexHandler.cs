using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace K2dPlugin.Features.GenerateReport.Handlers
{
    internal class CreatePexHandler : IExternalEventHandler
    {
        public List<int> FlushTank { get; set; }
        public List<int> FlushValve { get; set; }
        public List<string> Velocity { get; set; }
        public List<int> MaxGpm { get; set; }
        public double PsiPerFt { get; set; }

        public void Execute(UIApplication app)
        {
            UIDocument uiDoc = app.ActiveUIDocument;
            Document doc = uiDoc.Document;


            using (Transaction tx = new Transaction(doc))
            {
                try
                {
                    tx.Start("Create Legend Pex");

                    List<View> legendViews = new List<View>();

                    FilteredElementCollector collector = new FilteredElementCollector(doc);
                    ICollection<Element> views = collector.OfClass(typeof(View)).ToElements();

                    foreach (Element e in views)
                    {
                        View view = e as View;

                        if (view != null && view.ViewType == ViewType.Legend && view.Name == "Pex")
                        {
                            legendViews.Add(view);
                        }
                    }

                    var legend = legendViews.SingleOrDefault();

                    if (legend != null)
                    {
                        var headerText = new FilteredElementCollector(doc)
                            .OfClass(typeof(TextNoteType)).Cast<TextNoteType>()
                            .SingleOrDefault(x => x.Name == "headerText");

                        var normalText = new FilteredElementCollector(doc)
                            .OfClass(typeof(TextNoteType)).Cast<TextNoteType>()
                            .SingleOrDefault(x => x.Name == "normalText");


                        var cpvcText = new FilteredElementCollector(doc)
                            .OfClass(typeof(TextNoteType)).Cast<TextNoteType>()
                            .SingleOrDefault(x => x.Name == "Schedule Default Table");


                        AddTextNote(doc, legend, headerText, new XYZ(26.345963420, 8.139522479, 0.000000000), "PEX PIPE SIZING TABLE");
                        AddTextNote(doc, legend, cpvcText, new XYZ(6.500365801, 2.579696715, 0.000000000)
                            , $"UPONOR PEX PIPE FOR INSIDE THE APT. UNIT ONLY;  UPONOR AQUAPEX PIPING WITH PROPEX ENGINEERED \r\nPOLYMER (EP) COLD EXPANSION TYPE FITTINGS (LA CITY RR-5482)                                                             {PsiPerFt} PSI\r\n PER 100 FT., 8 FPS MAX. VELOCITY");


                        AddTextNote(doc, legend, normalText, new XYZ(2.488033697, -6.019398902, 0.000000000), "PIPE SIZE");
                        AddTextNote(doc, legend, normalText, new XYZ(11.889772260, -6.019398902, 0.000000000), "1/2\"");
                        AddTextNote(doc, legend, normalText, new XYZ(18.639772260, -6.019398902, 0.000000000), "3/4\"");
                        AddTextNote(doc, legend, normalText, new XYZ(26.180682326, -6.019398902, 0.000000000), "1\"");
                        AddTextNote(doc, legend, normalText, new XYZ(32.220597641, -6.019398902, 0.000000000), "1 1/4\"");
                        AddTextNote(doc, legend, normalText, new XYZ(39.303930974, -6.019398902, 0.000000000), "1 1/2\"");
                        AddTextNote(doc, legend, normalText, new XYZ(47.243008051, -6.019398902, 0.000000000), "2\"");
                        AddTextNote(doc, legend, normalText, new XYZ(54.684813277, -6.019398902, 0.000000000), "-");
                        AddTextNote(doc, legend, normalText, new XYZ(61.101479943, -6.019398902, 0.000000000), "-");
                        AddTextNote(doc, legend, normalText, new XYZ(68.101479943, -6.019398902, 0.000000000), "-");
                        AddTextNote(doc, legend, normalText, new XYZ(75.351479943, -6.019398902, 0.000000000), "-");
                        AddTextNote(doc, legend, normalText, new XYZ(82.518146610, -6.019398902, 0.000000000), "-");

                        AddTextNote(doc, legend, normalText, new XYZ(11.889772260, -11.519398902, 0.000000000), "0.5");
                        AddTextNote(doc, legend, normalText, new XYZ(18.556438926, -11.519398902, 0.000000000), "0.75");
                        AddTextNote(doc, legend, normalText, new XYZ(26.473105593, -11.519398902, 0.000000000), "1");
                        AddTextNote(doc, legend, normalText, new XYZ(32.639772260, -11.519398902, 0.000000000), "1.25");
                        AddTextNote(doc, legend, normalText, new XYZ(39.973105593, -11.519398902, 0.000000000), "1.5");
                        AddTextNote(doc, legend, normalText, new XYZ(47.306438926, -11.519398902, 0.000000000), "2");
                        AddTextNote(doc, legend, normalText, new XYZ(53.909674718, -11.519398902, 0.000000000), "2.5");
                        AddTextNote(doc, legend, normalText, new XYZ(61.400829188, -11.105490576, 0.000000000), "3");
                        AddTextNote(doc, legend, normalText, new XYZ(68.409674718, -11.519398902, 0.000000000), "4");
                        AddTextNote(doc, legend, normalText, new XYZ(75.909674718, -11.519398902, 0.000000000), "6");
                        AddTextNote(doc, legend, normalText, new XYZ(82.409674718, -11.519398902, 0.000000000), "8");

                        AddTextNote(doc, legend, normalText, new XYZ(4.037808935, -16.519398902, 0.000000000), "GPM");
                        AddTextNote(doc, legend, normalText, new XYZ(4.787808935, -20.436065569, 0.000000000), "FT");
                        AddTextNote(doc, legend, normalText, new XYZ(4.787808935, -22.788163418, 0.000000000), "FU");
                        AddTextNote(doc, legend, normalText, new XYZ(4.787808935, -25.436065569, 0.000000000), "FV");
                        AddTextNote(doc, legend, normalText, new XYZ(4.787808935, -27.788163418, 0.000000000), "FU");
                        AddTextNote(doc, legend, normalText, new XYZ(4.454475602, -31.621496751, 0.000000000), "VEL");


                        //GPM COLD
                        AddTextNote(doc, legend, normalText, new XYZ(12.397872014, -16.752521443, 0.000000000), $"{ConvertNumberToString(MaxGpm[0])}");
                        AddTextNote(doc, legend, normalText, new XYZ(19.556438926, -16.752521443, 0.000000000), $"{ConvertNumberToString(MaxGpm[1])}");
                        AddTextNote(doc, legend, normalText, new XYZ(26.473105593, -16.752521443, 0.000000000), $"{ConvertNumberToString(MaxGpm[2])}");
                        AddTextNote(doc, legend, normalText, new XYZ(33.223105593, -16.752521443, 0.000000000), $"{ConvertNumberToString(MaxGpm[3])}");
                        AddTextNote(doc, legend, normalText, new XYZ(40.473105593, -16.752521443, 0.000000000), $"{ConvertNumberToString(MaxGpm[4])}");
                        AddTextNote(doc, legend, normalText, new XYZ(47.139772260, -16.752521443, 0.000000000), $"{ConvertNumberToString(MaxGpm[5])}");
                        AddTextNote(doc, legend, normalText, new XYZ(54.601479943, -16.752521443, 0.000000000), "-");
                        AddTextNote(doc, legend, normalText, new XYZ(61.409674718, -16.752521443, 0.000000000), "-");
                        AddTextNote(doc, legend, normalText, new XYZ(68.558127264, -16.752521443, 0.000000000), "-");
                        AddTextNote(doc, legend, normalText, new XYZ(74.568797957, -16.752521443, 0.000000000), "   -");
                        AddTextNote(doc, legend, normalText, new XYZ(81.485464623, -16.752521443, 0.000000000), "   -");


                        //FT FU COLD
                        AddTextNote(doc, legend, normalText, new XYZ(12.397872014, -21.519398902, 0.000000000), $"{ConvertNumberToString(FlushTank[0])}");
                        AddTextNote(doc, legend, normalText, new XYZ(19.556438926, -21.519398902, 0.000000000), $"{ConvertNumberToString(FlushTank[1])}");
                        AddTextNote(doc, legend, normalText, new XYZ(26.176286226, -21.505661122, 0.000000000), $"{ConvertNumberToString(FlushTank[2])}");
                        AddTextNote(doc, legend, normalText, new XYZ(33.223105593, -21.519398902, 0.000000000), $"{ConvertNumberToString(FlushTank[3])}");
                        AddTextNote(doc, legend, normalText, new XYZ(40.473105593, -21.519398902, 0.000000000), $"{ConvertNumberToString(FlushTank[4])}");
                        AddTextNote(doc, legend, normalText, new XYZ(46.806438926, -21.519398902, 0.000000000), $"{ConvertNumberToString(FlushTank[5])}");
                        AddTextNote(doc, legend, normalText, new XYZ(54.703027397, -21.752521443, 0.000000000), "-");
                        AddTextNote(doc, legend, normalText, new XYZ(61.511222172, -21.752521443, 0.000000000), "-");
                        AddTextNote(doc, legend, normalText, new XYZ(68.409674718, -21.752521443, 0.000000000), "-");
                        AddTextNote(doc, legend, normalText, new XYZ(75.351479943, -21.519398902, 0.000000000), "-");
                        AddTextNote(doc, legend, normalText, new XYZ(82.601479943, -21.519398902, 0.000000000), "-");



                        //Fv Fu COLD
                        AddTextNote(doc, legend, normalText, new XYZ(12.397872014, -26.519398902, 0.000000000), $"{ConvertNumberToString(FlushValve[0])}");
                        AddTextNote(doc, legend, normalText, new XYZ(19.556438926, -26.519398902, 0.000000000), $"{ConvertNumberToString(FlushValve[1])}");
                        AddTextNote(doc, legend, normalText, new XYZ(26.556438926, -26.519398902, 0.000000000), $"{ConvertNumberToString(FlushValve[2])}");
                        AddTextNote(doc, legend, normalText, new XYZ(33.473105593, -26.519398902, 0.000000000), $"{ConvertNumberToString(FlushValve[3])}");
                        AddTextNote(doc, legend, normalText, new XYZ(40.630902995, -26.519398902, 0.000000000), $"{ConvertNumberToString(FlushValve[4])}");
                        AddTextNote(doc, legend, normalText, new XYZ(46.973105593, -26.519398902, 0.000000000), $"{ConvertNumberToString(FlushValve[5])}");
                        AddTextNote(doc, legend, normalText, new XYZ(54.851479943, -26.519398902, 0.000000000), "-");
                        AddTextNote(doc, legend, normalText, new XYZ(61.659674718, -26.519398902, 0.000000000), "-");
                        AddTextNote(doc, legend, normalText, new XYZ(68.601479943, -26.519398902, 0.000000000), "-");
                        AddTextNote(doc, legend, normalText, new XYZ(75.518146610, -26.519398902, 0.000000000), "-");
                        AddTextNote(doc, legend, normalText, new XYZ(82.601479943, -26.519398902, 0.000000000), "-");


                        //VEL COLD
                        AddTextNote(doc, legend, normalText, new XYZ(12.397872014, -31.519398902, 0.000000000), $"{Velocity[0]}");
                        AddTextNote(doc, legend, normalText, new XYZ(18.608068948, -31.621496751, 0.000000000), $"{Velocity[1]}");
                        AddTextNote(doc, legend, normalText, new XYZ(25.671964611, -31.621496751, 0.000000000), $"{Velocity[2]}");
                        AddTextNote(doc, legend, normalText, new XYZ(32.671964611, -31.621496751, 0.000000000), $"{Velocity[3]}");
                        AddTextNote(doc, legend, normalText, new XYZ(39.537368035, -31.621496751, 0.000000000), $"{Velocity[4]}");
                        AddTextNote(doc, legend, normalText, new XYZ(46.755297944, -31.621496751, 0.000000000), $"{Velocity[5]}");
                        AddTextNote(doc, legend, normalText, new XYZ(54.851479943, -31.519398902, 0.000000000), "-");
                        AddTextNote(doc, legend, normalText, new XYZ(61.659674718, -31.519398902, 0.000000000), "-");
                        AddTextNote(doc, legend, normalText, new XYZ(68.409674718, -31.621496751, 0.000000000), "-");
                        AddTextNote(doc, legend, normalText, new XYZ(75.601479943, -31.621496751, 0.000000000), "-");
                        AddTextNote(doc, legend, normalText, new XYZ(82.601479943, -31.621496751, 0.000000000), "-");

                        tx.Commit();

                    }
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

        public string GetName()
        {
            return "CreatePexHandler";
        }


        private void AddTextNote(Document doc, View legend, TextNoteType textNoteType, XYZ position, string text, string name = "")
        {
            TextNote textNote = TextNote.Create(doc, legend.Id, position, text, textNoteType.Id);
        }

        private double ConvertToTwoDecimal(double val) => Math.Round(val, 2);


        public string ConvertNumberToString(double number)
        {
            return number != 0 ? number.ToString() : "-";
        }

    }
}
