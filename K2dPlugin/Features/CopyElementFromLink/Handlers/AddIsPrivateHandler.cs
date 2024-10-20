using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.ExtensibleStorage;
using Autodesk.Revit.UI;

namespace K2dPlugin.Features.CopyElementFromLink.Handlers
{
    internal class AddIsPrivateHandler : IExternalEventHandler
    {
        public Document Document { get; set; }
        public IEnumerable<ElementId> ElementIds { get; set; }

        private static readonly List<string> PlumbingFixtures = new List<string>()
        {
            "BATHTUB/SHOWER",
            "SHOWER",
            "CLOTH WASHER",
            "KITCHEN SINK",
            "DISHWASHER",
            "LAVATORY",
            "W.C (GRAVITY TANK)",
            "W.C (FLUSH VALVE)",
            "LANDRY SINK",
            "BIDET",
            "URINAL",
            "SAUNA/STEAM SHOWER",
            "OTHER SINK",
            "BAR SINK",
            "REF",
            "ICE MAKER",
            "SERVICE SINK",
            "HOSE BIBB",
            "HOSE BIBB (EACH ADDITIONAL)",
            "Is Private"
        };
        public void Execute(UIApplication app)
        {
            try
            {
                using (Transaction trans = new Transaction(Document, "Add Parameter to Family Type"))
                {
                    trans.Start();

                    // Get the family type by name
                    FamilyManager familyManager = Document.FamilyManager;
                    FamilyType familyType = familyManager.Types.Cast<FamilyType>().FirstOrDefault();


                    if (familyType != null)
                    {
                        foreach (var fixtureName in PlumbingFixtures)
                        {
                            FamilyParameter fixtureParam = familyManager.get_Parameter(fixtureName);
                             
                            if (fixtureParam != null)  continue;

                            fixtureParam = familyManager.AddParameter(fixtureName, BuiltInParameterGroup.PG_IDENTITY_DATA, ParameterType.YesNo, fixtureName == "Is Private");
                            familyManager.Set(fixtureParam, 0);
                        }

                        string textNoteParameterName = "TextNote";
                        FamilyParameter textNoteParam = familyManager.get_Parameter(textNoteParameterName);

                        if (textNoteParam == null)
                        {
                            textNoteParam = familyManager.AddParameter(textNoteParameterName, BuiltInParameterGroup.PG_TEXT, ParameterType.Text, true);
                            familyManager.Set(textNoteParam, string.Empty);
                        }
                    }


                    //if (familyType != null)
                    //{
                    //    // Set the current type
                    //    familyManager.CurrentType = familyType;
                    //    var isPrivatePropertyName = "Is Private";
                    //    var plumbingFixturePropertyName = "Plumbing Fixture";

                    //    FamilyParameter isPrivateParam = familyManager.get_Parameter(isPrivatePropertyName);
                    //    FamilyParameter plumbingFixtureProp = familyManager.get_Parameter(plumbingFixturePropertyName);

                    //    if (isPrivateParam == null)// Check if the parameter already exists
                    //    {
                    //        isPrivateParam = familyManager.AddParameter(isPrivatePropertyName, BuiltInParameterGroup.PG_IDENTITY_DATA, ParameterType.YesNo, true);
                    //    }

                    //    if (plumbingFixtureProp == null)
                    //    {
                    //        plumbingFixtureProp = familyManager.AddParameter(plumbingFixturePropertyName, BuiltInParameterGroup.PG_IDENTITY_DATA, ParameterType.Text, false);

                    //    }


                    //    familyManager.Set(plumbingFixtureProp, string.Empty);
                    //    familyManager.Set(isPrivateParam, 1);
                    //}

                    trans.Commit();
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
            return "AddIsPrivateHandler";
        }
    }
}
