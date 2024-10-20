using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using K2dPlugin.Features.GenerateReport.Dto;

namespace K2dPlugin.Features.GenerateReport.Handlers
{
    internal class CreateWaterDemandLegendHandler : IExternalEventHandler
    {
        public WaterDemandTotalDto WaterDemandTotalDto { get; set; }
        public Dictionary<string, WaterDemandDto> WaterDemandDictionary { get; set; }
        public void Execute(UIApplication app)
        {
            UIDocument uiDoc = app.ActiveUIDocument;
            Document doc = uiDoc.Document;

            using (Transaction tx = new Transaction(doc))
            {
                try
                {
                    tx.Start("Create Water Demand Legend");

                    List<View> legendViews = new List<View>();

                    FilteredElementCollector collector = new FilteredElementCollector(doc);
                    ICollection<Element> views = collector.OfClass(typeof(View)).ToElements();

                    foreach (Element e in views)
                    {
                        View view = e as View;

                        if (view != null && view.ViewType == ViewType.Legend && view.Name == "Water Demand")
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


                        AddTextNote(doc, legend, headerText, new XYZ(27.723741057, 102.425922044, 0.000000000), "WATER DEMAND");

                        AddTextNote(doc, legend, normalText, new XYZ(13.571868688, 95.993418156, 0.000000000), "FIXTURE");
                        AddTextNote(doc, legend, normalText, new XYZ(34.031400011, 97.117881684, 0.000000000), "FIXTURE UNIT");
                        AddTextNote(doc, legend, normalText, new XYZ(30.673759572, 94.117881684, 0.000000000), "PRIVATE");
                        AddTextNote(doc, legend, normalText, new XYZ(41.144068360, 94.117881684, 0.000000000), "PUBLIC");
                        AddTextNote(doc, legend, normalText, new XYZ(55.006459253, 97.117881684, 0.000000000), "QUANTITY");
                        AddTextNote(doc, legend, normalText, new XYZ(50.923759572, 94.117881684, 0.000000000), "PRIVATE");
                        AddTextNote(doc, legend, normalText, new XYZ(61.394068360, 94.117881684, 0.000000000), "PUBLIC");
                        AddTextNote(doc, legend, normalText, new XYZ(69.933368942, 95.766967671, 0.000000000), "TOTAL (FU)");

                        var bathTubShower = WaterDemandDictionary["BathTubShower"];
                        AddTextNote(doc, legend, normalText, new XYZ(2.772582080, 91.118018447, 0.000000000), "BATH TUB/SHOWER");
                        AddTextNote(doc, legend, normalText, new XYZ(33.280054108, 91.117881684, 0.000000000), "4");
                        AddTextNote(doc, legend, normalText, new XYZ(43.780054108, 91.117881684, 0.000000000), "4");
                        AddTextNote(doc, legend, normalText, new XYZ(53.780054108, 91.117881684, 0.000000000), $"{bathTubShower.Private}");//VAL
                        AddTextNote(doc, legend, normalText, new XYZ(64.280054108, 91.117881684, 0.000000000), $"{bathTubShower.Public}");//VAL
                        AddTextNote(doc, legend, normalText, new XYZ(73.280054108, 91.117881684, 0.000000000), $"{bathTubShower.Total}");//VAL

                        var shower = WaterDemandDictionary["Shower"];
                        AddTextNote(doc, legend, normalText, new XYZ(2.772582080, 88.117881684, 0.000000000), "SHOWER");
                        AddTextNote(doc, legend, normalText, new XYZ(33.280054108, 88.117881684, 0.000000000), "4");
                        AddTextNote(doc, legend, normalText, new XYZ(43.780054108, 88.117881684, 0.000000000), "4");
                        AddTextNote(doc, legend, normalText, new XYZ(53.780054108, 88.117881684, 0.000000000), $"{shower.Private}");//VAL
                        AddTextNote(doc, legend, normalText, new XYZ(64.280054108, 88.117881684, 0.000000000), $"{shower.Public}");//VAL
                        AddTextNote(doc, legend, normalText, new XYZ(73.280054108, 88.117881684, 0.000000000), $"{shower.Total}");//VAL

                        var clothWasher = WaterDemandDictionary["ClothWasher"];
                        AddTextNote(doc, legend, normalText, new XYZ(2.772582080, 85.117881684, 0.000000000), "CLOTHES WASHER");
                        AddTextNote(doc, legend, normalText, new XYZ(33.280054108, 85.117881684, 0.000000000), "4");
                        AddTextNote(doc, legend, normalText, new XYZ(43.780054108, 85.117881684, 0.000000000), "4");
                        AddTextNote(doc, legend, normalText, new XYZ(53.780054108, 85.117881684, 0.000000000), $"{clothWasher.Private}");//VAL
                        AddTextNote(doc, legend, normalText, new XYZ(64.280054108, 85.117881684, 0.000000000), $"{clothWasher.Public}");//VAL
                        AddTextNote(doc, legend, normalText, new XYZ(73.280054108, 85.117881684, 0.000000000), $"{clothWasher.Total}");//VAL

                        var kitchenSink = WaterDemandDictionary["KitchenSink"];
                        AddTextNote(doc, legend, normalText, new XYZ(2.772582080, 82.117881684, 0.000000000), "KITCHEN SINK");
                        AddTextNote(doc, legend, normalText, new XYZ(32.683986709, 82.117881684, 0.000000000), "1.5");
                        AddTextNote(doc, legend, normalText, new XYZ(43.183986709, 82.117881684, 0.000000000), "1.5");
                        AddTextNote(doc, legend, normalText, new XYZ(53.780054108, 82.117881684, 0.000000000), $"{kitchenSink.Private}");//VAL
                        AddTextNote(doc, legend, normalText, new XYZ(64.280054108, 82.117881684, 0.000000000), $"{kitchenSink.Public}");//VAL
                        AddTextNote(doc, legend, normalText, new XYZ(73.280054108, 82.117881684, 0.000000000), $"{kitchenSink.Total}");//VAL

                        var dishwasher = WaterDemandDictionary["Dishwasher"];
                        AddTextNote(doc, legend, normalText, new XYZ(2.772582080, 79.117881684, 0.000000000), "DISHWASHER");
                        AddTextNote(doc, legend, normalText, new XYZ(32.683986709, 79.117881684, 0.000000000), "1.5");
                        AddTextNote(doc, legend, normalText, new XYZ(43.183986709, 79.117881684, 0.000000000), "1.5");
                        AddTextNote(doc, legend, normalText, new XYZ(53.780054108, 79.117881684, 0.000000000), $"{dishwasher.Private}");//VAL
                        AddTextNote(doc, legend, normalText, new XYZ(64.280054108, 79.117881684, 0.000000000), $"{dishwasher.Public}");//VAL
                        AddTextNote(doc, legend, normalText, new XYZ(73.280054108, 79.117881684, 0.000000000), $"{dishwasher.Total}");//VAL

                        var lavatory = WaterDemandDictionary["Lavatory"];   
                        AddTextNote(doc, legend, normalText, new XYZ(2.772582080, 76.117881684, 0.000000000), "LAVATORY");
                        AddTextNote(doc, legend, normalText, new XYZ(33.183986709, 76.117881684, 0.000000000), "1");
                        AddTextNote(doc, legend, normalText, new XYZ(43.933986709, 76.117881684, 0.000000000), "1");
                        AddTextNote(doc, legend, normalText, new XYZ(53.780054108, 76.117881684, 0.000000000), $"{lavatory.Private}");//VAL
                        AddTextNote(doc, legend, normalText, new XYZ(64.280054108, 76.117881684, 0.000000000), $"{lavatory.Public}");//VAL
                        AddTextNote(doc, legend, normalText, new XYZ(73.280054108, 76.117881684, 0.000000000), $"{lavatory.Total}");//VAL

                        var gravityTank = WaterDemandDictionary["GravityTank"];
                        AddTextNote(doc, legend, normalText, new XYZ(2.772582080, 73.117881684, 0.000000000), "W.C. (GRAVITY TANK)");
                        AddTextNote(doc, legend, normalText, new XYZ(33.030054108, 73.117881684, 0.000000000), "2.5");
                        AddTextNote(doc, legend, normalText, new XYZ(43.530054108, 73.117881684, 0.000000000), "2.5");
                        AddTextNote(doc, legend, normalText, new XYZ(53.780054108, 73.117881684, 0.000000000), $"{gravityTank.Private}");//VAL
                        AddTextNote(doc, legend, normalText, new XYZ(64.280054108, 73.117881684, 0.000000000), $"{gravityTank.Public}");//VAL
                        AddTextNote(doc, legend, normalText, new XYZ(73.280054108, 73.117881684, 0.000000000), $"{gravityTank.Total}");//VAL

                        var flushValve = WaterDemandDictionary["FlushValve"];
                        AddTextNote(doc, legend, normalText, new XYZ(2.772582080, 70.117881684, 0.000000000), "W.C. (FLASH VALVE)");
                        AddTextNote(doc, legend, normalText, new XYZ(33.280054108, 70.117881684, 0.000000000), "5");
                        AddTextNote(doc, legend, normalText, new XYZ(44.030054108, 70.117881684, 0.000000000), "5");
                        AddTextNote(doc, legend, normalText, new XYZ(53.780054108, 70.117881684, 0.000000000), $"{flushValve.Private}");//VAL
                        AddTextNote(doc, legend, normalText, new XYZ(64.280054108, 70.117881684, 0.000000000), $"{flushValve.Public}");//VAL
                        AddTextNote(doc, legend, normalText, new XYZ(73.280054108, 70.117881684, 0.000000000), $"{flushValve.Total}");//VAL

                        var laundrySink = WaterDemandDictionary["LaundrySink"];
                        AddTextNote(doc, legend, normalText, new XYZ(2.772582080, 67.117881684, 0.000000000), "LAUNDRY SINK");
                        AddTextNote(doc, legend, normalText, new XYZ(32.683986709, 67.117881684, 0.000000000), "1.5");
                        AddTextNote(doc, legend, normalText, new XYZ(43.183986709, 67.117881684, 0.000000000), "1.5");
                        AddTextNote(doc, legend, normalText, new XYZ(53.780054108, 67.117881684, 0.000000000), $"{laundrySink.Private}");//VAL
                        AddTextNote(doc, legend, normalText, new XYZ(64.280054108, 67.117881684, 0.000000000), $"{laundrySink.Public}");//VAL
                        AddTextNote(doc, legend, normalText, new XYZ(73.280054108, 67.117881684, 0.000000000), $"{laundrySink.Total}");//VAL

                        var bidet = WaterDemandDictionary["Bidet"];
                        AddTextNote(doc, legend, normalText, new XYZ(2.772582080, 64.117881684, 0.000000000), "BIDET");
                        AddTextNote(doc, legend, normalText, new XYZ(33.280054108, 64.117881684, 0.000000000), "1");
                        AddTextNote(doc, legend, normalText, new XYZ(44.030054108, 64.117881684, 0.000000000), "1");
                        AddTextNote(doc, legend, normalText, new XYZ(53.780054108, 64.117881684, 0.000000000), $"{bidet.Private}");//VAL
                        AddTextNote(doc, legend, normalText, new XYZ(64.280054108, 64.117881684, 0.000000000), $"{bidet.Public}");//VAL
                        AddTextNote(doc, legend, normalText, new XYZ(73.280054108, 64.117881684, 0.000000000), $"{bidet.Total}");//VAL

                        var urinal = WaterDemandDictionary["Urinal"];
                        AddTextNote(doc, legend, normalText, new XYZ(2.772582080, 61.117881684, 0.000000000), "URINAL");
                        AddTextNote(doc, legend, normalText, new XYZ(33.183986709, 61.117881684, 0.000000000), "3");
                        AddTextNote(doc, legend, normalText, new XYZ(43.933986709, 61.117881684, 0.000000000), "4");
                        AddTextNote(doc, legend, normalText, new XYZ(53.780054108, 61.117881684, 0.000000000), $"{urinal.Private}");//VAL
                        AddTextNote(doc, legend, normalText, new XYZ(64.280054108, 61.117881684, 0.000000000), $"{urinal.Public}");//VAL
                        AddTextNote(doc, legend, normalText, new XYZ(73.280054108, 61.117881684, 0.000000000), $"{urinal.Total}");//VAL

                        var saunaSteamShower = WaterDemandDictionary["SaunaSteamShower"];
                        AddTextNote(doc, legend, normalText, new XYZ(2.772582080, 58.117881684, 0.000000000), "SAUNA/STEAM SHOWER");
                        AddTextNote(doc, legend, normalText, new XYZ(33.280054108, 58.117881684, 0.000000000), "2");
                        AddTextNote(doc, legend, normalText, new XYZ(44.030054108, 58.117881684, 0.000000000), "2");
                        AddTextNote(doc, legend, normalText, new XYZ(53.780054108, 58.034548351, 0.000000000), $"{saunaSteamShower.Private}");//VAL
                        AddTextNote(doc, legend, normalText, new XYZ(64.280054108, 58.034548351, 0.000000000), $"{saunaSteamShower.Public}");//VAL
                        AddTextNote(doc, legend, normalText, new XYZ(73.280054108, 58.034548351, 0.000000000), $"{saunaSteamShower.Total}");//VAL

                        var otherSink = WaterDemandDictionary["OtherSink"];
                        AddTextNote(doc, legend, normalText, new XYZ(2.772582080, 55.117881684, 0.000000000), "OTHER SINK");
                        AddTextNote(doc, legend, normalText, new XYZ(33.183986709, 55.117881684, 0.000000000), "2");
                        AddTextNote(doc, legend, normalText, new XYZ(43.933986709, 55.117881684, 0.000000000), "2");
                        AddTextNote(doc, legend, normalText, new XYZ(53.780054108, 55.034548351, 0.000000000), $"{otherSink.Private}");//VAL
                        AddTextNote(doc, legend, normalText, new XYZ(64.280054108, 55.034548351, 0.000000000), $"{otherSink.Public}");//VAL
                        AddTextNote(doc, legend, normalText, new XYZ(73.280054108, 55.034548351, 0.000000000), $"{otherSink.Total}");//VAL

                        var barSink = WaterDemandDictionary["BarSink"];
                        AddTextNote(doc, legend, normalText, new XYZ(2.772582080, 52.117881684, 0.000000000), "BAR SINK");
                        AddTextNote(doc, legend, normalText, new XYZ(33.280054108, 52.117881684, 0.000000000), "2");
                        AddTextNote(doc, legend, normalText, new XYZ(44.030054108, 52.117881684, 0.000000000), "2");
                        AddTextNote(doc, legend, normalText, new XYZ(53.780054108, 52.034548351, 0.000000000), $"{barSink.Private}");//VAL
                        AddTextNote(doc, legend, normalText, new XYZ(64.280054108, 52.034548351, 0.000000000), $"{barSink.Public}");//VAL
                        AddTextNote(doc, legend, normalText, new XYZ(73.280054108, 52.034548351, 0.000000000), $"{barSink.Public}");//VAL

                        var refs = WaterDemandDictionary["Ref"];
                        AddTextNote(doc, legend, normalText, new XYZ(2.772582080, 49.117881684, 0.000000000), "REF");
                        AddTextNote(doc, legend, normalText, new XYZ(32.696720775, 49.117881684, 0.000000000), "0.5");
                        AddTextNote(doc, legend, normalText, new XYZ(43.446720775, 49.117881684, 0.000000000), "0.5");
                        AddTextNote(doc, legend, normalText, new XYZ(53.780054108, 49.117881684, 0.000000000), $"{refs.Private}");//VAL
                        AddTextNote(doc, legend, normalText, new XYZ(64.280054108, 49.117881684, 0.000000000), $"{refs.Public}");//VAL
                        AddTextNote(doc, legend, normalText, new XYZ(73.280054108, 49.117881684, 0.000000000), $"{refs.Total}");//VAL

                        var iceMaker = WaterDemandDictionary["IceMaker"];
                        AddTextNote(doc, legend, normalText, new XYZ(2.772582080, 46.117881684, 0.000000000), "ICE MAKER");
                        AddTextNote(doc, legend, normalText, new XYZ(32.683986709, 46.117881684, 0.000000000), "0.5");
                        AddTextNote(doc, legend, normalText, new XYZ(43.433986709, 46.117881684, 0.000000000), "0.5");
                        AddTextNote(doc, legend, normalText, new XYZ(53.780054108, 46.117881684, 0.000000000), $"{iceMaker.Private}");//VAL
                        AddTextNote(doc, legend, normalText, new XYZ(64.280054108, 46.117881684, 0.000000000), $"{iceMaker.Public}");//VAL
                        AddTextNote(doc, legend, normalText, new XYZ(73.280054108, 46.117881684, 0.000000000), $"{iceMaker.Total}");//VAL 

                        var serviceSink = WaterDemandDictionary["ServiceSink"];
                        AddTextNote(doc, legend, normalText, new XYZ(2.772582080, 43.117881684, 0.000000000), "SERVICE SINK");
                        AddTextNote(doc, legend, normalText, new XYZ(33.183986709, 43.117881684, 0.000000000), "3");
                        AddTextNote(doc, legend, normalText, new XYZ(43.933986709, 43.117881684, 0.000000000), "3");
                        AddTextNote(doc, legend, normalText, new XYZ(53.780054108, 43.117881684, 0.000000000), $"{serviceSink.Private}");//VAL
                        AddTextNote(doc, legend, normalText, new XYZ(64.280054108, 43.117881684, 0.000000000), $"{serviceSink.Public}");//VAL
                        AddTextNote(doc, legend, normalText, new XYZ(73.280054108, 43.117881684, 0.000000000), $"{serviceSink.Total}");//VAL

                        var hoseBibb = WaterDemandDictionary["HoseBibb"];
                        AddTextNote(doc, legend, normalText, new XYZ(2.772582080, 40.117881684, 0.000000000), "HOSE BIBB");
                        AddTextNote(doc, legend, normalText, new XYZ(32.696720775, 40.117881684, 0.000000000), "2.5");
                        AddTextNote(doc, legend, normalText, new XYZ(43.446720775, 40.117881684, 0.000000000), "2.5");
                        AddTextNote(doc, legend, normalText, new XYZ(53.780054108, 40.117881684, 0.000000000), $"{hoseBibb.Private}");//VAL
                        AddTextNote(doc, legend, normalText, new XYZ(64.280054108, 40.117881684, 0.000000000), $"{hoseBibb.Public}");//VAL
                        AddTextNote(doc, legend, normalText, new XYZ(73.280054108, 40.117881684, 0.000000000), $"{hoseBibb.Total}");//VAL

                        var hoseBibbAdd = WaterDemandDictionary["HoseBibbAdd"];
                        AddTextNote(doc, legend, normalText, new XYZ(2.772582080, 37.117881684, 0.000000000), "HOSE BIBB (EACH ADDITIONAL)");
                        AddTextNote(doc, legend, normalText, new XYZ(33.363387442, 37.117881684, 0.000000000), "1");
                        AddTextNote(doc, legend, normalText, new XYZ(43.933986709, 37.117881684, 0.000000000), "1");
                        AddTextNote(doc, legend, normalText, new XYZ(53.780054108, 37.117881684, 0.000000000), $"{hoseBibbAdd.Private}");//VAL
                        AddTextNote(doc, legend, normalText, new XYZ(64.280054108, 37.117881684, 0.000000000), $"{hoseBibbAdd.Public}");//VAL
                        AddTextNote(doc, legend, normalText, new XYZ(73.280054108, 37.117881684, 0.000000000), $"{hoseBibbAdd.Total}");//VAL

                        AddTextNote(doc, legend, normalText, new XYZ(62.299758881, 34.117881684, 0.000000000), "TOTAL");
                        AddTextNote(doc, legend, normalText, new XYZ(72.190879643, 34.117881684, 0.000000000), $"{WaterDemandTotalDto.FixtureUnitTotal}");

                        AddTextNote(doc, legend, normalText, new XYZ(26.613065298, 31.117881684, 0.000000000), "FIXTURE UNIT TOTAL");
                        AddTextNote(doc, legend, normalText, new XYZ(48.299758881, 31.117881684, 0.000000000), "FU =");
                        AddTextNote(doc, legend, normalText, new XYZ(56.299758881, 31.117881684, 0.000000000), $"{WaterDemandTotalDto.FixtureUnitTotal}");//VAL
                        AddTextNote(doc, legend, normalText, new XYZ(62.299758881, 31.117881684, 0.000000000), "GPM =");
                        AddTextNote(doc, legend, normalText, new XYZ(72.190879643, 31.117881684, 0.000000000), $"{WaterDemandTotalDto.FixtureUnitTotalGpm}");//VAL

                        AddTextNote(doc, legend, normalText, new XYZ(26.613065298, 28.117881684, 0.000000000), "OTHER WATER REQUIRED");

                        var otherWaterRequiredFu = WaterDemandTotalDto.OtherWaterRequiredFu != 0 ? WaterDemandTotalDto.OtherWaterRequiredFu.ToString() : "-";
                        AddTextNote(doc, legend, normalText, new XYZ(48.299758881, 28.117881684, 0.000000000), "FU =");
                        AddTextNote(doc, legend, normalText, new XYZ(56.633092215, 28.117881684, 0.000000000), $"{otherWaterRequiredFu}");//VAL

                        var otherWaterRequiredGpm = WaterDemandTotalDto.OtherWaterRequiredGpm != 0 ? WaterDemandTotalDto.OtherWaterRequiredGpm.ToString() : "-";
                        AddTextNote(doc, legend, normalText, new XYZ(62.299758881, 28.117881684, 0.000000000), "GPM =");
                        AddTextNote(doc, legend, normalText, new XYZ(72.774212976, 28.117881684, 0.000000000), $"{otherWaterRequiredGpm}");//VAL

                        AddTextNote(doc, legend, normalText, new XYZ(26.613065298, 25.117881684, 0.000000000), "EXIST WATER REQUIRED");

                        var existWaterRequiredFu = WaterDemandTotalDto.ExistWaterRequiredFu != 0  ?  WaterDemandTotalDto.ExistWaterRequiredFu.ToString() : "-";
                        AddTextNote(doc, legend, normalText, new XYZ(48.299758881, 25.117881684, 0.000000000), "FU =");
                        AddTextNote(doc, legend, normalText, new XYZ(56.633092215, 25.098087543, 0.000000000), $"{existWaterRequiredFu}");//VAL

                        var existWaterRequiredGpm = WaterDemandTotalDto.ExistWaterRequiredGpm != 0 ? WaterDemandTotalDto.ExistWaterRequiredGpm.ToString() : "-";
                        AddTextNote(doc, legend, normalText, new XYZ(62.299758881, 25.117881684, 0.000000000), "GPM =");

                        AddTextNote(doc, legend, normalText, new XYZ(72.799758881, 25.117881684, 0.000000000), $"{existWaterRequiredGpm}");//VAL

                        var totalFu = WaterDemandTotalDto.OtherWaterRequiredFu +
                                      WaterDemandTotalDto.FixtureUnitTotalGpm +
                                      WaterDemandTotalDto.ExistWaterRequiredGpm;
                        var totalGpm = WaterDemandTotalDto.FixtureUnitTotalGpm +
                                       WaterDemandTotalDto.ExistWaterRequiredGpm +
                                       WaterDemandTotalDto.OtherWaterRequiredGpm;
                        AddTextNote(doc, legend, normalText, new XYZ(26.613065298, 22.117881684, 0.000000000), "TOTAL WATER REQUIRED");
                        AddTextNote(doc, legend, normalText, new XYZ(48.299758881, 22.117881684, 0.000000000), "FU =");
                        AddTextNote(doc, legend, normalText, new XYZ(56.299758881, 22.117881684, 0.000000000), $"{totalFu}");//VAL
                        AddTextNote(doc, legend, normalText, new XYZ(62.299758881, 22.117881684, 0.000000000), "GPM =");
                        AddTextNote(doc, legend, normalText, new XYZ(72.190879643, 22.117881684, 0.000000000), $"{totalGpm}");//VAL
                    }

                    tx.Commit();

                    TaskDialog.Show("Legend Created", "Water Demand Legend view created successfully.");

                }
                catch (Exception ex)    
                {
                    if (tx.HasStarted()) tx.RollBack();

                    TaskDialog.Show("Error", ex.Message);
                }
            }
        }

        public string GetName()
        {
            return "CreateWaterDemandLegendHandler";
        }

        private void AddTextNote(Document doc, View legend, TextNoteType textNoteType, XYZ position, string text, string name = "")
        {
            TextNote textNote = TextNote.Create(doc, legend.Id, position, text, textNoteType.Id);
        }

        private double ConvertToTwoDecimal(double val) => Math.Round(val, 2);
    }
}
