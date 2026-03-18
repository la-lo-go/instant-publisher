using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using McTools.Xrm.Connection;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Newtonsoft.Json;
using XrmToolBox.Extensibility;
using XrmToolBox.Extensibility.Interfaces;

namespace Lalogo.InstantPublisher
{
    public partial class MainControl : PluginControlBase, IGitHubPlugin //, IPayPalPlugin
    {
        // ReSharper disable once InconsistentNaming
        private static readonly Dictionary<string, int> _extensionTypeCodeMap = new Dictionary<string, int> { { ".htm", 1 }, { ".html", 1 }, { ".css", 2 }, { ".js", 3 }, { ".xml", 4 }, { ".png", 5 }, { ".jpg", 6 }, { ".jpeg", 6 }, { ".gif", 7 }, { ".xap", 8 }, { ".xsl", 9 } };

        private readonly WatchersManager _watchers = new WatchersManager();
        private readonly Dictionary<string, WebResourceInfo> _webResources = new Dictionary<string, WebResourceInfo>();
        private readonly Dictionary<string, PluginInfo> _plugins = new Dictionary<string, PluginInfo>();
        private readonly Color _publishButtonColor = Color.FromArgb(74, 144, 217);
        private readonly Color _publishButtonHoverColor = Color.FromArgb(60, 120, 190);
        private readonly Color _deleteButtonColor = Color.FromArgb(192, 57, 43);
        private readonly Color _deleteButtonHoverColor = Color.FromArgb(170, 45, 35);
        private readonly Color _statusModifiedColor = Color.FromArgb(39, 174, 96);
        private readonly Color _statusPublishingColor = Color.FromArgb(74, 144, 217);
        private DataGridView _hoveredButtonGrid;
        private int _hoveredButtonRowIndex = -1;
        private int _hoveredButtonColumnIndex = -1;
        private string _currentConnectionKey;
        private Timer _publishingAnimTimer;
        private int _publishingDotCount;
        private Timer _notificationTimer;
        private Timer _relativeTimeTimer;
        private readonly Color _notificationSuccessColor = Color.FromArgb(39, 174, 96);
        private readonly Color _notificationErrorColor = Color.FromArgb(192, 57, 43);

        private const string WebResourceFileFilter = "All Web Resources files (*.htm, *.html, *.js, *.css, *.xml)|*.htm;*.html;*.js;*.css;*.xml|HTML files (*.htm, *.html)|*.htm;*.html|JavaScript files (*.js)|*.js|Style files (*.css)|*.css|XML files (*.xml)|*.xml";


        public MainControl()
        {
            try
            {
                InitializeComponent();
                _watchers.Changed += OnFileChanged;
                ConfigureGridInteractions(WebResourcesGrid);
                ConfigureGridInteractions(PluginsGrid);

                _publishingAnimTimer = new Timer { Interval = 400 };
                _publishingAnimTimer.Tick += PublishingAnimTimer_Tick;

                _notificationTimer = new Timer { Interval = 5000 };
                _notificationTimer.Tick += (s, ev) =>
                {
                    _notificationTimer.Stop();
                    StatusNotificationLabel.Text = "";
                };

                _relativeTimeTimer = new Timer { Interval = 60000 };
                _relativeTimeTimer.Tick += RelativeTimeTimer_Tick;
                _relativeTimeTimer.Start();

                SyncAddToSolutionButton();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error initializing plugin:\n\n{ex}", "InstantPublisher Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }


        // ReSharper disable UnusedMember.Global
        public string DonationDescription => "Donation for MSCRM Tools - Lalogo InstantPublisher";
        public string EmailAccount => "roman@kopaev.ru";
        // ReSharper restore UnusedMember.Global


        public string RepositoryName => "instant-publisher";
        public string UserName => "la-lo-go";


        #region File Change Detection

        private void OnFileChanged(object sender, FileSystemEventArgs e)
        {
            if (_webResources.ContainsKey(e.FullPath))
            {
                var webResourceInfo = _webResources[e.FullPath];
                var lastWriteTime = File.GetLastWriteTime(e.FullPath);
                if (lastWriteTime == webResourceInfo.LastPublish)
                    return;
                webResourceInfo.IsDirty = true;
                UpdateWebResourceGridRow(e.FullPath);
                if (webResourceInfo.IsAuto == false)
                    return;
                webResourceInfo.LastPublish = lastWriteTime;
                PublishWebResource(webResourceInfo);
                return;
            }

            if (_plugins.ContainsKey(e.FullPath))
            {
                var pluginInfo = _plugins[e.FullPath];
                pluginInfo.IsDirty = true;
                UpdatePluginGridRow(e.FullPath);
            }
        }

        #endregion


        #region Web Resource Publishing

        private void PublishWebResource(WebResourceInfo webResourceInfo)
        {
            Task.Run(() =>
            {
                webResourceInfo.IsBusy = true;
                var oldDirtyState = webResourceInfo.IsDirty;
                webResourceInfo.IsDirty = false;
                UpdateWebResourceGridRow(webResourceInfo.FileName);
                var success = false;
                try
                {
                    var bytes = File.ReadAllBytes(webResourceInfo.FileName);
                    var file = Convert.ToBase64String(bytes);
                    Service.Update(new Entity("webresource", webResourceInfo.WebResourceId) { ["content"] = file });
                    PublishWebResource(Service, webResourceInfo.WebResourceId);
                    webResourceInfo.IsDirty = false;
                    webResourceInfo.LastPublish = DateTime.Now;
                    success = true;
                }
                catch
                {
                    webResourceInfo.IsDirty = oldDirtyState;
                }
                finally
                {
                    webResourceInfo.IsBusy = false;
                    UpdateWebResourceGridRow(webResourceInfo.FileName);
                    var fileName = Path.GetFileName(webResourceInfo.FileName);
                    if (success)
                        ShowNotification($"Published {fileName}", false);
                    else
                        ShowNotification($"Failed: {fileName}", true);
                }
            });
        }


        /// <summary>
        /// Публикация одного веб-ресурса.
        /// </summary>
        public void PublishWebResource(IOrganizationService service, Guid resourceId)
        {
            service.Execute(new OrganizationRequest
            {
                RequestName = "PublishXml",
                Parameters = new ParameterCollection
                {
                    new KeyValuePair<string, object>("ParameterXml", $"<importexportxml><webresources><webresource>{resourceId}</webresource></webresources></importexportxml>")
                }
            });
        }

        #endregion


        #region Plugin Publishing

        private void PublishPlugin(IOrganizationService service, PluginInfo pluginInfo)
        {
            Task.Run(() =>
            {
                pluginInfo.IsBusy = true;
                var oldDirtyState = pluginInfo.IsDirty;
                pluginInfo.IsDirty = false;
                UpdatePluginGridRow(pluginInfo.FileName);
                var success = false;
                try
                {
                    if (pluginInfo.PluginAssemblyId == null)
                    {
                        var assemblyNameInfo = AssemblyName.GetAssemblyName(pluginInfo.FileName);
                        var assemblyName = assemblyNameInfo.Name;
                        var assemblyVersion = $"{assemblyNameInfo.Version.Major}.{assemblyNameInfo.Version.Minor}";
                        var assemblyPublicKeyToken = GetPublicKeyToken(assemblyNameInfo);

                        var query = new QueryExpression("pluginassembly")
                        {
                            ColumnSet = new ColumnSet("pluginassemblyid"),
                            Criteria = new FilterExpression(LogicalOperator.And)
                            {
                                Conditions =
                                {
                                    new ConditionExpression("name", ConditionOperator.Equal, assemblyName),
                                    new ConditionExpression("publickeytoken", ConditionOperator.Equal, assemblyPublicKeyToken),
                                    new ConditionExpression("version", ConditionOperator.BeginsWith, assemblyVersion),
                                }
                            }
                        };
                        var entity = service.RetrieveMultiple(query).Entities.FirstOrDefault();
                        if (entity == null)
                            throw new InvalidOperationException($"No matching assembly found for {Path.GetFileName(pluginInfo.FileName)}");
                        pluginInfo.PluginAssemblyId = entity.Id;
                    }

                    var bytes = File.ReadAllBytes(pluginInfo.FileName);
                    service.Update(new Entity("pluginassembly", pluginInfo.PluginAssemblyId.Value)
                    {
                        ["content"] = Convert.ToBase64String(bytes)
                    });

                    pluginInfo.IsDirty = false;
                    pluginInfo.LastPublish = DateTime.Now;
                    success = true;
                }
                catch
                {
                    pluginInfo.IsDirty = oldDirtyState;
                }
                finally
                {
                    pluginInfo.IsBusy = false;
                    UpdatePluginGridRow(pluginInfo.FileName);
                    var fileName = Path.GetFileName(pluginInfo.FileName);
                    if (success)
                        ShowNotification($"Published {fileName}", false);
                    else
                        ShowNotification($"Failed: {fileName}", true);
                }
            });
        }


        private static string GetPublicKeyToken(AssemblyName assemblyNameInfo)
        {
            var publicKeyTokenString = "";
            var token = assemblyNameInfo.GetPublicKeyToken();
            for (var i = 0; i < token.GetLength(0); i++)
                publicKeyTokenString += token[i].ToString("x2");
            return publicKeyTokenString;
        }

        #endregion


        #region Connection and Settings

        public override void UpdateConnection(IOrganizationService newService, ConnectionDetail detail, string actionName, object parameter)
        {
            SaveSettings();
            RemoveAllMonitoredItems();

            _currentConnectionKey = GetConnectionKey(detail);

            try
            {
                MonitoredCollection collection;
                if (SettingsManager.Instance.TryLoad<MonitoredCollection>(typeof(InstantPublisher), out collection, _currentConnectionKey))
                {
                    foreach (var wr in collection.WebResources)
                        AddWebResourceToUI(wr.FilePath, wr.WebResourceId, wr.WebResourceName, wr.IsAuto, wr.LastSolutionId);
                    foreach (var p in collection.Plugins)
                        AddPluginToUI(p.FilePath, p.IsAuto);
                }
            }
            catch
            {
                // Settings from a previous version may be incompatible
            }

            ExportButton.Enabled = true;
            ImportButton.Enabled = true;
            SyncPublishAllButton();
            SyncAddToSolutionButton();

            SelectWebResourceDialog.Service = newService;
            base.UpdateConnection(newService, detail, actionName, parameter);
        }

        private static string GetConnectionKey(ConnectionDetail detail)
        {
            if (detail == null)
                return null;

            var detailType = detail.GetType();
            var connectedOrgUniqueName = detailType.GetProperty("ConnectedOrgUniqueName")?.GetValue(detail) as string;
            if (!string.IsNullOrWhiteSpace(connectedOrgUniqueName))
                return connectedOrgUniqueName;

            var organizationUniqueName = detailType.GetProperty("OrganizationUniqueName")?.GetValue(detail) as string;
            if (!string.IsNullOrWhiteSpace(organizationUniqueName))
                return organizationUniqueName;

            var connectionName = detailType.GetProperty("ConnectionName")?.GetValue(detail) as string;
            if (!string.IsNullOrWhiteSpace(connectionName))
                return connectionName;

            return detailType.GetProperty("ConnectionId")?.GetValue(detail)?.ToString();
        }


        private void CloseButton_Click(object sender, EventArgs e)
        {
            SaveSettings();
            CloseTool();
        }


        private void SaveSettings()
        {
            if (_currentConnectionKey == null) return;

            var collection = new MonitoredCollection();
            foreach (var kvp in _webResources)
            {
                collection.WebResources.Add(new MonitoredWebResource
                {
                    FilePath = kvp.Key,
                    WebResourceId = kvp.Value.WebResourceId,
                    WebResourceName = kvp.Value.WebResourceName,
                    LastSolutionId = kvp.Value.LastSolutionId,
                    IsAuto = kvp.Value.IsAuto
                });
            }
            foreach (var kvp in _plugins)
            {
                collection.Plugins.Add(new MonitoredPlugin
                {
                    FilePath = kvp.Key,
                    IsAuto = kvp.Value.IsAuto
                });
            }
            SettingsManager.Instance.Save(typeof(InstantPublisher), collection, _currentConnectionKey);
        }


        private void RemoveAllMonitoredItems()
        {
            WebResourcesGrid.Rows.Clear();
            _webResources.Clear();

            PluginsGrid.Rows.Clear();
            _plugins.Clear();

            SyncAddToSolutionButton();
        }

        #endregion


        #region Add Web Resources

        private static string TruncatePath(string fullPath, int levels = 4)
        {
            var parts = fullPath.Replace('/', '\\').Split('\\');
            if (parts.Length <= levels)
                return fullPath;
            return @"...\" + string.Join(@"\", parts, parts.Length - levels, levels);
        }

        private static string ResolveWebResourceType(string fullFileName, string webResourceName)
        {
            var extension = Path.GetExtension(webResourceName);
            if (string.IsNullOrWhiteSpace(extension))
                extension = Path.GetExtension(fullFileName);

            if (string.IsNullOrWhiteSpace(extension))
                return "Other";

            int typeCode;
            if (!_extensionTypeCodeMap.TryGetValue(extension.ToLowerInvariant(), out typeCode))
                return "Other";

            switch (typeCode)
            {
                case 1:
                    return "HTML";
                case 2:
                case 9:
                    return "Style";
                case 3:
                    return "Script";
                case 4:
                    return "XML";
                case 5:
                case 6:
                case 7:
                case 10:
                    return "Image";
                case 8:
                    return "Silverlight";
                default:
                    return "Other";
            }
        }

        private void AddWebResourceToUI(string fullFileName, Guid webResourceId, string webResourceName, bool isAuto, Guid? lastSolutionId = null)
        {
            if (_webResources.ContainsKey(fullFileName))
                return;

            var webResourceInfo = new WebResourceInfo
            {
                FileName = fullFileName,
                WebResourceName = webResourceName,
                WebResourceId = webResourceId,
                LastSolutionId = lastSolutionId,
                IsAuto = isAuto
            };

            WebResourcesGrid.Rows.Insert(0);
            var row = WebResourcesGrid.Rows[0];
            row.Tag = fullFileName;
            row.Cells["ColWrFileName"].Value = TruncatePath(fullFileName);
            row.Cells["ColWrFileName"].ToolTipText = fullFileName;
            row.Cells["ColWrWebResource"].Value = webResourceName;
            row.Cells["ColWrType"].Value = ResolveWebResourceType(fullFileName, webResourceName);
            row.Cells["ColWrAuto"].Value = isAuto;
            row.Cells["ColWrStatus"].Value = "";
            row.Cells["ColWrLastPublished"].Value = "";

            var directoryName = Path.GetDirectoryName(fullFileName);
            _watchers.Add(directoryName);
            _webResources.Add(fullFileName, webResourceInfo);
            SyncAddToSolutionButton();
        }


        private void CloseWebResource(string fileName)
        {
            if (!_webResources.ContainsKey(fileName))
                return;

            foreach (DataGridViewRow row in WebResourcesGrid.Rows)
            {
                if ((string)row.Tag == fileName)
                {
                    WebResourcesGrid.Rows.Remove(row);
                    break;
                }
            }

            _webResources.Remove(fileName);
            SyncAddToSolutionButton();
            SaveSettings();
        }


        private void BrowseAndSelectButton_Click(object sender, EventArgs e)
        {
            var fileDialog = new OpenFileDialog { Filter = WebResourceFileFilter };
            if (fileDialog.ShowDialog() != DialogResult.OK)
                return;

            var fullFileName = fileDialog.FileName;

            if (_webResources.ContainsKey(fullFileName))
            {
                MessageBox.Show("This file is already being monitored.", "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var extension = Path.GetExtension(fullFileName);
            var typeCode = !string.IsNullOrEmpty(extension) && _extensionTypeCodeMap.ContainsKey(extension)
                ? _extensionTypeCodeMap[extension]
                : 0;

            var wrDialog = new SelectWebResourceDialog(typeCode);
            if (wrDialog.ShowDialog() != DialogResult.OK)
                return;

            AddWebResourceToUI(fullFileName, wrDialog.WebResourceId, wrDialog.WebResourceName, false);
            SaveSettings();
        }


        private void LuckyButton_Click(object sender, EventArgs e)
        {
            var fileDialog = new OpenFileDialog { Filter = WebResourceFileFilter };
            if (fileDialog.ShowDialog() != DialogResult.OK)
                return;

            var fullFileName = fileDialog.FileName;

            if (_webResources.ContainsKey(fullFileName))
            {
                MessageBox.Show("This file is already being monitored.", "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var result = SelectWebResourceDialog.FindByFileName(fullFileName);

            if (result.HasValue)
            {
                AddWebResourceToUI(fullFileName, result.Value.Id, result.Value.Name, false);
                SaveSettings();
                MessageBox.Show($"Matched: {result.Value.Name}", "Match Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                var dialogResult = MessageBox.Show(
                    $"No matching web resource found for '{Path.GetFileName(fullFileName)}'.\n\nWould you like to select one manually?",
                    "No Match Found",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information);

                if (dialogResult == DialogResult.Yes)
                {
                    var extension = Path.GetExtension(fullFileName);
                    var typeCode = !string.IsNullOrEmpty(extension) && _extensionTypeCodeMap.ContainsKey(extension)
                        ? _extensionTypeCodeMap[extension]
                        : 0;
                    var wrDialog = new SelectWebResourceDialog(typeCode);
                    if (wrDialog.ShowDialog() == DialogResult.OK)
                    {
                        AddWebResourceToUI(fullFileName, wrDialog.WebResourceId, wrDialog.WebResourceName, false);
                        SaveSettings();
                    }
                }
            }
        }

        private void AddToSolutionButton_Click(object sender, EventArgs e)
        {
            if (Service == null)
            {
                MessageBox.Show("Please connect to Dataverse first.", "Add to solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (_webResources.Count == 0)
            {
                MessageBox.Show("No monitored web resources.", "Add to solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var dialog = new AddWebResourcesToSolutionDialog(Service, _webResources.Values);
            if (dialog.ShowDialog(this) != DialogResult.OK)
                return;

            if (dialog.SelectedSolutionId.HasValue)
            {
                foreach (var info in _webResources.Values)
                {
                    if (dialog.AddedWebResourceIds.Contains(info.WebResourceId))
                        info.LastSolutionId = dialog.SelectedSolutionId.Value;
                }

                SaveSettings();
                ShowNotification($"Added {dialog.AddedWebResourceIds.Count} web resources to solution", false);
            }
        }

        #endregion


        #region Add Plugins

        private void AddPluginButton_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog { Filter = "DLL files (*.dll)|*.dll|All files|*.*" };
            if (dialog.ShowDialog() != DialogResult.OK)
                return;

            var fullFileName = dialog.FileName;
            if (_plugins.ContainsKey(fullFileName))
            {
                MessageBox.Show("This plugin is already being monitored.", "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            AddPluginToUI(fullFileName, false);
            SaveSettings();
        }


        private void AddPluginToUI(string fullFileName, bool isAuto)
        {
            if (_plugins.ContainsKey(fullFileName))
                return;

            var pluginInfo = new PluginInfo
            {
                FileName = fullFileName,
                IsAuto = isAuto
            };

            PluginsGrid.Rows.Insert(0);
            var row = PluginsGrid.Rows[0];
            row.Tag = fullFileName;
            row.Cells["ColPlFileName"].Value = TruncatePath(fullFileName);
            row.Cells["ColPlFileName"].ToolTipText = fullFileName;
            row.Cells["ColPlAuto"].Value = isAuto;
            row.Cells["ColPlStatus"].Value = "";
            row.Cells["ColPlLastPublished"].Value = "";

            var directoryName = Path.GetDirectoryName(fullFileName);
            _watchers.Add(directoryName);
            _plugins.Add(fullFileName, pluginInfo);
        }


        private void ClosePlugin(string fileName)
        {
            if (!_plugins.ContainsKey(fileName))
                return;

            foreach (DataGridViewRow row in PluginsGrid.Rows)
            {
                if ((string)row.Tag == fileName)
                {
                    PluginsGrid.Rows.Remove(row);
                    break;
                }
            }

            _plugins.Remove(fileName);
            SaveSettings();
        }

        #endregion


        #region DataGridView Event Handlers

        private void ConfigureGridInteractions(DataGridView grid)
        {
            grid.CellPainting += Grid_CellPainting;
            grid.CellMouseEnter += Grid_CellMouseEnter;
            grid.CellMouseLeave += Grid_CellMouseLeave;
            grid.MouseLeave += Grid_MouseLeave;
        }

        private static bool IsPublishColumn(DataGridView grid, int columnIndex)
        {
            if (columnIndex < 0 || columnIndex >= grid.Columns.Count)
                return false;

            var columnName = grid.Columns[columnIndex].Name;
            return columnName == "ColWrPublish" || columnName == "ColPlPublish";
        }

        private static bool IsDeleteColumn(DataGridView grid, int columnIndex)
        {
            if (columnIndex < 0 || columnIndex >= grid.Columns.Count)
                return false;

            var columnName = grid.Columns[columnIndex].Name;
            return columnName == "ColWrClose" || columnName == "ColPlClose";
        }

        private static bool IsButtonColumn(DataGridView grid, int columnIndex)
        {
            if (columnIndex < 0 || columnIndex >= grid.Columns.Count)
                return false;

            var columnName = grid.Columns[columnIndex].Name;
            return columnName == "ColWrPublish" || columnName == "ColPlPublish"
                || columnName == "ColWrClose" || columnName == "ColPlClose";
        }

        private void Grid_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            var grid = (DataGridView)sender;

            if (IsPublishColumn(grid, e.ColumnIndex))
            {
                var isHovered = grid == _hoveredButtonGrid
                                && e.RowIndex == _hoveredButtonRowIndex
                                && e.ColumnIndex == _hoveredButtonColumnIndex;
                var backgroundColor = isHovered ? _publishButtonHoverColor : _publishButtonColor;
                PaintGridButtonCell(grid, e, "Publish", backgroundColor, Color.White);
                return;
            }

            if (IsDeleteColumn(grid, e.ColumnIndex))
            {
                var isHovered = grid == _hoveredButtonGrid
                                && e.RowIndex == _hoveredButtonRowIndex
                                && e.ColumnIndex == _hoveredButtonColumnIndex;
                var backgroundColor = isHovered ? _deleteButtonHoverColor : _deleteButtonColor;
                PaintGridButtonCell(grid, e, "Remove", backgroundColor, Color.White);
            }
        }

        private static void PaintGridButtonCell(DataGridView grid, DataGridViewCellPaintingEventArgs e, string text, Color backColor, Color foreColor)
        {
            e.PaintBackground(e.CellBounds, true);
            e.Paint(e.CellBounds, DataGridViewPaintParts.Border);

            var buttonBounds = new Rectangle(
                e.CellBounds.X + 4,
                e.CellBounds.Y + 4,
                Math.Max(1, e.CellBounds.Width - 8),
                Math.Max(1, e.CellBounds.Height - 8));

            using (var backBrush = new SolidBrush(backColor))
            {
                e.Graphics.FillRectangle(backBrush, buttonBounds);
            }

            TextRenderer.DrawText(
                e.Graphics,
                text,
                e.CellStyle.Font ?? grid.Font,
                buttonBounds,
                foreColor,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);

            e.Handled = true;
        }

        private void Grid_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            var grid = (DataGridView)sender;
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            if (IsButtonColumn(grid, e.ColumnIndex))
            {
                grid.Cursor = Cursors.Hand;
                SetHoveredButtonCell(grid, e.RowIndex, e.ColumnIndex);
            }
        }

        private void Grid_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            var grid = (DataGridView)sender;
            grid.Cursor = Cursors.Default;

            if (_hoveredButtonGrid == sender && _hoveredButtonRowIndex == e.RowIndex && _hoveredButtonColumnIndex == e.ColumnIndex)
                ClearHoveredButtonCell();
        }

        private void Grid_MouseLeave(object sender, EventArgs e)
        {
            var grid = (DataGridView)sender;
            grid.Cursor = Cursors.Default;

            if (_hoveredButtonGrid == sender)
                ClearHoveredButtonCell();
        }

        private void SetHoveredButtonCell(DataGridView grid, int rowIndex, int columnIndex)
        {
            if (_hoveredButtonGrid == grid && _hoveredButtonRowIndex == rowIndex && _hoveredButtonColumnIndex == columnIndex)
                return;

            if (_hoveredButtonGrid != null && _hoveredButtonRowIndex >= 0 && _hoveredButtonColumnIndex >= 0
                && _hoveredButtonRowIndex < _hoveredButtonGrid.RowCount && _hoveredButtonColumnIndex < _hoveredButtonGrid.ColumnCount)
                _hoveredButtonGrid.InvalidateCell(_hoveredButtonColumnIndex, _hoveredButtonRowIndex);

            _hoveredButtonGrid = grid;
            _hoveredButtonRowIndex = rowIndex;
            _hoveredButtonColumnIndex = columnIndex;
            _hoveredButtonGrid.InvalidateCell(_hoveredButtonColumnIndex, _hoveredButtonRowIndex);
        }

        private void ClearHoveredButtonCell()
        {
            if (_hoveredButtonGrid != null && _hoveredButtonRowIndex >= 0 && _hoveredButtonColumnIndex >= 0
                && _hoveredButtonRowIndex < _hoveredButtonGrid.RowCount && _hoveredButtonColumnIndex < _hoveredButtonGrid.ColumnCount)
                _hoveredButtonGrid.InvalidateCell(_hoveredButtonColumnIndex, _hoveredButtonRowIndex);

            _hoveredButtonGrid = null;
            _hoveredButtonRowIndex = -1;
            _hoveredButtonColumnIndex = -1;
        }

        private void WebResourcesGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = WebResourcesGrid.Rows[e.RowIndex];
            var key = (string)row.Tag;

            if (WebResourcesGrid.Columns[e.ColumnIndex].Name == "ColWrPublish")
            {
                if (!_webResources.ContainsKey(key) || _webResources[key].IsBusy) return;
                PublishWebResource(_webResources[key]);
            }
            else if (WebResourcesGrid.Columns[e.ColumnIndex].Name == "ColWrClose")
            {
                CloseWebResource(key);
            }
        }

        private void WebResourcesGrid_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (WebResourcesGrid.CurrentCell is DataGridViewCheckBoxCell)
                WebResourcesGrid.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void WebResourcesGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (WebResourcesGrid.Columns[e.ColumnIndex].Name == "ColWrAuto")
            {
                var key = (string)WebResourcesGrid.Rows[e.RowIndex].Tag;
                if (_webResources.ContainsKey(key))
                {
                    _webResources[key].IsAuto = (bool)(WebResourcesGrid.Rows[e.RowIndex].Cells["ColWrAuto"].Value ?? false);
                    SaveSettings();
                }
            }
        }

        private void PluginsGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = PluginsGrid.Rows[e.RowIndex];
            var key = (string)row.Tag;

            if (PluginsGrid.Columns[e.ColumnIndex].Name == "ColPlPublish")
            {
                if (!_plugins.ContainsKey(key) || _plugins[key].IsBusy) return;
                PublishPlugin(Service, _plugins[key]);
            }
            else if (PluginsGrid.Columns[e.ColumnIndex].Name == "ColPlClose")
            {
                ClosePlugin(key);
            }
        }

        private void PluginsGrid_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (PluginsGrid.CurrentCell is DataGridViewCheckBoxCell)
                PluginsGrid.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void PluginsGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (PluginsGrid.Columns[e.ColumnIndex].Name == "ColPlAuto")
            {
                var key = (string)PluginsGrid.Rows[e.RowIndex].Tag;
                if (_plugins.ContainsKey(key))
                {
                    _plugins[key].IsAuto = (bool)(PluginsGrid.Rows[e.RowIndex].Cells["ColPlAuto"].Value ?? false);
                    SaveSettings();
                }
            }
        }

        #endregion


        #region Grid Update Helpers

        private void UpdateWebResourceGridRow(string key)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() => UpdateWebResourceGridRow(key)));
                return;
            }
            if (!_webResources.ContainsKey(key)) return;
            var info = _webResources[key];
            foreach (DataGridViewRow row in WebResourcesGrid.Rows)
            {
                if ((string)row.Tag == key)
                {
                    ApplyStatusStyle(row.Cells["ColWrStatus"], info.IsBusy, info.IsDirty);
                    row.Cells["ColWrLastPublished"].Value = FormatRelativeTime(info.LastPublish);
                    break;
                }
            }
            SyncPublishingTimer();
        }

        private void UpdatePluginGridRow(string key)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() => UpdatePluginGridRow(key)));
                return;
            }
            if (!_plugins.ContainsKey(key)) return;
            var info = _plugins[key];
            foreach (DataGridViewRow row in PluginsGrid.Rows)
            {
                if ((string)row.Tag == key)
                {
                    ApplyStatusStyle(row.Cells["ColPlStatus"], info.IsBusy, info.IsDirty);
                    row.Cells["ColPlLastPublished"].Value = FormatRelativeTime(info.LastPublish);
                    break;
                }
            }
            SyncPublishingTimer();
        }

        private void ApplyStatusStyle(DataGridViewCell cell, bool isBusy, bool isDirty)
        {
            if (isBusy)
            {
                var dots = new string('.', (_publishingDotCount % 3) + 1);
                cell.Value = "Publishing" + dots;
                cell.Style.ForeColor = _statusPublishingColor;
                cell.Style.Font = new Font(WebResourcesGrid.Font, FontStyle.Bold);
            }
            else if (isDirty)
            {
                cell.Value = "Modified";
                cell.Style.ForeColor = _statusModifiedColor;
                cell.Style.Font = new Font(WebResourcesGrid.Font, FontStyle.Bold);
            }
            else
            {
                cell.Value = "";
                cell.Style.ForeColor = Color.Black;
                cell.Style.Font = null;
            }
        }

        private void SyncPublishingTimer()
        {
            var anyBusy = _webResources.Values.Any(w => w.IsBusy) || _plugins.Values.Any(p => p.IsBusy);
            if (anyBusy && !_publishingAnimTimer.Enabled)
            {
                _publishingDotCount = 0;
                _publishingAnimTimer.Start();
            }
            else if (!anyBusy && _publishingAnimTimer.Enabled)
            {
                _publishingAnimTimer.Stop();
            }
            SyncPublishAllButton();
        }

        private void SyncPublishAllButton()
        {
            if (PublishAllButton == null || ActionToolTip == null)
                return;

            var anyDirty = _webResources.Values.Any(w => w.IsDirty) || _plugins.Values.Any(p => p.IsDirty);
            PublishAllButton.Enabled = anyDirty;
            if (anyDirty)
            {
                PublishAllButton.BackColor = _publishButtonColor;
                PublishAllButton.ForeColor = Color.White;
                PublishAllButton.FlatAppearance.MouseOverBackColor = _publishButtonHoverColor;
                PublishAllButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(50, 100, 170);
                ActionToolTip.SetToolTip(PublishAllButton, "Publish all changed items (Ctrl+Shift+P)");
            }
            else
            {
                PublishAllButton.BackColor = Color.FromArgb(200, 200, 200);
                PublishAllButton.ForeColor = Color.FromArgb(140, 140, 140);
                PublishAllButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(200, 200, 200);
                PublishAllButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(200, 200, 200);
                ActionToolTip.SetToolTip(PublishAllButton, "No changed items to publish");
            }
        }

        private void SyncAddToSolutionButton()
        {
            if (AddToSolutionButton == null)
                return;

            var hasMonitoredWebResources = _webResources.Count > 0;
            AddToSolutionButton.Enabled = hasMonitoredWebResources;
            if (ActionToolTip != null)
            {
                ActionToolTip.SetToolTip(
                    AddToSolutionButton,
                    hasMonitoredWebResources
                        ? "Add monitored web resources to a solution"
                        : "No monitored web resources to add");
            }
        }

        private void PublishingAnimTimer_Tick(object sender, EventArgs e)
        {
            _publishingDotCount++;
            foreach (var kvp in _webResources)
            {
                if (kvp.Value.IsBusy)
                {
                    foreach (DataGridViewRow row in WebResourcesGrid.Rows)
                    {
                        if ((string)row.Tag == kvp.Key)
                        {
                            var dots = new string('.', (_publishingDotCount % 3) + 1);
                            row.Cells["ColWrStatus"].Value = "Publishing" + dots;
                            break;
                        }
                    }
                }
            }
            foreach (var kvp in _plugins)
            {
                if (kvp.Value.IsBusy)
                {
                    foreach (DataGridViewRow row in PluginsGrid.Rows)
                    {
                        if ((string)row.Tag == kvp.Key)
                        {
                            var dots = new string('.', (_publishingDotCount % 3) + 1);
                            row.Cells["ColPlStatus"].Value = "Publishing" + dots;
                            break;
                        }
                    }
                }
            }
        }

        #endregion


        #region Export / Import

        private void ExportButton_Click(object sender, EventArgs e)
        {
            var dialog = new SaveFileDialog
            {
                Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*",
                DefaultExt = "json",
                FileName = $"InstantPublisher_{_currentConnectionKey}"
            };
            if (dialog.ShowDialog() != DialogResult.OK) return;

            var collection = new MonitoredCollection();
            foreach (var kvp in _webResources)
            {
                collection.WebResources.Add(new MonitoredWebResource
                {
                    FilePath = kvp.Key,
                    WebResourceId = kvp.Value.WebResourceId,
                    WebResourceName = kvp.Value.WebResourceName,
                    LastSolutionId = kvp.Value.LastSolutionId,
                    IsAuto = kvp.Value.IsAuto
                });
            }
            foreach (var kvp in _plugins)
            {
                collection.Plugins.Add(new MonitoredPlugin
                {
                    FilePath = kvp.Key,
                    IsAuto = kvp.Value.IsAuto
                });
            }

            var json = JsonConvert.SerializeObject(collection, Formatting.Indented);
            File.WriteAllText(dialog.FileName, json);
            MessageBox.Show($"Exported {collection.WebResources.Count} web resources and {collection.Plugins.Count} plugins.",
                "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void ImportButton_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*",
                DefaultExt = "json"
            };
            if (dialog.ShowDialog() != DialogResult.OK) return;

            try
            {
                var json = File.ReadAllText(dialog.FileName);
                var collection = JsonConvert.DeserializeObject<MonitoredCollection>(json);

                foreach (var wr in collection.WebResources)
                    AddWebResourceToUI(wr.FilePath, wr.WebResourceId, wr.WebResourceName, wr.IsAuto, wr.LastSolutionId);
                foreach (var p in collection.Plugins)
                    AddPluginToUI(p.FilePath, p.IsAuto);

                SaveSettings();

                MessageBox.Show($"Imported {collection.WebResources.Count} web resources and {collection.Plugins.Count} plugins.",
                    "Import Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error importing file: {ex.Message}",
                    "Import Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion


        #region Collapse / Expand

        private int _wrSavedSplitterDistance;
        private int _plSavedSplitterDistance;
        private bool _wrCollapsed;
        private bool _plCollapsed;

        private void WrHeaderPanel_Click(object sender, EventArgs e)
        {
            if (!_wrCollapsed)
            {
                _wrSavedSplitterDistance = splitContainer1.SplitterDistance;
                splitContainer1.SplitterDistance = splitContainer1.Panel1MinSize;
                splitContainer1.IsSplitterFixed = _plCollapsed || true;
                _wrCollapsed = true;
                WrCollapseLabel.Text = "\u25BC";
            }
            else
            {
                splitContainer1.SplitterDistance = _wrSavedSplitterDistance > splitContainer1.Panel1MinSize
                    ? _wrSavedSplitterDistance
                    : splitContainer1.Height / 2;
                splitContainer1.IsSplitterFixed = _plCollapsed;
                _wrCollapsed = false;
                WrCollapseLabel.Text = "\u25B2";
            }
        }

        private void PlHeaderPanel_Click(object sender, EventArgs e)
        {
            if (!_plCollapsed)
            {
                _plSavedSplitterDistance = splitContainer1.SplitterDistance;
                splitContainer1.SplitterDistance = splitContainer1.Height - splitContainer1.Panel2MinSize - splitContainer1.SplitterWidth;
                splitContainer1.IsSplitterFixed = _wrCollapsed || true;
                _plCollapsed = true;
                PlCollapseLabel.Text = "\u25BC";
            }
            else
            {
                splitContainer1.SplitterDistance = _plSavedSplitterDistance < splitContainer1.Height - splitContainer1.Panel2MinSize - splitContainer1.SplitterWidth
                    ? _plSavedSplitterDistance
                    : splitContainer1.Height / 2;
                splitContainer1.IsSplitterFixed = _wrCollapsed;
                _plCollapsed = false;
                PlCollapseLabel.Text = "\u25B2";
            }
        }

        #endregion


        private void GitHubLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/la-lo-go/instant-publisher");
        }


        #region Publish All

        private void PublishAllButton_Click(object sender, EventArgs e)
        {
            foreach (var info in _webResources.Values)
            {
                if (info.IsDirty && !info.IsBusy)
                    PublishWebResource(info);
            }
            foreach (var info in _plugins.Values)
            {
                if (info.IsDirty && !info.IsBusy)
                    PublishPlugin(Service, info);
            }
        }

        #endregion


        #region Notifications

        private void ShowNotification(string message, bool isError)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() => ShowNotification(message, isError)));
                return;
            }
            StatusNotificationLabel.ForeColor = isError ? _notificationErrorColor : _notificationSuccessColor;
            StatusNotificationLabel.Text = message;
            _notificationTimer.Stop();
            _notificationTimer.Start();
        }

        #endregion


        #region Keyboard Shortcuts

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.Shift | Keys.P))
            {
                if (PublishAllButton.Enabled)
                    PublishAllButton_Click(this, EventArgs.Empty);
                return true;
            }
            if (keyData == (Keys.Control | Keys.E))
            {
                if (ExportButton.Enabled)
                    ExportButton_Click(this, EventArgs.Empty);
                return true;
            }
            if (keyData == (Keys.Control | Keys.I))
            {
                if (ImportButton.Enabled)
                    ImportButton_Click(this, EventArgs.Empty);
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        #endregion


        #region Relative Time

        private static string FormatRelativeTime(DateTime timestamp)
        {
            if (timestamp == DateTime.MinValue)
                return "";

            var elapsed = DateTime.Now - timestamp;

            if (elapsed.TotalSeconds < 60)
                return "Just now";
            if (elapsed.TotalMinutes < 60)
                return $"{(int)elapsed.TotalMinutes} min ago";
            if (elapsed.TotalHours < 24)
                return $"{(int)elapsed.TotalHours} hr ago";
            return $"{(int)elapsed.TotalDays} days ago";
        }

        private void RelativeTimeTimer_Tick(object sender, EventArgs e)
        {
            foreach (var kvp in _webResources)
            {
                if (kvp.Value.LastPublish == DateTime.MinValue) continue;
                foreach (DataGridViewRow row in WebResourcesGrid.Rows)
                {
                    if ((string)row.Tag == kvp.Key)
                    {
                        row.Cells["ColWrLastPublished"].Value = FormatRelativeTime(kvp.Value.LastPublish);
                        break;
                    }
                }
            }
            foreach (var kvp in _plugins)
            {
                if (kvp.Value.LastPublish == DateTime.MinValue) continue;
                foreach (DataGridViewRow row in PluginsGrid.Rows)
                {
                    if ((string)row.Tag == kvp.Key)
                    {
                        row.Cells["ColPlLastPublished"].Value = FormatRelativeTime(kvp.Value.LastPublish);
                        break;
                    }
                }
            }
        }

        #endregion
    }
}
