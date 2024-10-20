using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI.Selection;
using Autodesk.Revit.DB.Events;
using Autodesk.Revit.DB.Plumbing;
using K2dPlugin.Features.CopyElementFromLink.Handlers;
using K2dPlugin.Features.PipeSum;
using Point = Autodesk.Revit.DB.Point;
using System.Windows.Controls.Primitives;
using System.Windows.Controls;
using System.Windows.Documents;
using K2dPlugin.Features.CopyElementFromLink.Dto;

namespace K2dPlugin.Features.CopyElementFromLink.CopyElementForm
{
    public partial class CopyElementFromLinkForm : System.Windows.Forms.Form
    {
        public Document Document;
        public Document LinkedDocument;
        public List<Document> DocumentList = new List<Document>();
        private UIApplication UiApplication;
        private UIDocument UiDocument;
        private List<ElementId> ElementIds = new List<ElementId>();
        private ExternalEvent copyElementEvent;
        private ExternalEvent addIsPrivateEvent;
        private CopyElementHandler copyElementHandler;
        private AddIsPrivateHandler addIsPrivateHandler;



        public CopyElementFromLinkForm(ExternalCommandData commandData,Document document, UIApplication uiApp)
        {
            InitializeComponent();
            this.TopMost = true;
            this.Document = document;
            this.UiApplication = uiApp;
            this.UiDocument = commandData.Application.ActiveUIDocument;

            var linkedProjects = GetLinkedProjects(Document);
            
            //populate dropdown of revit project
            foreach (var link in linkedProjects)
            {
                LinkProjectComboBox.Items.Add(link.Name.Split(':')[0]);
            }

 
            copyElementHandler = new CopyElementHandler();
            copyElementEvent = ExternalEvent.Create(copyElementHandler);

            addIsPrivateHandler = new AddIsPrivateHandler();
            addIsPrivateEvent = ExternalEvent.Create(addIsPrivateHandler);
        }

        private void PopulateGridView(IEnumerable<FamilyInstance> instances)
        {
            LinkGridView.Rows.Clear();

            foreach (var family in instances)
            {
                LinkGridView.Rows.Add(null,family.Name);
            }
        }
        private List<FamilyInstance> GetPlumbingFixtureTypes(RevitLinkInstance link)
        {
            Document linkedDoc = link.GetLinkDocument();
                
            if (linkedDoc == null) return new List<FamilyInstance>();

            return GetPlumbingFixtureTypesByDocument(linkedDoc);

        }

        private List<FamilyInstance> GetPlumbingFixtureTypesByDocument(Document doc)
        {
            FilteredElementCollector collector = new FilteredElementCollector(doc);

            var plumbingFixtures = collector
                .OfClass(typeof(FamilyInstance))
                .OfCategory(BuiltInCategory.OST_PlumbingFixtures)
                .WhereElementIsNotElementType()
                .Cast<FamilyInstance>()
                .Where(instance => instance.Document.Equals(doc))
                .ToList();

            var groupedByElementId = plumbingFixtures
                .GroupBy(fixture => fixture.Symbol.Family.Name)
                .Select(group => group.First());

            return groupedByElementId.ToList();
        }

        private List<RevitLinkInstance> GetLinkedProjects(Document document)
        {
            var linkedProjects = new List<RevitLinkInstance>();
            var collector = new FilteredElementCollector(document);
            var linkedInstance = collector.OfClass(typeof(RevitLinkInstance)).ToElements();


            foreach (var element in linkedInstance)
            {
                RevitLinkType type = Document.GetElement(element.GetTypeId()) as RevitLinkType;

                if (type.GetParentId() != ElementId.InvalidElementId) continue;


                var instance = element as RevitLinkInstance;

                linkedProjects.Add(instance);
            }

            return linkedProjects;
        }

        private List<Document> GetChildLinkedProjects(Document document, string parentName)
        {
            var linkedProjects = new List<RevitLinkInstance>();
            var collector = new FilteredElementCollector(document);
            List<Document> linkedInstance = collector.OfClass(typeof(RevitLinkInstance)).Cast<RevitLinkInstance>()
                .Select(linkInstance => this.LinkedDocument.GetElement(linkInstance.GetTypeId()) as RevitLinkType)
                .Select(type =>
                {
                    ModelPath modelPath = type.GetExternalFileReference().GetAbsolutePath();
                    string filePath = ModelPathUtils.ConvertModelPathToUserVisiblePath(modelPath);
                    var shit = type.GetChildIds();

                    Document linkedDoc = UiApplication.Application.OpenDocumentFile(filePath);
                    var projLoc = type.Location;
                    DocumentList.Add(linkedDoc);


                    return linkedDoc;

                })
                .Distinct()
                .ToList();

            return linkedInstance;
        }

        private void eventLog1_EntryWritten(object sender, System.Diagnostics.EntryWrittenEventArgs e)
        {

        }

        private void HighlightProjectRow(string projectName)
        {
            foreach (DataGridViewRow row in LinkGridView.Rows)
            {
                if (row.Cells[1].Value != null && row.Cells[1].Value.ToString() == projectName)
                {
                    LinkGridView.ClearSelection();
                    LinkGridView.CurrentCell = row.Cells[0];
                    row.Selected = true;
                    break;
                }
            }
        }

        private void SelectElementBtn_Click(object sender, EventArgs e)
        {
            ElementIds = new List<ElementId>();

            var selection = UiDocument.Selection;
            var selectedElement = selection.PickObject(ObjectType.LinkedElement, "Select Linked Element");
            var linkedProject = Document.GetElement(selectedElement) as RevitLinkInstance;
            var linkedDocument = linkedProject.GetLinkDocument();
            LinkedDocument = linkedDocument;

            var categoryName = linkedDocument.GetElement(selectedElement.LinkedElementId).Category.Id.IntegerValue;
            var elementName = linkedDocument.GetElement(selectedElement.LinkedElementId).Name;

            var projectName = linkedProject.Name.Split(':')[0];
            HighlightProjectRow(projectName);


            var builtInCategory = (BuiltInCategory)categoryName;

            var elementToCopy = new FilteredElementCollector(linkedDocument)
                .OfCategory(builtInCategory)
                .WhereElementIsNotElementType()
                .Where(x => x.Name == elementName);

            foreach (var element in elementToCopy)
            {
                var data = element.Location;

                ElementIds.Add(element.Id);
            }

            this.Show();
        }

        private void CopyElementBtn_Click(object sender, EventArgs e)
        {
            var names = new List<string>();


            foreach (DataGridViewRow row in LinkGridView.Rows)
            {
                if(row == null) continue;

                var objValue = row.Cells[0].Value != null 
                    ? row.Cells[0].Value.ToString() 
                    : string.Empty;

                var isSelected = bool.TryParse(objValue, out var isSel);

                if (isSel)
                {
                    var name = row.Cells[1].Value.ToString();
                    names.Add(name);
                }
            }

            //get element from selected project

            //get the correct Linked doc
            //group element by link
            //var elementToCopyFromOtherDocs = GetElementFromNestedDocumentByNames(names, DocumentList);
            var elementFromLinkToCopy = GetElementFromDocumentByNames(names, LinkedDocument);
            var elementsFromCurrentDoc = GetElementFromDocumentByNames(names, Document);

            if(elementFromLinkToCopy == null) return;

            var docLocationAsPoints = GetPointsByLocations(elementsFromCurrentDoc);

            ElementIds = new List<ElementId>();

            foreach (var element in elementFromLinkToCopy)
            {
                var name = element.Name;
                if (element.Location == null) continue;

                var locPoint = element.Location as LocationPoint;


                if (locPoint == null) continue;

                var point = locPoint.Point;

                if (!IsOccupied(docLocationAsPoints, point))
                {
                    ElementIds.Add(element.Id);
                }
            }

            if(ElementIds.Count == 0) return;

            copyElementHandler.Document = Document;
            copyElementHandler.LinkedDocument = LinkedDocument;
            copyElementHandler.ElementIds = ElementIds;
            copyElementEvent.Raise();
        }

        private List<CopyDto> GetElementFromNestedDocumentByNames(List<string> names, List<Document> documentList)
        {
            var elements = new List<CopyDto>();

            foreach (var dc in documentList)
            {
                var elementFromLinkToCopy = GetElementFromDocumentByNames(names, dc);

                if (elementFromLinkToCopy == null) continue;

                var dto = new CopyDto()
                {
                    Elements = elementFromLinkToCopy,
                    Doc = dc,
                };

                elements.Add(dto);
            }

            return elements;
        }

        private bool IsOccupied(IEnumerable<XYZ> docPoints, XYZ point)
        {
            foreach (var pt in docPoints)
            {
                if(pt.X == point.X & pt.Y == point.Y & pt.Z == point.Z) return true;
            }

            return false;
        }

        private IEnumerable<XYZ> GetPointsByLocations(IEnumerable<Element> elements)
        {
            var locationAsPoint = elements
                .Select(x => x.Location)
                .OfType<LocationPoint>()
                .Select(lp => lp.Point)
                .ToList();

            return locationAsPoint;
        }

        private IEnumerable<Element> GetElementFromDocumentByNames(IEnumerable<string> names, Document doc)
        {
            var elements = new FilteredElementCollector(doc)
                .WhereElementIsNotElementType()
                .Where(x => names.Contains(x.Name));

            return elements;
        }

        private void LinkProjectComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DocumentList.Clear();
            var test = new List<FamilyInstance>();
            var selected = LinkProjectComboBox.SelectedItem;
            var linkedProjects = GetLinkedProjects(Document);
            

            var selectedLink = linkedProjects
                .FirstOrDefault(x => x.Name.Split(':')[0].Equals(selected.ToString()));


            this.LinkedDocument = selectedLink.GetLinkDocument();

            var childLink = GetChildLinkedProjects(LinkedDocument, selectedLink.Name.ToString());

            var linkElements = GetPlumbingFixtureTypes(selectedLink);
            test.AddRange(linkElements);

            foreach (var linkElement in childLink)
            {
                var linkName = linkElement.PathName;

                if (linkElement != null)
                {
                    IEnumerable<FamilyInstance> ChildLinkElements = GetPlumbingFixtureTypesByDocument(linkElement);

                    if (ChildLinkElements != null)
                    {
                        foreach (var family in ChildLinkElements)
                        {
                            var names = test.Select(x => x.Name.Split(':')[0].ToString()).ToList();
                            if (!names.Contains(family.Name.Split(':')[0].ToString()))
                            {
                                test.Add(family);
                            }
                        }

                    };
                }
            }

            PopulateGridView(test);
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void SelectAllCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            var  selectAll = SelectAllCheckBox.Checked;

            foreach (DataGridViewRow row in LinkGridView.Rows)
            {
                var checkBoxCell = row.Cells[0] as DataGridViewCheckBoxCell;

                if (checkBoxCell != null)
                {
                    checkBoxCell.Value = selectAll;
                }
            }
        }

        private void AddPropertyBtn_Click(object sender, EventArgs e)
        {

            if (Document.IsFamilyDocument)
            {
                addIsPrivateHandler.Document = Document;
                addIsPrivateEvent.Raise();
            }

        }

        //private void SelectElement_Click(object sender, EventArgs e)
        //{
        //    ElementIds = new List<ElementId>();

        //    var selection = UiDocument.Selection;
        //    this.Hide();
        //    var selectedElement = selection.PickObject(ObjectType.LinkedElement, "Select Linked Element");
        //    var linkedProject = Document.GetElement(selectedElement) as RevitLinkInstance;

        //    var linkedDocument = linkedProject.GetLinkDocument();
        //    var elem = linkedDocument.GetElement(selectedElement.LinkedElementId);

        //    var docName = linkedProject.Name.Split(':')[0].ToString();
        //    var shitLink = GetChildLinkedProjects(linkedDocument, docName);
        //    LinkedDocument = linkedDocument;

        //    var categoryName = linkedDocument.GetElement(selectedElement.LinkedElementId).Category.Id.IntegerValue;
        //    var elementName = linkedDocument.GetElement(selectedElement.LinkedElementId).Name;

        //    var projectName = linkedProject.Name.Split(':')[0];
        //    HighlightProjectRow(projectName);


        //    var builtInCategory = (BuiltInCategory)categoryName;

        //    //var elementToCopy = new FilteredElementCollector(linkedDocument)
        //    //    .OfCategory(builtInCategory)
        //    //    .WhereElementIsNotElementType()
        //    //    .Where(x => x.Name == elementName);

        //    //foreach (var element in elementToCopy)
        //    //{
        //    //    var global = selectedElement.GlobalPoint;
        //    //    var location = element.Location;
        //    //    if (location != null)
        //    //    {
        //    //        element.Location;
        //    //        //var transform = linkedProject.GetTotalTransform();
        //    //        //var globalPoint = transform.OfPoint(location.Point);
        //    //        // Use the globalPoint as needed, for example:
        //    //        // Do something with globalPoint


        //    //        ElementIds.Add(element.Id);
        //    //    }
        //    //}
        //    //copyElementHandler.Location = selectedElement.GlobalPoint;
        //    ElementIds.Add(elem.Id);


        //    this.Show();
        //}

        //private void CopySelected_Click(object sender, EventArgs e)
        //{
        //    copyElementHandler.Document = Document;
        //    copyElementHandler.LinkedDocument = LinkedDocument;
        //    copyElementHandler.ElementIds = ElementIds;

        //    copyElementEvent.Raise();
        //}
    }

}