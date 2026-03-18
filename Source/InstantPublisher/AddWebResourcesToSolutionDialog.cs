using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Lalogo.InstantPublisher.Models;
using Lalogo.InstantPublisher.Services;

namespace Lalogo.InstantPublisher
{
    public class AddWebResourcesToSolutionDialog : Form
    {
        private static readonly Color SurfaceColor = Color.FromArgb(240, 242, 245);
        private static readonly Color HeaderColor = Color.FromArgb(74, 144, 217);
        private static readonly Color HeaderTextColor = Color.White;
        private static readonly Color GridHeaderBackColor = Color.FromArgb(240, 242, 245);
        private static readonly Color GridHeaderTextColor = Color.FromArgb(100, 100, 100);
        private static readonly Color GridAltRowColor = Color.FromArgb(230, 236, 245);
        private static readonly Color GridLineColor = Color.FromArgb(220, 225, 230);

        private readonly SolutionService _solutionService;
        private readonly List<WebResourceInfo> _webResources;
        private readonly List<SelectableSolutionComponent> _componentItems = new List<SelectableSolutionComponent>();

        private readonly TextBox _solutionSearchTextBox;
        private readonly ListBox _solutionsListBox;
        private readonly Label _selectedSolutionLabel;
        private readonly CheckBox _selectAllCheckBox;
        private readonly DataGridView _componentsGrid;
        private readonly Button _addSelectedButton;
        private readonly Button _cancelButton;
        private readonly Label _summaryLabel;

        private bool _suppressEvents;

        public Guid? SelectedSolutionId { get; private set; }
        public string SelectedSolutionUniqueName { get; private set; }
        public List<Guid> AddedWebResourceIds { get; } = new List<Guid>();

        public AddWebResourcesToSolutionDialog(Microsoft.Xrm.Sdk.IOrganizationService service, IEnumerable<WebResourceInfo> webResources)
        {
            if (service == null) throw new ArgumentNullException(nameof(service));
            if (webResources == null) throw new ArgumentNullException(nameof(webResources));

            _solutionService = new SolutionService(service);
            _webResources = webResources
                .Where(w => w != null)
                .GroupBy(w => w.WebResourceId)
                .Select(g => g.First())
                .OrderBy(w => w.WebResourceName)
                .ToList();

            Text = "Add Web Resources to Solution";
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.Sizable;
            MinimizeBox = false;
            MaximizeBox = true;
            ShowInTaskbar = false;
            Size = new Size(860, 620);
            Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point);
            BackColor = SurfaceColor;

            var root = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 4,
                Padding = new Padding(12),
                BackColor = SurfaceColor
            };
            root.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            root.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            root.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
            root.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            Controls.Add(root);

            var solutionPanel = new TableLayoutPanel
            {
                Dock = DockStyle.Top,
                ColumnCount = 1,
                RowCount = 4,
                AutoSize = true,
                BackColor = Color.White,
                Padding = new Padding(10),
                Margin = new Padding(0, 0, 0, 8)
            };
            solutionPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            solutionPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            solutionPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 140));
            solutionPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            var solutionTitle = new Label
            {
                Text = "Select solution",
                AutoSize = true,
                Font = new Font(Font, FontStyle.Bold),
                ForeColor = HeaderColor,
                Margin = new Padding(0, 0, 0, 6)
            };
            solutionPanel.Controls.Add(solutionTitle, 0, 0);

            _solutionSearchTextBox = new TextBox
            {
                Dock = DockStyle.Top,
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.White,
                Margin = new Padding(0, 0, 0, 6)
            };
            _solutionSearchTextBox.TextChanged += SolutionSearchTextBox_TextChanged;
            solutionPanel.Controls.Add(_solutionSearchTextBox, 0, 1);

            _solutionsListBox = new ListBox
            {
                Dock = DockStyle.Fill,
                IntegralHeight = false,
                BorderStyle = BorderStyle.None,
                BackColor = Color.White,
                Margin = new Padding(0)
            };
            _solutionsListBox.SelectedIndexChanged += SolutionsListBox_SelectedIndexChanged;
            solutionPanel.Controls.Add(_solutionsListBox, 0, 2);

            _selectedSolutionLabel = new Label
            {
                Text = "Selected: none",
                AutoSize = true,
                ForeColor = Color.FromArgb(80, 80, 80),
                Margin = new Padding(0, 6, 0, 6)
            };
            solutionPanel.Controls.Add(_selectedSolutionLabel, 0, 3);

            root.Controls.Add(solutionPanel, 0, 0);

            _selectAllCheckBox = new CheckBox
            {
                Text = "Select all available",
                AutoSize = true,
                Enabled = false,
                ForeColor = Color.FromArgb(80, 80, 80),
                Margin = new Padding(0, 0, 0, 6)
            };
            _selectAllCheckBox.CheckedChanged += SelectAllCheckBox_CheckedChanged;
            root.Controls.Add(_selectAllCheckBox, 0, 1);

            _componentsGrid = new DataGridView
            {
                Dock = DockStyle.Fill,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                AllowUserToResizeRows = false,
                MultiSelect = false,
                RowHeadersVisible = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal,
                EnableHeadersVisualStyles = false,
                ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };
            _componentsGrid.ColumnHeadersDefaultCellStyle.BackColor = GridHeaderBackColor;
            _componentsGrid.ColumnHeadersDefaultCellStyle.ForeColor = GridHeaderTextColor;
            _componentsGrid.ColumnHeadersDefaultCellStyle.SelectionBackColor = GridHeaderBackColor;
            _componentsGrid.ColumnHeadersDefaultCellStyle.SelectionForeColor = GridHeaderTextColor;
            _componentsGrid.ColumnHeadersDefaultCellStyle.Padding = new Padding(0, 4, 0, 4);
            _componentsGrid.DefaultCellStyle.BackColor = Color.White;
            _componentsGrid.DefaultCellStyle.Padding = new Padding(0, 3, 0, 3);
            _componentsGrid.DefaultCellStyle.SelectionBackColor = Color.White;
            _componentsGrid.DefaultCellStyle.SelectionForeColor = Color.Black;
            _componentsGrid.AlternatingRowsDefaultCellStyle.BackColor = GridAltRowColor;
            _componentsGrid.AlternatingRowsDefaultCellStyle.SelectionBackColor = GridAltRowColor;
            _componentsGrid.AlternatingRowsDefaultCellStyle.SelectionForeColor = Color.Black;
            _componentsGrid.GridColor = GridLineColor;
            _componentsGrid.RowTemplate.Height = 30;
            _componentsGrid.Columns.Add(new DataGridViewCheckBoxColumn { Name = "ColSelect", HeaderText = "", Width = 40, FillWeight = 10f });
            _componentsGrid.Columns.Add(new DataGridViewTextBoxColumn { Name = "ColName", HeaderText = "Web Resource", ReadOnly = true, FillWeight = 50f });
            _componentsGrid.Columns.Add(new DataGridViewTextBoxColumn { Name = "ColType", HeaderText = "Type", ReadOnly = true, FillWeight = 20f });
            _componentsGrid.Columns.Add(new DataGridViewTextBoxColumn { Name = "ColStatus", HeaderText = "Status", ReadOnly = true, FillWeight = 20f });
            _componentsGrid.CurrentCellDirtyStateChanged += ComponentsGrid_CurrentCellDirtyStateChanged;
            _componentsGrid.CellValueChanged += ComponentsGrid_CellValueChanged;
            root.Controls.Add(_componentsGrid, 0, 2);

            var bottomPanel = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 3,
                RowCount = 1,
                AutoSize = true,
                BackColor = Color.White,
                Padding = new Padding(10, 8, 10, 8)
            };
            bottomPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
            bottomPanel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            bottomPanel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));

            _summaryLabel = new Label
            {
                AutoSize = true,
                Anchor = AnchorStyles.Left,
                ForeColor = Color.FromArgb(80, 80, 80),
                Text = "Select a solution to continue"
            };
            bottomPanel.Controls.Add(_summaryLabel, 0, 0);

            _addSelectedButton = new Button
            {
                Text = "Add selected",
                AutoSize = true,
                Enabled = false,
                Margin = new Padding(8, 0, 0, 0)
            };
            _addSelectedButton.FlatStyle = FlatStyle.Flat;
            _addSelectedButton.BackColor = HeaderColor;
            _addSelectedButton.ForeColor = HeaderTextColor;
            _addSelectedButton.FlatAppearance.BorderSize = 0;
            _addSelectedButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(60, 120, 190);
            _addSelectedButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(50, 100, 170);
            _addSelectedButton.Padding = new Padding(14, 4, 14, 4);
            _addSelectedButton.Click += AddSelectedButton_Click;
            bottomPanel.Controls.Add(_addSelectedButton, 1, 0);

            _cancelButton = new Button
            {
                Text = "Cancel",
                AutoSize = true,
                Margin = new Padding(8, 0, 0, 0)
            };
            _cancelButton.FlatStyle = FlatStyle.Flat;
            _cancelButton.BackColor = Color.White;
            _cancelButton.ForeColor = Color.FromArgb(80, 80, 80);
            _cancelButton.FlatAppearance.BorderColor = Color.FromArgb(200, 200, 200);
            _cancelButton.FlatAppearance.BorderSize = 1;
            _cancelButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(245, 247, 250);
            _cancelButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(235, 238, 242);
            _cancelButton.Padding = new Padding(14, 4, 14, 4);
            _cancelButton.Click += (s, e) => Close();
            bottomPanel.Controls.Add(_cancelButton, 2, 0);

            root.Controls.Add(bottomPanel, 0, 3);

            Load += AddWebResourcesToSolutionDialog_Load;
        }

        private void AddWebResourcesToSolutionDialog_Load(object sender, EventArgs e)
        {
            LoadSolutions(_solutionSearchTextBox.Text);
        }

        private void SolutionSearchTextBox_TextChanged(object sender, EventArgs e)
        {
            LoadSolutions(_solutionSearchTextBox.Text);
        }

        private void LoadSolutions(string searchText)
        {
            SolutionReference previousSelection = null;
            if (_solutionsListBox.SelectedItem is SolutionReference selected)
                previousSelection = selected;

            List<SolutionReference> solutions;
            try
            {
                solutions = _solutionService.GetSolutions(searchText);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Failed to load solutions:\n" + ex.Message, "Add to solution", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _suppressEvents = true;
            _solutionsListBox.BeginUpdate();
            _solutionsListBox.Items.Clear();
            foreach (var solution in solutions)
                _solutionsListBox.Items.Add(solution);
            _solutionsListBox.EndUpdate();

            if (previousSelection != null)
            {
                for (var i = 0; i < _solutionsListBox.Items.Count; i++)
                {
                    var item = _solutionsListBox.Items[i] as SolutionReference;
                    if (item != null && item.Id == previousSelection.Id)
                    {
                        _solutionsListBox.SelectedIndex = i;
                        break;
                    }
                }
            }

            _suppressEvents = false;

            if (_solutionsListBox.SelectedItem == null)
            {
                _selectedSolutionLabel.Text = "Selected: none";
                ResetComponentsGrid();
                _summaryLabel.Text = solutions.Count == 0 ? "No solutions found" : "Select a solution to continue";
            }
        }

        private void SolutionsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_suppressEvents)
                return;

            var solution = _solutionsListBox.SelectedItem as SolutionReference;
            if (solution == null)
            {
                _selectedSolutionLabel.Text = "Selected: none";
                ResetComponentsGrid();
                return;
            }

            SelectedSolutionId = solution.Id;
            SelectedSolutionUniqueName = solution.UniqueName;
            _selectedSolutionLabel.Text = "Selected: " + solution.DisplayName;

            HashSet<Guid> existingIds;
            try
            {
                existingIds = _solutionService.GetComponentIdsInSolution(solution.Id, SolutionComponentType.WebResource);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Failed to load solution components:\n" + ex.Message, "Add to solution", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ResetComponentsGrid();
                return;
            }

            BuildComponentItems(existingIds);
            PopulateComponentsGrid();
            UpdateActionState();
        }

        private void BuildComponentItems(HashSet<Guid> existingIds)
        {
            _componentItems.Clear();

            foreach (var wr in _webResources)
            {
                _componentItems.Add(new SelectableSolutionComponent
                {
                    ComponentId = wr.WebResourceId,
                    ComponentType = SolutionComponentType.WebResource,
                    Name = wr.WebResourceName,
                    TypeLabel = ResolveWebResourceType(wr.FileName, wr.WebResourceName),
                    IsAlreadyInSolution = existingIds.Contains(wr.WebResourceId),
                    IsSelected = false
                });
            }
        }

        private static string ResolveWebResourceType(string localFileName, string webResourceName)
        {
            var extension = Path.GetExtension(localFileName);
            if (string.IsNullOrWhiteSpace(extension))
                extension = Path.GetExtension(webResourceName);
            if (string.IsNullOrWhiteSpace(extension))
                return "Other";

            switch (extension.ToLowerInvariant())
            {
                case ".htm":
                case ".html":
                    return "HTML";
                case ".css":
                case ".xsl":
                    return "Style";
                case ".js":
                    return "Script";
                case ".xml":
                    return "XML";
                case ".png":
                case ".jpg":
                case ".jpeg":
                case ".gif":
                case ".ico":
                case ".svg":
                    return "Image";
                default:
                    return "Other";
            }
        }

        private void PopulateComponentsGrid()
        {
            _suppressEvents = true;
            _componentsGrid.Rows.Clear();

            foreach (var component in _componentItems)
            {
                var rowIndex = _componentsGrid.Rows.Add(component.IsSelected, component.Name, component.TypeLabel, component.StatusLabel);
                var row = _componentsGrid.Rows[rowIndex];
                row.Tag = component;

                if (!component.CanSelect)
                {
                    row.Cells["ColSelect"].ReadOnly = true;
                    row.DefaultCellStyle.ForeColor = Color.FromArgb(170, 170, 170);
                    row.DefaultCellStyle.SelectionForeColor = Color.FromArgb(170, 170, 170);
                    row.DefaultCellStyle.SelectionBackColor = Color.FromArgb(245, 245, 245);
                    row.DefaultCellStyle.BackColor = Color.FromArgb(248, 248, 248);
                }
            }

            _suppressEvents = false;
            UpdateActionState();
        }

        private void ResetComponentsGrid()
        {
            _componentItems.Clear();
            _componentsGrid.Rows.Clear();
            _selectAllCheckBox.Checked = false;
            _selectAllCheckBox.Enabled = false;
            _addSelectedButton.Enabled = false;
        }

        private void SelectAllCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (_suppressEvents)
                return;

            _suppressEvents = true;
            var shouldSelect = _selectAllCheckBox.Checked;
            foreach (DataGridViewRow row in _componentsGrid.Rows)
            {
                var component = row.Tag as SelectableSolutionComponent;
                if (component == null || !component.CanSelect)
                    continue;

                component.IsSelected = shouldSelect;
                row.Cells["ColSelect"].Value = shouldSelect;
            }
            _suppressEvents = false;

            UpdateActionState();
        }

        private void ComponentsGrid_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (_componentsGrid.CurrentCell is DataGridViewCheckBoxCell)
                _componentsGrid.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void ComponentsGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (_suppressEvents || e.RowIndex < 0)
                return;
            if (_componentsGrid.Columns[e.ColumnIndex].Name != "ColSelect")
                return;

            var row = _componentsGrid.Rows[e.RowIndex];
            var component = row.Tag as SelectableSolutionComponent;
            if (component == null || !component.CanSelect)
                return;

            component.IsSelected = (bool)(row.Cells["ColSelect"].Value ?? false);
            UpdateActionState();
        }

        private void UpdateActionState()
        {
            var selectableCount = _componentItems.Count(c => c.CanSelect);
            var alreadyInSolutionCount = _componentItems.Count(c => c.IsAlreadyInSolution);
            var selectedCount = _componentItems.Count(c => c.CanSelect && c.IsSelected);

            _selectAllCheckBox.Enabled = selectableCount > 0;
            if (selectableCount == 0 && _selectAllCheckBox.Checked)
            {
                _suppressEvents = true;
                _selectAllCheckBox.Checked = false;
                _suppressEvents = false;
            }

            if (selectableCount > 0)
            {
                var allSelected = selectedCount == selectableCount;
                if (_selectAllCheckBox.Checked != allSelected)
                {
                    _suppressEvents = true;
                    _selectAllCheckBox.Checked = allSelected;
                    _suppressEvents = false;
                }
            }

            _addSelectedButton.Enabled = SelectedSolutionId.HasValue && selectedCount > 0;
            _summaryLabel.Text = selectedCount + " selected, " + alreadyInSolutionCount + " already in solution";
        }

        private void AddSelectedButton_Click(object sender, EventArgs e)
        {
            if (!SelectedSolutionId.HasValue || string.IsNullOrWhiteSpace(SelectedSolutionUniqueName))
            {
                MessageBox.Show(this, "Please select a solution first.", "Add to solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var selectedComponents = _componentItems
                .Where(c => c.CanSelect && c.IsSelected)
                .ToList();

            if (selectedComponents.Count == 0)
            {
                MessageBox.Show(this, "Please select at least one web resource.", "Add to solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var successCount = 0;
            var failed = new List<string>();

            UseWaitCursor = true;
            try
            {
                foreach (var component in selectedComponents)
                {
                    try
                    {
                        _solutionService.AddComponentToSolution(SelectedSolutionUniqueName, component.ComponentType, component.ComponentId);
                        AddedWebResourceIds.Add(component.ComponentId);
                        successCount++;
                    }
                    catch (Exception ex)
                    {
                        failed.Add(component.Name + ": " + ex.Message);
                    }
                }
            }
            finally
            {
                UseWaitCursor = false;
            }

            if (successCount > 0)
            {
                var summary = "Added " + successCount + " web resource" + (successCount == 1 ? string.Empty : "s") + ".";
                if (failed.Count > 0)
                    summary += "\nFailed: " + failed.Count + ".";

                MessageBox.Show(this, summary, "Add to solution", MessageBoxButtons.OK,
                    failed.Count == 0 ? MessageBoxIcon.Information : MessageBoxIcon.Warning);

                if (failed.Count == 0)
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }
                return;
            }

            MessageBox.Show(this,
                "No web resources were added.\n\n" + string.Join("\n", failed.Take(8)),
                "Add to solution",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }
}
