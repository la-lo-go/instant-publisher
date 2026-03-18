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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle97 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle98 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle99 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle100 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle101 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle102 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.WebResourcesGrid = new System.Windows.Forms.DataGridView();
            this.ColWrFileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColWrWebResource = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColWrType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColWrAuto = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColWrStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColWrLastPublished = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColWrClose = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColWrPublish = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.AddToSolutionButton = new System.Windows.Forms.Button();
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
            this.ColPlClose = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColPlPublish = new System.Windows.Forms.DataGridViewButtonColumn();
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
            this.ActionToolTip = new System.Windows.Forms.ToolTip(this.components);
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
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.WebResourcesGrid);
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            this.splitContainer1.Panel1.Controls.Add(this.WrHeaderPanel);
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.splitContainer1.Panel1MinSize = 33;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.PluginsGrid);
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Panel2.Controls.Add(this.PlHeaderPanel);
            this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.splitContainer1.Panel2MinSize = 28;
            this.splitContainer1.Size = new System.Drawing.Size(941, 530);
            this.splitContainer1.SplitterDistance = 270;
            this.splitContainer1.SplitterWidth = 6;
            this.splitContainer1.TabIndex = 0;
            // 
            // WebResourcesGrid
            // 
            this.WebResourcesGrid.AllowUserToAddRows = false;
            this.WebResourcesGrid.AllowUserToDeleteRows = false;
            this.WebResourcesGrid.AllowUserToResizeRows = false;
            dataGridViewCellStyle97.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(236)))), ((int)(((byte)(245)))));
            dataGridViewCellStyle97.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(236)))), ((int)(((byte)(245)))));
            dataGridViewCellStyle97.SelectionForeColor = System.Drawing.Color.Black;
            this.WebResourcesGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle97;
            this.WebResourcesGrid.BackgroundColor = System.Drawing.Color.White;
            this.WebResourcesGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.WebResourcesGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.WebResourcesGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle98.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle98.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            dataGridViewCellStyle98.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle98.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            dataGridViewCellStyle98.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            dataGridViewCellStyle98.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            dataGridViewCellStyle98.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle98.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.WebResourcesGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle98;
            this.WebResourcesGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.WebResourcesGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColWrFileName,
            this.ColWrWebResource,
            this.ColWrType,
            this.ColWrAuto,
            this.ColWrStatus,
            this.ColWrLastPublished,
            this.ColWrClose,
            this.ColWrPublish});
            dataGridViewCellStyle99.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle99.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle99.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle99.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle99.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            dataGridViewCellStyle99.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle99.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle99.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.WebResourcesGrid.DefaultCellStyle = dataGridViewCellStyle99;
            this.WebResourcesGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WebResourcesGrid.EnableHeadersVisualStyles = false;
            this.WebResourcesGrid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(225)))), ((int)(((byte)(230)))));
            this.WebResourcesGrid.Location = new System.Drawing.Point(5, 69);
            this.WebResourcesGrid.MultiSelect = false;
            this.WebResourcesGrid.Name = "WebResourcesGrid";
            this.WebResourcesGrid.RowHeadersVisible = false;
            this.WebResourcesGrid.RowTemplate.Height = 30;
            this.WebResourcesGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.WebResourcesGrid.Size = new System.Drawing.Size(931, 201);
            this.WebResourcesGrid.TabIndex = 2;
            this.WebResourcesGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.WebResourcesGrid_CellContentClick);
            this.WebResourcesGrid.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.WebResourcesGrid_CellValueChanged);
            this.WebResourcesGrid.CurrentCellDirtyStateChanged += new System.EventHandler(this.WebResourcesGrid_CurrentCellDirtyStateChanged);
            // 
            // ColWrFileName
            // 
            this.ColWrFileName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColWrFileName.FillWeight = 45F;
            this.ColWrFileName.HeaderText = "File";
            this.ColWrFileName.Name = "ColWrFileName";
            this.ColWrFileName.ReadOnly = true;
            // 
            // ColWrWebResource
            // 
            this.ColWrWebResource.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColWrWebResource.FillWeight = 36F;
            this.ColWrWebResource.HeaderText = "Web Resource";
            this.ColWrWebResource.Name = "ColWrWebResource";
            this.ColWrWebResource.ReadOnly = true;
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
            // ColWrClose
            // 
            this.ColWrClose.HeaderText = "";
            this.ColWrClose.Name = "ColWrClose";
            this.ColWrClose.Text = "Remove";
            this.ColWrClose.UseColumnTextForButtonValue = true;
            this.ColWrClose.Width = 60;
            // 
            // ColWrPublish
            // 
            this.ColWrPublish.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ColWrPublish.HeaderText = "";
            this.ColWrPublish.Name = "ColWrPublish";
            this.ColWrPublish.Text = "Publish";
            this.ColWrPublish.UseColumnTextForButtonValue = true;
            this.ColWrPublish.Width = 70;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.panel1.Controls.Add(this.AddToSolutionButton);
            this.panel1.Controls.Add(this.LuckyButton);
            this.panel1.Controls.Add(this.BrowseAndSelectButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(5, 33);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(4);
            this.panel1.Size = new System.Drawing.Size(931, 36);
            this.panel1.TabIndex = 1;
            // 
            // AddToSolutionButton
            // 
            this.AddToSolutionButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AddToSolutionButton.BackColor = System.Drawing.Color.DarkOrange;
            this.AddToSolutionButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AddToSolutionButton.FlatAppearance.BorderSize = 0;
            this.AddToSolutionButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(84)))), ((int)(((byte)(0)))));
            this.AddToSolutionButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(126)))), ((int)(((byte)(34)))));
            this.AddToSolutionButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddToSolutionButton.ForeColor = System.Drawing.Color.White;
            this.AddToSolutionButton.Location = new System.Drawing.Point(805, 5);
            this.AddToSolutionButton.Name = "AddToSolutionButton";
            this.AddToSolutionButton.Size = new System.Drawing.Size(119, 26);
            this.AddToSolutionButton.TabIndex = 2;
            this.AddToSolutionButton.Text = "Add to solution";
            this.ActionToolTip.SetToolTip(this.AddToSolutionButton, "Add monitored web resources to a solution");
            this.AddToSolutionButton.UseVisualStyleBackColor = false;
            this.AddToSolutionButton.Click += new System.EventHandler(this.AddToSolutionButton_Click);
            // 
            // LuckyButton
            // 
            this.LuckyButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.LuckyButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LuckyButton.FlatAppearance.BorderSize = 0;
            this.LuckyButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(130)))), ((int)(((byte)(68)))));
            this.LuckyButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(150)))), ((int)(((byte)(80)))));
            this.LuckyButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LuckyButton.ForeColor = System.Drawing.Color.White;
            this.LuckyButton.Location = new System.Drawing.Point(7, 5);
            this.LuckyButton.Name = "LuckyButton";
            this.LuckyButton.Size = new System.Drawing.Size(120, 26);
            this.LuckyButton.TabIndex = 0;
            this.LuckyButton.Text = "Smart add";
            this.ActionToolTip.SetToolTip(this.LuckyButton, "Auto-match web resource by file name");
            this.LuckyButton.UseVisualStyleBackColor = false;
            this.LuckyButton.Click += new System.EventHandler(this.LuckyButton_Click);
            // 
            // BrowseAndSelectButton
            // 
            this.BrowseAndSelectButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(144)))), ((int)(((byte)(217)))));
            this.BrowseAndSelectButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BrowseAndSelectButton.FlatAppearance.BorderSize = 0;
            this.BrowseAndSelectButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(100)))), ((int)(((byte)(170)))));
            this.BrowseAndSelectButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(120)))), ((int)(((byte)(190)))));
            this.BrowseAndSelectButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BrowseAndSelectButton.ForeColor = System.Drawing.Color.White;
            this.BrowseAndSelectButton.Location = new System.Drawing.Point(137, 5);
            this.BrowseAndSelectButton.Name = "BrowseAndSelectButton";
            this.BrowseAndSelectButton.Size = new System.Drawing.Size(150, 26);
            this.BrowseAndSelectButton.TabIndex = 1;
            this.BrowseAndSelectButton.Text = "Manual add";
            this.ActionToolTip.SetToolTip(this.BrowseAndSelectButton, "Browse file and pick the web resource manually");
            this.BrowseAndSelectButton.UseVisualStyleBackColor = false;
            this.BrowseAndSelectButton.Click += new System.EventHandler(this.BrowseAndSelectButton_Click);
            // 
            // WrHeaderPanel
            // 
            this.WrHeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(144)))), ((int)(((byte)(217)))));
            this.WrHeaderPanel.Controls.Add(this.WrCollapseLabel);
            this.WrHeaderPanel.Controls.Add(this.WrHeaderLabel);
            this.WrHeaderPanel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.WrHeaderPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.WrHeaderPanel.Location = new System.Drawing.Point(5, 5);
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
            this.WrCollapseLabel.Text = "▲";
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
            // PluginsGrid
            // 
            this.PluginsGrid.AllowUserToAddRows = false;
            this.PluginsGrid.AllowUserToDeleteRows = false;
            this.PluginsGrid.AllowUserToResizeRows = false;
            dataGridViewCellStyle100.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(236)))), ((int)(((byte)(245)))));
            dataGridViewCellStyle100.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(236)))), ((int)(((byte)(245)))));
            dataGridViewCellStyle100.SelectionForeColor = System.Drawing.Color.Black;
            this.PluginsGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle100;
            this.PluginsGrid.BackgroundColor = System.Drawing.Color.White;
            this.PluginsGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PluginsGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.PluginsGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle101.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle101.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            dataGridViewCellStyle101.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle101.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            dataGridViewCellStyle101.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            dataGridViewCellStyle101.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            dataGridViewCellStyle101.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle101.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.PluginsGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle101;
            this.PluginsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PluginsGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColPlFileName,
            this.ColPlAuto,
            this.ColPlStatus,
            this.ColPlLastPublished,
            this.ColPlClose,
            this.ColPlPublish});
            dataGridViewCellStyle102.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle102.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle102.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle102.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle102.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            dataGridViewCellStyle102.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle102.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle102.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.PluginsGrid.DefaultCellStyle = dataGridViewCellStyle102;
            this.PluginsGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PluginsGrid.EnableHeadersVisualStyles = false;
            this.PluginsGrid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(225)))), ((int)(((byte)(230)))));
            this.PluginsGrid.Location = new System.Drawing.Point(5, 64);
            this.PluginsGrid.MultiSelect = false;
            this.PluginsGrid.Name = "PluginsGrid";
            this.PluginsGrid.RowHeadersVisible = false;
            this.PluginsGrid.RowTemplate.Height = 30;
            this.PluginsGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.PluginsGrid.Size = new System.Drawing.Size(931, 190);
            this.PluginsGrid.TabIndex = 2;
            this.PluginsGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.PluginsGrid_CellContentClick);
            this.PluginsGrid.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.PluginsGrid_CellValueChanged);
            this.PluginsGrid.CurrentCellDirtyStateChanged += new System.EventHandler(this.PluginsGrid_CurrentCellDirtyStateChanged);
            // 
            // ColPlFileName
            // 
            this.ColPlFileName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColPlFileName.FillWeight = 50F;
            this.ColPlFileName.HeaderText = "File";
            this.ColPlFileName.Name = "ColPlFileName";
            this.ColPlFileName.ReadOnly = true;
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
            // ColPlClose
            // 
            this.ColPlClose.HeaderText = "";
            this.ColPlClose.Name = "ColPlClose";
            this.ColPlClose.Text = "Remove";
            this.ColPlClose.UseColumnTextForButtonValue = true;
            this.ColPlClose.Width = 60;
            // 
            // ColPlPublish
            // 
            this.ColPlPublish.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ColPlPublish.HeaderText = "";
            this.ColPlPublish.Name = "ColPlPublish";
            this.ColPlPublish.Text = "Publish";
            this.ColPlPublish.UseColumnTextForButtonValue = true;
            this.ColPlPublish.Width = 70;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.panel2.Controls.Add(this.AddPluginButton);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(5, 28);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(4);
            this.panel2.Size = new System.Drawing.Size(931, 36);
            this.panel2.TabIndex = 1;
            // 
            // AddPluginButton
            // 
            this.AddPluginButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.AddPluginButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AddPluginButton.FlatAppearance.BorderSize = 0;
            this.AddPluginButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(130)))), ((int)(((byte)(68)))));
            this.AddPluginButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(150)))), ((int)(((byte)(80)))));
            this.AddPluginButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddPluginButton.ForeColor = System.Drawing.Color.White;
            this.AddPluginButton.Location = new System.Drawing.Point(7, 5);
            this.AddPluginButton.Margin = new System.Windows.Forms.Padding(0);
            this.AddPluginButton.Name = "AddPluginButton";
            this.AddPluginButton.Size = new System.Drawing.Size(200, 26);
            this.AddPluginButton.TabIndex = 0;
            this.AddPluginButton.Text = "Add DLL...";
            this.ActionToolTip.SetToolTip(this.AddPluginButton, "Browse and add a DLL to monitor");
            this.AddPluginButton.UseVisualStyleBackColor = false;
            this.AddPluginButton.Click += new System.EventHandler(this.AddPluginButton_Click);
            // 
            // PlHeaderPanel
            // 
            this.PlHeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(144)))), ((int)(((byte)(217)))));
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
            this.PlCollapseLabel.Text = "▲";
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
            // BottomPanel
            // 
            this.BottomPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.BottomPanel.Controls.Add(this.GitHubLink);
            this.BottomPanel.Controls.Add(this.StatusNotificationLabel);
            this.BottomPanel.Controls.Add(this.PublishAllButton);
            this.BottomPanel.Controls.Add(this.ExportButton);
            this.BottomPanel.Controls.Add(this.ImportButton);
            this.BottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomPanel.Location = new System.Drawing.Point(0, 530);
            this.BottomPanel.Name = "BottomPanel";
            this.BottomPanel.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.BottomPanel.Size = new System.Drawing.Size(941, 35);
            this.BottomPanel.TabIndex = 1;
            // 
            // GitHubLink
            // 
            this.GitHubLink.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(100)))), ((int)(((byte)(170)))));
            this.GitHubLink.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.GitHubLink.AutoSize = true;
            this.GitHubLink.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.GitHubLink.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(144)))), ((int)(((byte)(217)))));
            this.GitHubLink.Location = new System.Drawing.Point(8, 9);
            this.GitHubLink.Name = "GitHubLink";
            this.GitHubLink.Size = new System.Drawing.Size(57, 15);
            this.GitHubLink.TabIndex = 2;
            this.GitHubLink.TabStop = true;
            this.GitHubLink.Text = "GitHub ↗";
            this.ActionToolTip.SetToolTip(this.GitHubLink, "View source code on GitHub");
            this.GitHubLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.GitHubLink_LinkClicked);
            // 
            // StatusNotificationLabel
            // 
            this.StatusNotificationLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.StatusNotificationLabel.AutoSize = true;
            this.StatusNotificationLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.StatusNotificationLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.StatusNotificationLabel.Location = new System.Drawing.Point(80, 9);
            this.StatusNotificationLabel.Name = "StatusNotificationLabel";
            this.StatusNotificationLabel.Size = new System.Drawing.Size(0, 15);
            this.StatusNotificationLabel.TabIndex = 4;
            // 
            // PublishAllButton
            // 
            this.PublishAllButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PublishAllButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(144)))), ((int)(((byte)(217)))));
            this.PublishAllButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PublishAllButton.Enabled = false;
            this.PublishAllButton.FlatAppearance.BorderSize = 0;
            this.PublishAllButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(100)))), ((int)(((byte)(170)))));
            this.PublishAllButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(120)))), ((int)(((byte)(190)))));
            this.PublishAllButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PublishAllButton.ForeColor = System.Drawing.Color.White;
            this.PublishAllButton.Location = new System.Drawing.Point(826, 5);
            this.PublishAllButton.Name = "PublishAllButton";
            this.PublishAllButton.Size = new System.Drawing.Size(110, 25);
            this.PublishAllButton.TabIndex = 3;
            this.PublishAllButton.Text = "Publish All";
            this.ActionToolTip.SetToolTip(this.PublishAllButton, "Publish all changed items (Ctrl+Shift+P)");
            this.PublishAllButton.UseVisualStyleBackColor = false;
            this.PublishAllButton.Click += new System.EventHandler(this.PublishAllButton_Click);
            // 
            // ExportButton
            // 
            this.ExportButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ExportButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.ExportButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ExportButton.Enabled = false;
            this.ExportButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.ExportButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(205)))), ((int)(((byte)(210)))));
            this.ExportButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(225)))), ((int)(((byte)(230)))));
            this.ExportButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExportButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.ExportButton.Location = new System.Drawing.Point(616, 5);
            this.ExportButton.Name = "ExportButton";
            this.ExportButton.Size = new System.Drawing.Size(100, 25);
            this.ExportButton.TabIndex = 0;
            this.ExportButton.Text = "⬆ Export";
            this.ActionToolTip.SetToolTip(this.ExportButton, "Export monitored items to a JSON file (Ctrl+E)");
            this.ExportButton.UseVisualStyleBackColor = false;
            this.ExportButton.Click += new System.EventHandler(this.ExportButton_Click);
            // 
            // ImportButton
            // 
            this.ImportButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ImportButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.ImportButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ImportButton.Enabled = false;
            this.ImportButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.ImportButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(205)))), ((int)(((byte)(210)))));
            this.ImportButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(225)))), ((int)(((byte)(230)))));
            this.ImportButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ImportButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.ImportButton.Location = new System.Drawing.Point(721, 5);
            this.ImportButton.Name = "ImportButton";
            this.ImportButton.Size = new System.Drawing.Size(100, 25);
            this.ImportButton.TabIndex = 1;
            this.ImportButton.Text = "⬇ Import";
            this.ActionToolTip.SetToolTip(this.ImportButton, "Import monitored items from a JSON file (Ctrl+I)");
            this.ImportButton.UseVisualStyleBackColor = false;
            this.ImportButton.Click += new System.EventHandler(this.ImportButton_Click);
            // 
            // SaveAssemblyDialog
            // 
            this.SaveAssemblyDialog.DefaultExt = "dll";
            this.SaveAssemblyDialog.Filter = "DLL (*.dll)|*.dll|All files (*.*)|*.*";
            // 
            // ActionToolTip
            // 
            this.ActionToolTip.AutoPopDelay = 30000;
            this.ActionToolTip.InitialDelay = 300;
            this.ActionToolTip.ReshowDelay = 100;
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
        private System.Windows.Forms.Button AddToSolutionButton;
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
