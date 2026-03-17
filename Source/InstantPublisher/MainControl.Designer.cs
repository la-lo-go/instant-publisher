using System;
using XrmToolBox.Extensibility;


namespace Lalogo.InstantPublisher
{
    partial class MainControl
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle alternatingStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle alternatingStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.WebResourcesGrid = new System.Windows.Forms.DataGridView();
            this.ColWrClose = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColWrFileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColWrWebResource = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColWrType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColWrAuto = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColWrStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColWrLastPublished = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColWrPublish = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.LuckyButton = new System.Windows.Forms.Button();
            this.BrowseAndSelectButton = new System.Windows.Forms.Button();
            this.WrHeaderPanel = new System.Windows.Forms.Panel();
            this.WrCollapseLabel = new System.Windows.Forms.Label();
            this.WrHeaderLabel = new System.Windows.Forms.Label();
            this.PluginsGrid = new System.Windows.Forms.DataGridView();
            this.ColPlFileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPlAuto = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColPlStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPlLastPublished = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPlPublish = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColPlClose = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.AddPluginButton = new System.Windows.Forms.Button();
            this.PlHeaderPanel = new System.Windows.Forms.Panel();
            this.PlCollapseLabel = new System.Windows.Forms.Label();
            this.PlHeaderLabel = new System.Windows.Forms.Label();
            this.BottomPanel = new System.Windows.Forms.Panel();
            this.GitHubLink = new System.Windows.Forms.LinkLabel();
            this.StatusNotificationLabel = new System.Windows.Forms.Label();
            this.PublishAllButton = new System.Windows.Forms.Button();
            this.ExportButton = new System.Windows.Forms.Button();
            this.ImportButton = new System.Windows.Forms.Button();
            this.SaveAssemblyDialog = new System.Windows.Forms.SaveFileDialog();
            this.ActionToolTip = new System.Windows.Forms.ToolTip();
            this.ActionToolTip.AutoPopDelay = 30000;
            this.ActionToolTip.InitialDelay = 300;
            this.ActionToolTip.ReshowDelay = 100;
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WebResourcesGrid)).BeginInit();
            this.panel1.SuspendLayout();
            this.WrHeaderPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PluginsGrid)).BeginInit();
            this.panel2.SuspendLayout();
            this.PlHeaderPanel.SuspendLayout();
            this.BottomPanel.SuspendLayout();
            this.SuspendLayout();
            //
            // splitContainer1
            //
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.splitContainer1.Size = new System.Drawing.Size(941, 530);
            this.splitContainer1.SplitterDistance = 270;
            this.splitContainer1.SplitterWidth = 6;
            this.splitContainer1.TabIndex = 0;
            //
            // splitContainer1.Panel1 - Web Resources
            //
            this.splitContainer1.Panel1.Controls.Add(this.WebResourcesGrid);
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            this.splitContainer1.Panel1.Controls.Add(this.WrHeaderPanel);
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.splitContainer1.Panel1MinSize = 28;
            //
            // splitContainer1.Panel2 - DLLs
            //
            this.splitContainer1.Panel2.Controls.Add(this.PluginsGrid);
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Panel2.Controls.Add(this.PlHeaderPanel);
            this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.splitContainer1.Panel2MinSize = 28;
            //
            // WrHeaderPanel
            //
            this.WrHeaderPanel.BackColor = System.Drawing.Color.FromArgb(74, 144, 217);
            this.WrHeaderPanel.Controls.Add(this.WrCollapseLabel);
            this.WrHeaderPanel.Controls.Add(this.WrHeaderLabel);
            this.WrHeaderPanel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.WrHeaderPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.WrHeaderPanel.Location = new System.Drawing.Point(5, 0);
            this.WrHeaderPanel.Name = "WrHeaderPanel";
            this.WrHeaderPanel.Size = new System.Drawing.Size(931, 28);
            this.WrHeaderPanel.TabIndex = 0;
            this.WrHeaderPanel.Click += new System.EventHandler(this.WrHeaderPanel_Click);
            //
            // WrCollapseLabel
            //
            this.WrCollapseLabel.Dock = System.Windows.Forms.DockStyle.Right;
            this.WrCollapseLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.WrCollapseLabel.ForeColor = System.Drawing.Color.White;
            this.WrCollapseLabel.Location = new System.Drawing.Point(901, 0);
            this.WrCollapseLabel.Name = "WrCollapseLabel";
            this.WrCollapseLabel.Size = new System.Drawing.Size(30, 28);
            this.WrCollapseLabel.TabIndex = 1;
            this.WrCollapseLabel.Text = "\u25B2";
            this.WrCollapseLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.WrCollapseLabel.Click += new System.EventHandler(this.WrHeaderPanel_Click);
            //
            // WrHeaderLabel
            //
            this.WrHeaderLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WrHeaderLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.WrHeaderLabel.ForeColor = System.Drawing.Color.White;
            this.WrHeaderLabel.Location = new System.Drawing.Point(0, 0);
            this.WrHeaderLabel.Name = "WrHeaderLabel";
            this.WrHeaderLabel.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.WrHeaderLabel.Size = new System.Drawing.Size(931, 28);
            this.WrHeaderLabel.TabIndex = 0;
            this.WrHeaderLabel.Text = "Web Resources";
            this.WrHeaderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.WrHeaderLabel.Click += new System.EventHandler(this.WrHeaderPanel_Click);
            //
            // panel1
            //
            this.panel1.Controls.Add(this.LuckyButton);
            this.panel1.Controls.Add(this.BrowseAndSelectButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(5, 28);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(931, 36);
            this.panel1.TabIndex = 1;
            this.panel1.BackColor = System.Drawing.Color.FromArgb(240, 242, 245);
            this.panel1.Padding = new System.Windows.Forms.Padding(4);
            //
            // LuckyButton (Auto map - now first/left)
            //
            this.LuckyButton.Location = new System.Drawing.Point(7, 5);
            this.LuckyButton.Name = "LuckyButton";
            this.LuckyButton.Size = new System.Drawing.Size(120, 26);
            this.LuckyButton.TabIndex = 0;
            this.LuckyButton.Text = "Auto map";
            this.LuckyButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LuckyButton.BackColor = System.Drawing.Color.FromArgb(39, 174, 96);
            this.LuckyButton.ForeColor = System.Drawing.Color.White;
            this.LuckyButton.FlatAppearance.BorderSize = 0;
            this.LuckyButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(30, 150, 80);
            this.LuckyButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(24, 130, 68);
            this.LuckyButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ActionToolTip.SetToolTip(this.LuckyButton, "Auto-match web resource by file name");
            this.LuckyButton.Click += new System.EventHandler(this.LuckyButton_Click);
            //
            // BrowseAndSelectButton (Map manually - now second/right)
            //
            this.BrowseAndSelectButton.Location = new System.Drawing.Point(137, 5);
            this.BrowseAndSelectButton.Name = "BrowseAndSelectButton";
            this.BrowseAndSelectButton.Size = new System.Drawing.Size(150, 26);
            this.BrowseAndSelectButton.TabIndex = 1;
            this.BrowseAndSelectButton.Text = "Map manually";
            this.BrowseAndSelectButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BrowseAndSelectButton.BackColor = System.Drawing.Color.FromArgb(74, 144, 217);
            this.BrowseAndSelectButton.ForeColor = System.Drawing.Color.White;
            this.BrowseAndSelectButton.FlatAppearance.BorderSize = 0;
            this.BrowseAndSelectButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(60, 120, 190);
            this.BrowseAndSelectButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(50, 100, 170);
            this.BrowseAndSelectButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ActionToolTip.SetToolTip(this.BrowseAndSelectButton, "Browse file and pick the web resource manually");
            this.BrowseAndSelectButton.Click += new System.EventHandler(this.BrowseAndSelectButton_Click);
            //
            // WebResourcesGrid
            //
            this.WebResourcesGrid.AllowUserToAddRows = false;
            this.WebResourcesGrid.AllowUserToDeleteRows = false;
            this.WebResourcesGrid.AllowUserToResizeRows = false;
            this.WebResourcesGrid.RowHeadersVisible = false;
            this.WebResourcesGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.WebResourcesGrid.MultiSelect = false;
            this.WebResourcesGrid.BackgroundColor = System.Drawing.Color.White;
            this.WebResourcesGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.WebResourcesGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.WebResourcesGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.WebResourcesGrid.EnableHeadersVisualStyles = false;
            this.WebResourcesGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.WebResourcesGrid.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(240, 242, 245);
            this.WebResourcesGrid.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(100, 100, 100);
            this.WebResourcesGrid.ColumnHeadersDefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(240, 242, 245);
            this.WebResourcesGrid.ColumnHeadersDefaultCellStyle.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.WebResourcesGrid.GridColor = System.Drawing.Color.FromArgb(220, 225, 230);
            this.WebResourcesGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WebResourcesGrid.Location = new System.Drawing.Point(5, 64);
            this.WebResourcesGrid.Name = "WebResourcesGrid";
            this.WebResourcesGrid.ReadOnly = false;
            this.WebResourcesGrid.Size = new System.Drawing.Size(931, 206);
            this.WebResourcesGrid.TabIndex = 2;
            this.WebResourcesGrid.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.WebResourcesGrid.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.WebResourcesGrid.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            this.WebResourcesGrid.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            alternatingStyle1.BackColor = System.Drawing.Color.FromArgb(230, 236, 245);
            alternatingStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(230, 236, 245);
            alternatingStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.WebResourcesGrid.AlternatingRowsDefaultCellStyle = alternatingStyle1;
            this.WebResourcesGrid.RowTemplate.Height = 30;
            this.WebResourcesGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.ColWrFileName,
                this.ColWrWebResource,
                this.ColWrType,
                this.ColWrAuto,
                this.ColWrStatus,
                this.ColWrLastPublished,
                this.ColWrClose,
                this.ColWrPublish});
            this.WebResourcesGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.WebResourcesGrid_CellContentClick);
            this.WebResourcesGrid.CurrentCellDirtyStateChanged += new System.EventHandler(this.WebResourcesGrid_CurrentCellDirtyStateChanged);
            this.WebResourcesGrid.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.WebResourcesGrid_CellValueChanged);
            //
            // ColWrClose
            //
            this.ColWrClose.HeaderText = "";
            this.ColWrClose.Name = "ColWrClose";
            this.ColWrClose.Text = "Remove";
            this.ColWrClose.UseColumnTextForButtonValue = true;
            this.ColWrClose.Width = 60;
            this.ColWrClose.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            //
            // ColWrFileName
            //
            this.ColWrFileName.HeaderText = "File";
            this.ColWrFileName.Name = "ColWrFileName";
            this.ColWrFileName.ReadOnly = true;
            this.ColWrFileName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColWrFileName.FillWeight = 45F;
            //
            // ColWrWebResource
            //
            this.ColWrWebResource.HeaderText = "Web Resource";
            this.ColWrWebResource.Name = "ColWrWebResource";
            this.ColWrWebResource.ReadOnly = true;
            this.ColWrWebResource.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColWrWebResource.FillWeight = 36F;
            //
            // ColWrType
            //
            this.ColWrType.HeaderText = "Type";
            this.ColWrType.Name = "ColWrType";
            this.ColWrType.ReadOnly = true;
            this.ColWrType.Width = 85;
            //
            // ColWrAuto
            //
            this.ColWrAuto.HeaderText = "Auto";
            this.ColWrAuto.Name = "ColWrAuto";
            this.ColWrAuto.Width = 45;
            //
            // ColWrStatus
            //
            this.ColWrStatus.HeaderText = "Status";
            this.ColWrStatus.Name = "ColWrStatus";
            this.ColWrStatus.ReadOnly = true;
            this.ColWrStatus.Width = 80;
            //
            // ColWrLastPublished
            //
            this.ColWrLastPublished.HeaderText = "Last Published";
            this.ColWrLastPublished.Name = "ColWrLastPublished";
            this.ColWrLastPublished.ReadOnly = true;
            this.ColWrLastPublished.Width = 110;
            //
            // ColWrPublish
            //
            this.ColWrPublish.HeaderText = "";
            this.ColWrPublish.Name = "ColWrPublish";
            this.ColWrPublish.Text = "Publish";
            this.ColWrPublish.UseColumnTextForButtonValue = true;
            this.ColWrPublish.Width = 70;
            this.ColWrPublish.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            //
            // PlHeaderPanel
            //
            this.PlHeaderPanel.BackColor = System.Drawing.Color.FromArgb(74, 144, 217);
            this.PlHeaderPanel.Controls.Add(this.PlCollapseLabel);
            this.PlHeaderPanel.Controls.Add(this.PlHeaderLabel);
            this.PlHeaderPanel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PlHeaderPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.PlHeaderPanel.Location = new System.Drawing.Point(5, 0);
            this.PlHeaderPanel.Name = "PlHeaderPanel";
            this.PlHeaderPanel.Size = new System.Drawing.Size(931, 28);
            this.PlHeaderPanel.TabIndex = 0;
            this.PlHeaderPanel.Click += new System.EventHandler(this.PlHeaderPanel_Click);
            //
            // PlCollapseLabel
            //
            this.PlCollapseLabel.Dock = System.Windows.Forms.DockStyle.Right;
            this.PlCollapseLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.PlCollapseLabel.ForeColor = System.Drawing.Color.White;
            this.PlCollapseLabel.Location = new System.Drawing.Point(901, 0);
            this.PlCollapseLabel.Name = "PlCollapseLabel";
            this.PlCollapseLabel.Size = new System.Drawing.Size(30, 28);
            this.PlCollapseLabel.TabIndex = 1;
            this.PlCollapseLabel.Text = "\u25B2";
            this.PlCollapseLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.PlCollapseLabel.Click += new System.EventHandler(this.PlHeaderPanel_Click);
            //
            // PlHeaderLabel
            //
            this.PlHeaderLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PlHeaderLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.PlHeaderLabel.ForeColor = System.Drawing.Color.White;
            this.PlHeaderLabel.Location = new System.Drawing.Point(0, 0);
            this.PlHeaderLabel.Name = "PlHeaderLabel";
            this.PlHeaderLabel.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.PlHeaderLabel.Size = new System.Drawing.Size(931, 28);
            this.PlHeaderLabel.TabIndex = 0;
            this.PlHeaderLabel.Text = "DLLs";
            this.PlHeaderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.PlHeaderLabel.Click += new System.EventHandler(this.PlHeaderPanel_Click);
            //
            // panel2
            //
            this.panel2.Controls.Add(this.AddPluginButton);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(5, 28);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(931, 36);
            this.panel2.TabIndex = 1;
            this.panel2.BackColor = System.Drawing.Color.FromArgb(240, 242, 245);
            this.panel2.Padding = new System.Windows.Forms.Padding(4);
            //
            // AddPluginButton (now green like Auto map)
            //
            this.AddPluginButton.Location = new System.Drawing.Point(7, 5);
            this.AddPluginButton.Margin = new System.Windows.Forms.Padding(0);
            this.AddPluginButton.Name = "AddPluginButton";
            this.AddPluginButton.Size = new System.Drawing.Size(200, 26);
            this.AddPluginButton.TabIndex = 0;
            this.AddPluginButton.Text = "Add DLL...";
            this.AddPluginButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddPluginButton.BackColor = System.Drawing.Color.FromArgb(39, 174, 96);
            this.AddPluginButton.ForeColor = System.Drawing.Color.White;
            this.AddPluginButton.FlatAppearance.BorderSize = 0;
            this.AddPluginButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(30, 150, 80);
            this.AddPluginButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(24, 130, 68);
            this.AddPluginButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ActionToolTip.SetToolTip(this.AddPluginButton, "Browse and add a DLL to monitor");
            this.AddPluginButton.Click += new System.EventHandler(this.AddPluginButton_Click);
            //
            // PluginsGrid
            //
            this.PluginsGrid.AllowUserToAddRows = false;
            this.PluginsGrid.AllowUserToDeleteRows = false;
            this.PluginsGrid.AllowUserToResizeRows = false;
            this.PluginsGrid.RowHeadersVisible = false;
            this.PluginsGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.PluginsGrid.MultiSelect = false;
            this.PluginsGrid.BackgroundColor = System.Drawing.Color.White;
            this.PluginsGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PluginsGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.PluginsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PluginsGrid.EnableHeadersVisualStyles = false;
            this.PluginsGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.PluginsGrid.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(240, 242, 245);
            this.PluginsGrid.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(100, 100, 100);
            this.PluginsGrid.ColumnHeadersDefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(240, 242, 245);
            this.PluginsGrid.ColumnHeadersDefaultCellStyle.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.PluginsGrid.GridColor = System.Drawing.Color.FromArgb(220, 225, 230);
            this.PluginsGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PluginsGrid.Location = new System.Drawing.Point(5, 64);
            this.PluginsGrid.Name = "PluginsGrid";
            this.PluginsGrid.ReadOnly = false;
            this.PluginsGrid.Size = new System.Drawing.Size(931, 200);
            this.PluginsGrid.TabIndex = 2;
            this.PluginsGrid.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.PluginsGrid.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.PluginsGrid.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            this.PluginsGrid.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            alternatingStyle2.BackColor = System.Drawing.Color.FromArgb(230, 236, 245);
            alternatingStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(230, 236, 245);
            alternatingStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.PluginsGrid.AlternatingRowsDefaultCellStyle = alternatingStyle2;
            this.PluginsGrid.RowTemplate.Height = 30;
            this.PluginsGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.ColPlFileName,
                this.ColPlAuto,
                this.ColPlStatus,
                this.ColPlLastPublished,
                this.ColPlClose,
                this.ColPlPublish});
            this.PluginsGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.PluginsGrid_CellContentClick);
            this.PluginsGrid.CurrentCellDirtyStateChanged += new System.EventHandler(this.PluginsGrid_CurrentCellDirtyStateChanged);
            this.PluginsGrid.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.PluginsGrid_CellValueChanged);
            //
            // ColPlFileName
            //
            this.ColPlFileName.HeaderText = "File";
            this.ColPlFileName.Name = "ColPlFileName";
            this.ColPlFileName.ReadOnly = true;
            this.ColPlFileName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColPlFileName.FillWeight = 50F;
            //
            // ColPlAuto
            //
            this.ColPlAuto.HeaderText = "Auto";
            this.ColPlAuto.Name = "ColPlAuto";
            this.ColPlAuto.Width = 40;
            //
            // ColPlStatus
            //
            this.ColPlStatus.HeaderText = "Status";
            this.ColPlStatus.Name = "ColPlStatus";
            this.ColPlStatus.ReadOnly = true;
            this.ColPlStatus.Width = 80;
            //
            // ColPlLastPublished
            //
            this.ColPlLastPublished.HeaderText = "Last Published";
            this.ColPlLastPublished.Name = "ColPlLastPublished";
            this.ColPlLastPublished.ReadOnly = true;
            this.ColPlLastPublished.Width = 110;
            //
            // ColPlPublish
            //
            this.ColPlPublish.HeaderText = "";
            this.ColPlPublish.Name = "ColPlPublish";
            this.ColPlPublish.Text = "Publish";
            this.ColPlPublish.UseColumnTextForButtonValue = true;
            this.ColPlPublish.Width = 70;
            this.ColPlPublish.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            //
            // ColPlClose
            //
            this.ColPlClose.HeaderText = "";
            this.ColPlClose.Name = "ColPlClose";
            this.ColPlClose.Text = "Remove";
            this.ColPlClose.UseColumnTextForButtonValue = true;
            this.ColPlClose.Width = 60;
            this.ColPlClose.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            //
            // BottomPanel
            //
            this.BottomPanel.BackColor = System.Drawing.Color.FromArgb(240, 242, 245);
            this.BottomPanel.Controls.Add(this.GitHubLink);
            this.BottomPanel.Controls.Add(this.StatusNotificationLabel);
            this.BottomPanel.Controls.Add(this.PublishAllButton);
            this.BottomPanel.Controls.Add(this.ExportButton);
            this.BottomPanel.Controls.Add(this.ImportButton);
            this.BottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomPanel.Location = new System.Drawing.Point(0, 530);
            this.BottomPanel.Name = "BottomPanel";
            this.BottomPanel.Size = new System.Drawing.Size(941, 35);
            this.BottomPanel.TabIndex = 1;
            this.BottomPanel.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            //
            // PublishAllButton
            //
            this.PublishAllButton.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
            this.PublishAllButton.Location = new System.Drawing.Point(616, 5);
            this.PublishAllButton.Name = "PublishAllButton";
            this.PublishAllButton.Size = new System.Drawing.Size(110, 25);
            this.PublishAllButton.TabIndex = 3;
            this.PublishAllButton.Text = "Publish All";
            this.PublishAllButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PublishAllButton.BackColor = System.Drawing.Color.FromArgb(74, 144, 217);
            this.PublishAllButton.ForeColor = System.Drawing.Color.White;
            this.PublishAllButton.FlatAppearance.BorderSize = 0;
            this.PublishAllButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(60, 120, 190);
            this.PublishAllButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(50, 100, 170);
            this.PublishAllButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PublishAllButton.Enabled = false;
            this.ActionToolTip.SetToolTip(this.PublishAllButton, "Publish all changed items (Ctrl+Shift+P)");
            this.PublishAllButton.Click += new System.EventHandler(this.PublishAllButton_Click);
            //
            // StatusNotificationLabel
            //
            this.StatusNotificationLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.StatusNotificationLabel.AutoSize = true;
            this.StatusNotificationLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.StatusNotificationLabel.ForeColor = System.Drawing.Color.FromArgb(39, 174, 96);
            this.StatusNotificationLabel.Location = new System.Drawing.Point(80, 9);
            this.StatusNotificationLabel.Name = "StatusNotificationLabel";
            this.StatusNotificationLabel.Size = new System.Drawing.Size(0, 15);
            this.StatusNotificationLabel.TabIndex = 4;
            this.StatusNotificationLabel.Text = "";
            //
            // ExportButton
            //
            this.ExportButton.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
            this.ExportButton.Location = new System.Drawing.Point(731, 5);
            this.ExportButton.Name = "ExportButton";
            this.ExportButton.Size = new System.Drawing.Size(100, 25);
            this.ExportButton.TabIndex = 0;
            this.ExportButton.Text = "\u2B06 Export";
            this.ExportButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExportButton.BackColor = System.Drawing.Color.FromArgb(240, 242, 245);
            this.ExportButton.ForeColor = System.Drawing.Color.FromArgb(80, 80, 80);
            this.ExportButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(200, 200, 200);
            this.ExportButton.FlatAppearance.BorderSize = 1;
            this.ExportButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(220, 225, 230);
            this.ExportButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(200, 205, 210);
            this.ExportButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ExportButton.Enabled = false;
            this.ActionToolTip.SetToolTip(this.ExportButton, "Export monitored items to a JSON file (Ctrl+E)");
            this.ExportButton.Click += new System.EventHandler(this.ExportButton_Click);
            //
            // ImportButton
            //
            this.ImportButton.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
            this.ImportButton.Location = new System.Drawing.Point(836, 5);
            this.ImportButton.Name = "ImportButton";
            this.ImportButton.Size = new System.Drawing.Size(100, 25);
            this.ImportButton.TabIndex = 1;
            this.ImportButton.Text = "\u2B07 Import";
            this.ImportButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ImportButton.BackColor = System.Drawing.Color.FromArgb(240, 242, 245);
            this.ImportButton.ForeColor = System.Drawing.Color.FromArgb(80, 80, 80);
            this.ImportButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(200, 200, 200);
            this.ImportButton.FlatAppearance.BorderSize = 1;
            this.ImportButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(220, 225, 230);
            this.ImportButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(200, 205, 210);
            this.ImportButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ImportButton.Enabled = false;
            this.ActionToolTip.SetToolTip(this.ImportButton, "Import monitored items from a JSON file (Ctrl+I)");
            this.ImportButton.Click += new System.EventHandler(this.ImportButton_Click);
            //
            // GitHubLink
            //
            this.GitHubLink.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.GitHubLink.AutoSize = true;
            this.GitHubLink.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.GitHubLink.LinkColor = System.Drawing.Color.FromArgb(74, 144, 217);
            this.GitHubLink.ActiveLinkColor = System.Drawing.Color.FromArgb(50, 100, 170);
            this.GitHubLink.Location = new System.Drawing.Point(8, 9);
            this.GitHubLink.Name = "GitHubLink";
            this.GitHubLink.Size = new System.Drawing.Size(180, 15);
            this.GitHubLink.TabIndex = 2;
            this.GitHubLink.TabStop = true;
            this.GitHubLink.Text = "GitHub \u2197";
            this.ActionToolTip.SetToolTip(this.GitHubLink, "View source code on GitHub");
            this.GitHubLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.GitHubLink_LinkClicked);
            //
            // SaveAssemblyDialog
            //
            this.SaveAssemblyDialog.DefaultExt = "dll";
            this.SaveAssemblyDialog.Filter = "DLL (*.dll)|*.dll|All files (*.*)|*.*";
            //
            // MainControl
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.BottomPanel);
            this.Name = "MainControl";
            this.Size = new System.Drawing.Size(941, 565);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.WebResourcesGrid)).EndInit();
            this.panel1.ResumeLayout(false);
            this.WrHeaderPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PluginsGrid)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.PlHeaderPanel.ResumeLayout(false);
            this.BottomPanel.ResumeLayout(false);
            this.BottomPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SaveFileDialog SaveAssemblyDialog;
        private System.Windows.Forms.Panel WrHeaderPanel;
        private System.Windows.Forms.Label WrCollapseLabel;
        private System.Windows.Forms.Label WrHeaderLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BrowseAndSelectButton;
        private System.Windows.Forms.Button LuckyButton;
        private System.Windows.Forms.DataGridView WebResourcesGrid;
        private System.Windows.Forms.DataGridViewButtonColumn ColWrClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColWrFileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColWrWebResource;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColWrType;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColWrAuto;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColWrStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColWrLastPublished;
        private System.Windows.Forms.DataGridViewButtonColumn ColWrPublish;
        private System.Windows.Forms.Panel PlHeaderPanel;
        private System.Windows.Forms.Label PlCollapseLabel;
        private System.Windows.Forms.Label PlHeaderLabel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button AddPluginButton;
        private System.Windows.Forms.DataGridView PluginsGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPlFileName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColPlAuto;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPlStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPlLastPublished;
        private System.Windows.Forms.DataGridViewButtonColumn ColPlPublish;
        private System.Windows.Forms.DataGridViewButtonColumn ColPlClose;
        private System.Windows.Forms.Panel BottomPanel;
        private System.Windows.Forms.Button PublishAllButton;
        private System.Windows.Forms.Label StatusNotificationLabel;
        private System.Windows.Forms.Button ExportButton;
        private System.Windows.Forms.Button ImportButton;
        private System.Windows.Forms.LinkLabel GitHubLink;
        private System.Windows.Forms.ToolTip ActionToolTip;
    }
}
