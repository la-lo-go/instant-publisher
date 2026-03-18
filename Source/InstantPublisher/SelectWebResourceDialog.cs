using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;

namespace Lalogo.InstantPublisher
{
    public partial class SelectWebResourceDialog : Form
    {
        private List<Entity> _resources = new List<Entity>();
        private CancellationTokenSource _filterCts;

        public static IOrganizationService Service { get; set; }
        

        public Guid WebResourceId { get; set; }


        public string WebResourceName { get; set; }

        
        public SelectWebResourceDialog(int typeCode)
        {
            InitializeComponent();
            InitializeTreeIcons();
            SelectionHintLabel.Text = "Loading web resources from CRM...";
            SetBusyState(true, "Loading web resources from CRM...");
            Shown += SelectWebResourceDialog_Shown;

            var map = new Dictionary<int, CheckBox> { { 1, HtmlFilterBox }, { 2, StylesFilterBox }, { 9, StylesFilterBox }, { 3, ScriptsFilterBox }, { 4, XmlFilterBox }, { 5, ImagesFilterBox }, { 6, ImagesFilterBox }, { 7, ImagesFilterBox }, { 10, ImagesFilterBox }, { 8, OtherFilterBox } };
            if (typeCode != 0)
            {
                HtmlFilterBox.Checked = ScriptsFilterBox.Checked = StylesFilterBox.Checked = ImagesFilterBox.Checked = XmlFilterBox.Checked = OtherFilterBox.Checked = false;
                map[typeCode].Checked = true;
            }

        }

        private async void SelectWebResourceDialog_Shown(object sender, EventArgs e)
        {
            await LoadResourcesFromCrmAsync();
        }

        private void InitializeTreeIcons()
        {
            IconsList.Images.Clear();
            IconsList.ColorDepth = ColorDepth.Depth32Bit;
            IconsList.ImageSize = new Size(16, 16);

            var iconNames = new[]
            {
                "ico.root.16.png",
                "ico.folder.16.png",
                "ico.html.16.png",
                "ico.image.16.png",
                "ico.xml.16.png",
                "ico.style.16.png",
                "ico.script.16.png",
                "ico.other.16.png"
            };

            var assembly = Assembly.GetExecutingAssembly();
            foreach (var iconName in iconNames)
            {
                var resourceName = "Lalogo.InstantPublisher.Assets.Icons." + iconName;
                using (var stream = assembly.GetManifestResourceStream(resourceName))
                {
                    if (stream == null)
                    {
                        IconsList.Images.Add(iconName, SystemIcons.Application.ToBitmap());
                        continue;
                    }

                    using (var image = Image.FromStream(stream))
                    {
                        IconsList.Images.Add(iconName, new Bitmap(image));
                    }
                }
            }
        }

        private async Task LoadResourcesFromCrmAsync()
        {
            var fetchXml = @"
<fetch no-lock='true'>
  <entity name='webresource'>
    <attribute name='name' />
    <attribute name='webresourcetype' />
    <attribute name='displayname' />
    <attribute name='ismanaged' />
    <filter>
      <condition attribute='name' operator='not-begin-with' value='msdyn_'/>
      <condition attribute='ismanaged' operator='eq' value='0'/>
    </filter>
  </entity>
</fetch>";

            SetBusyState(true, "Loading web resources from CRM...");
            await Task.Yield();

            try
            {
                _resources = await Task.Run(() =>
                    Service.RetrieveMultiple(new FetchExpression(fetchXml))
                        .Entities
                        .OrderBy(r => r.GetAttributeValue<string>("name"))
                        .ToList());

                await ApplyResourceFiltersAsync("Building list...");
            }
            catch (Exception ex)
            {
                SetBusyState(false, "Failed to load web resources");
                MessageBox.Show(this,
                    "Failed to load web resources from CRM:\n" + ex.Message,
                    "Select Web Resource",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void SetBusyState(bool isBusy, string message)
        {
            UseWaitCursor = isBusy;
            FilterFlowPanel.Enabled = !isBusy;
            SearchTextBox.Enabled = !isBusy;
            WebResourceTree.Enabled = !isBusy;
            if (!isBusy)
                SelectButton.Enabled = WebResourceTree.SelectedNode is WebResourceTreeNode;

            SelectionHintLabel.Text = message;
            SelectionHintLabel.ForeColor = isBusy
                ? Color.FromArgb(74, 144, 217)
                : Color.FromArgb(80, 80, 80);
            SelectionHintLabel.Refresh();
        }


        public static (Guid Id, string Name)? FindByFileName(string localFilePath)
        {
            if (Service == null)
                return null;

            var fileNameWithoutExt = Path.GetFileNameWithoutExtension(localFilePath);
            if (string.IsNullOrWhiteSpace(fileNameWithoutExt))
                return null;

            var escapedName = SecurityElement.Escape(fileNameWithoutExt);

            var fetchXml = $@"
<fetch no-lock='true'>
  <entity name='webresource'>
    <attribute name='name' />
    <attribute name='webresourcetype' />
    <filter>
      <condition attribute='name' operator='not-begin-with' value='msdyn_'/>
      <condition attribute='ismanaged' operator='eq' value='0'/>
      <condition attribute='name' operator='like' value='%{escapedName}%'/>
    </filter>
  </entity>
</fetch>";

            var results = Service.RetrieveMultiple(new FetchExpression(fetchXml)).Entities;

            var match = results.FirstOrDefault(r =>
            {
                var name = r.GetAttributeValue<string>("name");
                var lastSegment = name.Split('/').Last();
                var segmentWithoutExt = Path.GetFileNameWithoutExtension(lastSegment);
                return string.Equals(segmentWithoutExt, fileNameWithoutExt, StringComparison.OrdinalIgnoreCase);
            });

            if (match == null)
                return null;

            return (match.Id, match.GetAttributeValue<string>("name"));
        }


        private void BuildTree(IEnumerable<Entity> resources)
        {
            WebResourceTree.Nodes.Clear();

            foreach (var resource in resources)
            {
                var name = resource.GetAttributeValue<string>("name");
                var type = resource.GetAttributeValue<OptionSetValue>("webresourcetype").Value;
                var pathParts = name.Split('/');
                var path = string.Empty;
                TreeNode lastNode = null;
                var lastPathPart = pathParts.Last();
                foreach (var pathPart in pathParts)
                {
                    path += pathPart + "\\";
                    var nodes = WebResourceTree.Nodes.Find(path, true);
                    if (nodes.Length == 0)
                    {
                        var isLast = pathPart == lastPathPart;
                        var collection = lastNode == null ? WebResourceTree.Nodes : lastNode.Nodes;
                        TreeNode node;
                        if (isLast)
                        {
                            switch (type)
                            {
                                case 1:
                                    node = new HtmlTreeNode(name, resource.Id, pathPart);
                                    break;
                                case 2:
                                case 9:
                                    node = new StyleTreeNode(name, resource.Id, pathPart);
                                    break;
                                case 3:
                                    node = new ScriptTreeNode(name, resource.Id, pathPart);
                                    break;
                                case 4:
                                    node = new XmlTreeNode(name, resource.Id, pathPart);
                                    break;
                                case 5:
                                case 6:
                                case 7:
                                case 10:
                                    node = new ImageTreeNode(name, resource.Id, pathPart);
                                    break;
                                default:
                                    node = new OtherTreeNode(name, resource.Id, pathPart);
                                    break;
                            }
                        }
                        else
                            node = new TreeNode(pathPart) { Name = path };

                        collection.Add(node);
                        lastNode = node;
                    }
                    else
                        lastNode = nodes[0];
                }
            }
        }


        private void SelectWebResource(object sender, object e)
        {
            if (!(WebResourceTree.SelectedNode is WebResourceTreeNode wrNode))
                return;
            WebResourceId = wrNode.Id;
            WebResourceName = wrNode.Name;
        }

        private void WebResourceTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            SelectButton.Enabled = e.Node is WebResourceTreeNode;
        }


        private void WebResourceTree_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            SelectButton.PerformClick();
        }

        private void FilterBox_CheckedChanged(object sender, EventArgs e)
        {
            _ = ApplyResourceFiltersAsync("Filtering web resources...");
        }

        private void SearchTextBox_TextChanged(object sender, EventArgs e)
        {
            _ = ApplyResourceFiltersAsync("Filtering web resources...");
        }

        private async Task ApplyResourceFiltersAsync(string busyMessage)
        {
            if (_resources == null || _resources.Count == 0)
            {
                BuildTree(Enumerable.Empty<Entity>());
                SetBusyState(false, "No web resources found");
                return;
            }

            _filterCts?.Cancel();
            _filterCts = new CancellationTokenSource();
            var token = _filterCts.Token;

            var types = new List<int>();
            if (HtmlFilterBox.Checked)
                types.Add(1);
            if (StylesFilterBox.Checked)
                types.AddRange(new[] { 2, 9 });
            if (ScriptsFilterBox.Checked)
                types.Add(3);
            if (XmlFilterBox.Checked)
                types.Add(4);
            if (ImagesFilterBox.Checked)
                types.AddRange(new[] { 5, 6, 7, 10 });
            if (OtherFilterBox.Checked)
                types.Add(8);

            var searchText = (SearchTextBox?.Text ?? string.Empty).Trim();
            SetBusyState(true, busyMessage);
            await Task.Yield();

            List<Entity> filtered;
            try
            {
                filtered = await Task.Run(() =>
                {
                    IEnumerable<Entity> resources = _resources.Where(r =>
                        types.Contains(r.GetAttributeValue<OptionSetValue>("webresourcetype").Value));

                    if (searchText.Length > 0)
                    {
                        resources = resources.Where(r =>
                        {
                            var name = r.GetAttributeValue<string>("name") ?? string.Empty;
                            return name.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0;
                        });
                    }

                    return resources.ToList();
                }, token);
            }
            catch (OperationCanceledException)
            {
                return;
            }

            if (token.IsCancellationRequested)
                return;

            BuildTree(filtered);

            if (filtered.Count == 0)
                SetBusyState(false, "No web resources match current filters");
            else
                SetBusyState(false, "Showing " + filtered.Count + " web resource(s)");
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _filterCts?.Cancel();
            _filterCts?.Dispose();
            base.OnFormClosed(e);
        }
    }

    public class RootTreeNode : TreeNode
    {
        public RootTreeNode(string key, string text) : base(text)
        {
            Name = key;
            ImageIndex = SelectedImageIndex = 0;
        }
    }


    public abstract class WebResourceTreeNode : TreeNode
    {
        public Guid Id { get; set; }


        protected WebResourceTreeNode(string key, Guid id, string text) : base(text)
        {
            Id = id;
            Name = key;
        }

    }


    public class HtmlTreeNode : WebResourceTreeNode
    {
        public HtmlTreeNode(string key, Guid id, string text) : base(key, id, text)
        {
            ImageIndex = SelectedImageIndex = 2;
        }
    }
    public class ImageTreeNode : WebResourceTreeNode
    {
        public ImageTreeNode(string key, Guid id, string text) : base(key, id, text)
        {
            ImageIndex = SelectedImageIndex = 3;
        }
    }
    public class StyleTreeNode : WebResourceTreeNode
    {
        public StyleTreeNode(string key, Guid id, string text) : base(key, id, text)
        {
            ImageIndex = SelectedImageIndex = 5;
        }
    }
    public class ScriptTreeNode : WebResourceTreeNode
    {
        public ScriptTreeNode(string key, Guid id, string text) : base(key, id, text)
        {
            ImageIndex = SelectedImageIndex = 6;
        }
    }
    public class XmlTreeNode : WebResourceTreeNode
    {
        public XmlTreeNode(string key, Guid id, string text) : base(key, id, text)
        {
            ImageIndex = SelectedImageIndex = 4;
        }
    }

    public class OtherTreeNode : WebResourceTreeNode
    {
        public OtherTreeNode(string key, Guid id, string text) : base(key, id, text)
        {
            ImageIndex = SelectedImageIndex = 7;
        }
    }
}
