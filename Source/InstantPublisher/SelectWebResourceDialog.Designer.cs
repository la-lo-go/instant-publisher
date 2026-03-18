namespace Lalogo.InstantPublisher
{
    partial class SelectWebResourceDialog
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.RootPanel = new System.Windows.Forms.TableLayoutPanel();
            this.ContentPanel = new System.Windows.Forms.TableLayoutPanel();
            this.FilterSearchPanel = new System.Windows.Forms.TableLayoutPanel();
            this.FilterFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.HtmlFilterBox = new System.Windows.Forms.CheckBox();
            this.ScriptsFilterBox = new System.Windows.Forms.CheckBox();
            this.StylesFilterBox = new System.Windows.Forms.CheckBox();
            this.ImagesFilterBox = new System.Windows.Forms.CheckBox();
            this.XmlFilterBox = new System.Windows.Forms.CheckBox();
            this.OtherFilterBox = new System.Windows.Forms.CheckBox();
            this.SearchPanel = new System.Windows.Forms.Panel();
            this.SearchTextBox = new System.Windows.Forms.TextBox();
            this.SearchLabel = new System.Windows.Forms.Label();
            this.TreeContainerPanel = new System.Windows.Forms.Panel();
            this.WebResourceTree = new System.Windows.Forms.TreeView();
            this.IconsList = new System.Windows.Forms.ImageList(this.components);
            this.BottomPanel = new System.Windows.Forms.TableLayoutPanel();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.SelectButton = new System.Windows.Forms.Button();
            this.SelectionHintLabel = new System.Windows.Forms.Label();
            this.RootPanel.SuspendLayout();
            this.ContentPanel.SuspendLayout();
            this.FilterSearchPanel.SuspendLayout();
            this.FilterFlowPanel.SuspendLayout();
            this.SearchPanel.SuspendLayout();
            this.TreeContainerPanel.SuspendLayout();
            this.BottomPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // RootPanel
            // 
            this.RootPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.RootPanel.ColumnCount = 1;
            this.RootPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.RootPanel.Controls.Add(this.ContentPanel, 0, 1);
            this.RootPanel.Controls.Add(this.BottomPanel, 0, 2);
            this.RootPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RootPanel.Location = new System.Drawing.Point(0, 0);
            this.RootPanel.Name = "RootPanel";
            this.RootPanel.Padding = new System.Windows.Forms.Padding(12);
            this.RootPanel.RowCount = 3;
            this.RootPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.RootPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.RootPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.RootPanel.Size = new System.Drawing.Size(760, 560);
            this.RootPanel.TabIndex = 0;
            // 
            // ContentPanel
            // 
            this.ContentPanel.BackColor = System.Drawing.Color.White;
            this.ContentPanel.ColumnCount = 1;
            this.ContentPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ContentPanel.Controls.Add(this.FilterSearchPanel, 0, 0);
            this.ContentPanel.Controls.Add(this.TreeContainerPanel, 0, 1);
            this.ContentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ContentPanel.Location = new System.Drawing.Point(12, 12);
            this.ContentPanel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.ContentPanel.Name = "ContentPanel";
            this.ContentPanel.Padding = new System.Windows.Forms.Padding(10);
            this.ContentPanel.RowCount = 2;
            this.ContentPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.ContentPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ContentPanel.Size = new System.Drawing.Size(736, 488);
            this.ContentPanel.TabIndex = 1;
            // 
            // FilterSearchPanel
            // 
            this.FilterSearchPanel.ColumnCount = 2;
            this.FilterSearchPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.FilterSearchPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 250F));
            this.FilterSearchPanel.Controls.Add(this.FilterFlowPanel, 0, 0);
            this.FilterSearchPanel.Controls.Add(this.SearchPanel, 1, 0);
            this.FilterSearchPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FilterSearchPanel.Location = new System.Drawing.Point(10, 10);
            this.FilterSearchPanel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.FilterSearchPanel.Name = "FilterSearchPanel";
            this.FilterSearchPanel.RowCount = 1;
            this.FilterSearchPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.FilterSearchPanel.Size = new System.Drawing.Size(716, 32);
            this.FilterSearchPanel.TabIndex = 0;
            // 
            // FilterFlowPanel
            // 
            this.FilterFlowPanel.Controls.Add(this.HtmlFilterBox);
            this.FilterFlowPanel.Controls.Add(this.ScriptsFilterBox);
            this.FilterFlowPanel.Controls.Add(this.StylesFilterBox);
            this.FilterFlowPanel.Controls.Add(this.ImagesFilterBox);
            this.FilterFlowPanel.Controls.Add(this.XmlFilterBox);
            this.FilterFlowPanel.Controls.Add(this.OtherFilterBox);
            this.FilterFlowPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FilterFlowPanel.Location = new System.Drawing.Point(0, 0);
            this.FilterFlowPanel.Margin = new System.Windows.Forms.Padding(0);
            this.FilterFlowPanel.Name = "FilterFlowPanel";
            this.FilterFlowPanel.Size = new System.Drawing.Size(466, 32);
            this.FilterFlowPanel.TabIndex = 0;
            this.FilterFlowPanel.WrapContents = false;
            // 
            // HtmlFilterBox
            // 
            this.HtmlFilterBox.AutoSize = true;
            this.HtmlFilterBox.Checked = true;
            this.HtmlFilterBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.HtmlFilterBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(75)))));
            this.HtmlFilterBox.Location = new System.Drawing.Point(0, 5);
            this.HtmlFilterBox.Margin = new System.Windows.Forms.Padding(0, 5, 12, 0);
            this.HtmlFilterBox.Name = "HtmlFilterBox";
            this.HtmlFilterBox.Size = new System.Drawing.Size(58, 19);
            this.HtmlFilterBox.TabIndex = 0;
            this.HtmlFilterBox.Text = "HTML";
            this.HtmlFilterBox.UseVisualStyleBackColor = true;
            this.HtmlFilterBox.CheckedChanged += new System.EventHandler(this.FilterBox_CheckedChanged);
            // 
            // ScriptsFilterBox
            // 
            this.ScriptsFilterBox.AutoSize = true;
            this.ScriptsFilterBox.Checked = true;
            this.ScriptsFilterBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ScriptsFilterBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(75)))));
            this.ScriptsFilterBox.Location = new System.Drawing.Point(70, 5);
            this.ScriptsFilterBox.Margin = new System.Windows.Forms.Padding(0, 5, 12, 0);
            this.ScriptsFilterBox.Name = "ScriptsFilterBox";
            this.ScriptsFilterBox.Size = new System.Drawing.Size(61, 19);
            this.ScriptsFilterBox.TabIndex = 1;
            this.ScriptsFilterBox.Text = "Scripts";
            this.ScriptsFilterBox.UseVisualStyleBackColor = true;
            this.ScriptsFilterBox.CheckedChanged += new System.EventHandler(this.FilterBox_CheckedChanged);
            // 
            // StylesFilterBox
            // 
            this.StylesFilterBox.AutoSize = true;
            this.StylesFilterBox.Checked = true;
            this.StylesFilterBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.StylesFilterBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(75)))));
            this.StylesFilterBox.Location = new System.Drawing.Point(143, 5);
            this.StylesFilterBox.Margin = new System.Windows.Forms.Padding(0, 5, 12, 0);
            this.StylesFilterBox.Name = "StylesFilterBox";
            this.StylesFilterBox.Size = new System.Drawing.Size(56, 19);
            this.StylesFilterBox.TabIndex = 2;
            this.StylesFilterBox.Text = "Styles";
            this.StylesFilterBox.UseVisualStyleBackColor = true;
            this.StylesFilterBox.CheckedChanged += new System.EventHandler(this.FilterBox_CheckedChanged);
            // 
            // ImagesFilterBox
            // 
            this.ImagesFilterBox.AutoSize = true;
            this.ImagesFilterBox.Checked = true;
            this.ImagesFilterBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ImagesFilterBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(75)))));
            this.ImagesFilterBox.Location = new System.Drawing.Point(211, 5);
            this.ImagesFilterBox.Margin = new System.Windows.Forms.Padding(0, 5, 12, 0);
            this.ImagesFilterBox.Name = "ImagesFilterBox";
            this.ImagesFilterBox.Size = new System.Drawing.Size(64, 19);
            this.ImagesFilterBox.TabIndex = 3;
            this.ImagesFilterBox.Text = "Images";
            this.ImagesFilterBox.UseVisualStyleBackColor = true;
            this.ImagesFilterBox.CheckedChanged += new System.EventHandler(this.FilterBox_CheckedChanged);
            // 
            // XmlFilterBox
            // 
            this.XmlFilterBox.AutoSize = true;
            this.XmlFilterBox.Checked = true;
            this.XmlFilterBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.XmlFilterBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(75)))));
            this.XmlFilterBox.Location = new System.Drawing.Point(287, 5);
            this.XmlFilterBox.Margin = new System.Windows.Forms.Padding(0, 5, 12, 0);
            this.XmlFilterBox.Name = "XmlFilterBox";
            this.XmlFilterBox.Size = new System.Drawing.Size(50, 19);
            this.XmlFilterBox.TabIndex = 4;
            this.XmlFilterBox.Text = "XML";
            this.XmlFilterBox.UseVisualStyleBackColor = true;
            this.XmlFilterBox.CheckedChanged += new System.EventHandler(this.FilterBox_CheckedChanged);
            // 
            // OtherFilterBox
            // 
            this.OtherFilterBox.AutoSize = true;
            this.OtherFilterBox.Checked = true;
            this.OtherFilterBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.OtherFilterBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(75)))));
            this.OtherFilterBox.Location = new System.Drawing.Point(349, 5);
            this.OtherFilterBox.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.OtherFilterBox.Name = "OtherFilterBox";
            this.OtherFilterBox.Size = new System.Drawing.Size(56, 19);
            this.OtherFilterBox.TabIndex = 5;
            this.OtherFilterBox.Text = "Other";
            this.OtherFilterBox.UseVisualStyleBackColor = true;
            this.OtherFilterBox.CheckedChanged += new System.EventHandler(this.FilterBox_CheckedChanged);
            // 
            // SearchPanel
            // 
            this.SearchPanel.Controls.Add(this.SearchTextBox);
            this.SearchPanel.Controls.Add(this.SearchLabel);
            this.SearchPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SearchPanel.Location = new System.Drawing.Point(466, 0);
            this.SearchPanel.Margin = new System.Windows.Forms.Padding(0);
            this.SearchPanel.Name = "SearchPanel";
            this.SearchPanel.Size = new System.Drawing.Size(250, 32);
            this.SearchPanel.TabIndex = 1;
            // 
            // SearchTextBox
            // 
            this.SearchTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SearchTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SearchTextBox.Location = new System.Drawing.Point(61, 4);
            this.SearchTextBox.Name = "SearchTextBox";
            this.SearchTextBox.Size = new System.Drawing.Size(186, 23);
            this.SearchTextBox.TabIndex = 1;
            this.SearchTextBox.TextChanged += new System.EventHandler(this.SearchTextBox_TextChanged);
            // 
            // SearchLabel
            // 
            this.SearchLabel.AutoSize = true;
            this.SearchLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.SearchLabel.Location = new System.Drawing.Point(4, 8);
            this.SearchLabel.Name = "SearchLabel";
            this.SearchLabel.Size = new System.Drawing.Size(42, 15);
            this.SearchLabel.TabIndex = 0;
            this.SearchLabel.Text = "Search";
            // 
            // TreeContainerPanel
            // 
            this.TreeContainerPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(225)))), ((int)(((byte)(230)))));
            this.TreeContainerPanel.Controls.Add(this.WebResourceTree);
            this.TreeContainerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TreeContainerPanel.Location = new System.Drawing.Point(10, 50);
            this.TreeContainerPanel.Margin = new System.Windows.Forms.Padding(0);
            this.TreeContainerPanel.Name = "TreeContainerPanel";
            this.TreeContainerPanel.Padding = new System.Windows.Forms.Padding(1);
            this.TreeContainerPanel.Size = new System.Drawing.Size(716, 428);
            this.TreeContainerPanel.TabIndex = 1;
            // 
            // WebResourceTree
            // 
            this.WebResourceTree.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.WebResourceTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WebResourceTree.ImageIndex = 0;
            this.WebResourceTree.ImageList = this.IconsList;
            this.WebResourceTree.Location = new System.Drawing.Point(1, 1);
            this.WebResourceTree.Margin = new System.Windows.Forms.Padding(0);
            this.WebResourceTree.Name = "WebResourceTree";
            this.WebResourceTree.SelectedImageIndex = 0;
            this.WebResourceTree.Size = new System.Drawing.Size(714, 426);
            this.WebResourceTree.TabIndex = 0;
            this.WebResourceTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.WebResourceTree_AfterSelect);
            this.WebResourceTree.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.WebResourceTree_NodeMouseDoubleClick);
            // 
            // IconsList
            // 
            this.IconsList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.IconsList.ImageSize = new System.Drawing.Size(16, 16);
            this.IconsList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // BottomPanel
            // 
            this.BottomPanel.BackColor = System.Drawing.Color.White;
            this.BottomPanel.ColumnCount = 3;
            this.BottomPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.BottomPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.BottomPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.BottomPanel.Controls.Add(this.CancelBtn, 2, 0);
            this.BottomPanel.Controls.Add(this.SelectButton, 1, 0);
            this.BottomPanel.Controls.Add(this.SelectionHintLabel, 0, 0);
            this.BottomPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BottomPanel.Location = new System.Drawing.Point(12, 508);
            this.BottomPanel.Margin = new System.Windows.Forms.Padding(0);
            this.BottomPanel.Name = "BottomPanel";
            this.BottomPanel.Padding = new System.Windows.Forms.Padding(10, 8, 10, 8);
            this.BottomPanel.RowCount = 1;
            this.BottomPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.BottomPanel.Size = new System.Drawing.Size(736, 40);
            this.BottomPanel.TabIndex = 2;
            // 
            // CancelBtn
            // 
            this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.CancelBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(238)))), ((int)(((byte)(242)))));
            this.CancelBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.CancelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CancelBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.CancelBtn.Location = new System.Drawing.Point(645, 8);
            this.CancelBtn.Margin = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(81, 24);
            this.CancelBtn.TabIndex = 2;
            this.CancelBtn.Text = "Cancel";
            this.CancelBtn.UseVisualStyleBackColor = false;
            // 
            // SelectButton
            // 
            this.SelectButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(144)))), ((int)(((byte)(217)))));
            this.SelectButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.SelectButton.Enabled = false;
            this.SelectButton.FlatAppearance.BorderSize = 0;
            this.SelectButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(100)))), ((int)(((byte)(170)))));
            this.SelectButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(120)))), ((int)(((byte)(190)))));
            this.SelectButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SelectButton.ForeColor = System.Drawing.Color.White;
            this.SelectButton.Location = new System.Drawing.Point(544, 8);
            this.SelectButton.Margin = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.SelectButton.Name = "SelectButton";
            this.SelectButton.Size = new System.Drawing.Size(93, 24);
            this.SelectButton.TabIndex = 1;
            this.SelectButton.Text = "Select";
            this.SelectButton.UseVisualStyleBackColor = false;
            this.SelectButton.Click += new System.EventHandler(this.SelectWebResource);
            // 
            // SelectionHintLabel
            // 
            this.SelectionHintLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.SelectionHintLabel.AutoSize = true;
            this.SelectionHintLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.SelectionHintLabel.Location = new System.Drawing.Point(10, 12);
            this.SelectionHintLabel.Margin = new System.Windows.Forms.Padding(0);
            this.SelectionHintLabel.Name = "SelectionHintLabel";
            this.SelectionHintLabel.Size = new System.Drawing.Size(223, 15);
            this.SelectionHintLabel.TabIndex = 0;
            this.SelectionHintLabel.Text = "Select a leaf node to enable confirmation";
            // 
            // SelectWebResourceDialog
            // 
            this.AcceptButton = this.SelectButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.CancelButton = this.CancelBtn;
            this.ClientSize = new System.Drawing.Size(760, 560);
            this.Controls.Add(this.RootPanel);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SelectWebResourceDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Select Web Resource";
            this.RootPanel.ResumeLayout(false);
            this.ContentPanel.ResumeLayout(false);
            this.FilterSearchPanel.ResumeLayout(false);
            this.FilterFlowPanel.ResumeLayout(false);
            this.FilterFlowPanel.PerformLayout();
            this.SearchPanel.ResumeLayout(false);
            this.SearchPanel.PerformLayout();
            this.TreeContainerPanel.ResumeLayout(false);
            this.BottomPanel.ResumeLayout(false);
            this.BottomPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel RootPanel;
        private System.Windows.Forms.TableLayoutPanel ContentPanel;
        private System.Windows.Forms.TableLayoutPanel FilterSearchPanel;
        private System.Windows.Forms.FlowLayoutPanel FilterFlowPanel;
        private System.Windows.Forms.Panel SearchPanel;
        private System.Windows.Forms.TextBox SearchTextBox;
        private System.Windows.Forms.Label SearchLabel;
        private System.Windows.Forms.Panel TreeContainerPanel;
        private System.Windows.Forms.TableLayoutPanel BottomPanel;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.Button SelectButton;
        private System.Windows.Forms.Label SelectionHintLabel;
        private System.Windows.Forms.TreeView WebResourceTree;
        private System.Windows.Forms.ImageList IconsList;
        private System.Windows.Forms.CheckBox HtmlFilterBox;
        private System.Windows.Forms.CheckBox ScriptsFilterBox;
        private System.Windows.Forms.CheckBox StylesFilterBox;
        private System.Windows.Forms.CheckBox ImagesFilterBox;
        private System.Windows.Forms.CheckBox XmlFilterBox;
        private System.Windows.Forms.CheckBox OtherFilterBox;
    }
}