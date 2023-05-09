namespace sisedit
{
    partial class Form1
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "Codepage",
            "1252"}, -1);
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem(new string[] {
            "Title",
            "Installation Database",
            "Transform"}, -1);
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem(new string[] {
            "Subject",
            ""}, -1);
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem("Author");
            System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem(new string[] {
            "Keyword",
            "Installer,MSI,Database"}, -1);
            System.Windows.Forms.ListViewItem listViewItem6 = new System.Windows.Forms.ListViewItem(new string[] {
            "Comments",
            "This installer database contains the logic and data required to install <INSERT_N" +
                "AME_HERE>"}, -1);
            System.Windows.Forms.ListViewItem listViewItem7 = new System.Windows.Forms.ListViewItem(new string[] {
            "Template",
            "Intel;1033"}, -1);
            System.Windows.Forms.ListViewItem listViewItem8 = new System.Windows.Forms.ListViewItem(new string[] {
            "LastAuthor",
            ""}, -1);
            System.Windows.Forms.ListViewItem listViewItem9 = new System.Windows.Forms.ListViewItem(new string[] {
            "Revision",
            ""}, -1);
            System.Windows.Forms.ListViewItem listViewItem10 = new System.Windows.Forms.ListViewItem(new string[] {
            "Printed",
            ""}, -1);
            System.Windows.Forms.ListViewItem listViewItem11 = new System.Windows.Forms.ListViewItem(new string[] {
            "Created",
            ""}, -1);
            System.Windows.Forms.ListViewItem listViewItem12 = new System.Windows.Forms.ListViewItem(new string[] {
            "Saved",
            ""}, -1);
            System.Windows.Forms.ListViewItem listViewItem13 = new System.Windows.Forms.ListViewItem(new string[] {
            "Schema",
            "200"}, -1);
            System.Windows.Forms.ListViewItem listViewItem14 = new System.Windows.Forms.ListViewItem(new string[] {
            "Source flags",
            "8"}, -1);
            System.Windows.Forms.ListViewItem listViewItem15 = new System.Windows.Forms.ListViewItem(new string[] {
            "Characters",
            "0"}, -1);
            System.Windows.Forms.ListViewItem listViewItem16 = new System.Windows.Forms.ListViewItem(new string[] {
            "Application",
            "Windows Installer"}, -1);
            System.Windows.Forms.ListViewItem listViewItem17 = new System.Windows.Forms.ListViewItem(new string[] {
            "Security",
            "0"}, -1);
            this.lstSIS = new System.Windows.Forms.ListView();
            this._Name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Value = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnSaveAs = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.propGrid = new System.Windows.Forms.PropertyGrid();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.restoreDefaultsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateGUIDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstSIS
            // 
            this.lstSIS.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstSIS.AutoArrange = false;
            this.lstSIS.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this._Name,
            this.Value});
            this.lstSIS.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lstSIS.FullRowSelect = true;
            this.lstSIS.GridLines = true;
            this.lstSIS.HideSelection = false;
            listViewItem1.StateImageIndex = 0;
            listViewItem1.ToolTipText = "ANSI codepage of text strings in summary information only";
            listViewItem2.StateImageIndex = 0;
            listViewItem2.ToolTipText = "Package type, e.g. Installation Database";
            listViewItem3.StateImageIndex = 0;
            listViewItem3.ToolTipText = "Product full name or description";
            listViewItem4.StateImageIndex = 0;
            listViewItem4.ToolTipText = "Creator, typically vendor name";
            listViewItem5.StateImageIndex = 0;
            listViewItem5.ToolTipText = "List of keywords for use by file browsers";
            listViewItem6.StateImageIndex = 0;
            listViewItem6.ToolTipText = "Description of purpose or use of package";
            listViewItem7.StateImageIndex = 0;
            listViewItem7.ToolTipText = "Target system: Platform(s);Language(s)";
            listViewItem8.StateImageIndex = 0;
            listViewItem9.StateImageIndex = 0;
            listViewItem9.ToolTipText = "Package code GUID, for transforms contains old and new info";
            listViewItem10.StateImageIndex = 0;
            listViewItem10.ToolTipText = "Date and time of installation image";
            listViewItem11.StateImageIndex = 0;
            listViewItem11.ToolTipText = "Date and time of package creation";
            listViewItem12.StateImageIndex = 0;
            listViewItem12.ToolTipText = "Date and time of last package modification";
            listViewItem13.StateImageIndex = 0;
            listViewItem13.ToolTipText = "Minimum Windows Installer version required: Major * 100 + Minor";
            listViewItem14.StateImageIndex = 0;
            listViewItem14.ToolTipText = "1=short names, 2=compressed, 4=network image, 8=no elevated privileges required";
            listViewItem15.StateImageIndex = 0;
            listViewItem15.ToolTipText = "Used for transforms only: validation and error flags";
            listViewItem16.StateImageIndex = 0;
            listViewItem16.ToolTipText = "Application associated with file, \"Windows Installer\" for MSI";
            listViewItem17.StateImageIndex = 0;
            listViewItem17.ToolTipText = "This property should be set to read-only recommended (2) for an installation data" +
    "base and to read-only enforced (4) for a transform or patch.";
            this.lstSIS.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4,
            listViewItem5,
            listViewItem6,
            listViewItem7,
            listViewItem8,
            listViewItem9,
            listViewItem10,
            listViewItem11,
            listViewItem12,
            listViewItem13,
            listViewItem14,
            listViewItem15,
            listViewItem16,
            listViewItem17});
            this.lstSIS.Location = new System.Drawing.Point(14, 13);
            this.lstSIS.Name = "lstSIS";
            this.lstSIS.ShowItemToolTips = true;
            this.lstSIS.Size = new System.Drawing.Size(662, 391);
            this.lstSIS.TabIndex = 0;
            this.lstSIS.UseCompatibleStateImageBehavior = false;
            this.lstSIS.View = System.Windows.Forms.View.Details;
            this.lstSIS.Visible = false;
            // 
            // _Name
            // 
            this._Name.Text = "Name";
            this._Name.Width = 106;
            // 
            // Value
            // 
            this.Value.Text = "Value";
            this.Value.Width = 547;
            // 
            // btnLoad
            // 
            this.btnLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLoad.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoad.Location = new System.Drawing.Point(15, 420);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(87, 27);
            this.btnLoad.TabIndex = 1;
            this.btnLoad.Text = "Load from...";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnSaveAs
            // 
            this.btnSaveAs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveAs.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveAs.Location = new System.Drawing.Point(589, 421);
            this.btnSaveAs.Name = "btnSaveAs";
            this.btnSaveAs.Size = new System.Drawing.Size(87, 27);
            this.btnSaveAs.TabIndex = 1;
            this.btnSaveAs.Text = "Save to...";
            this.btnSaveAs.UseVisualStyleBackColor = true;
            this.btnSaveAs.Click += new System.EventHandler(this.btnSaveAs_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Enabled = false;
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(487, 421);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(87, 27);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // propGrid
            // 
            this.propGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.propGrid.ContextMenuStrip = this.contextMenuStrip1;
            this.propGrid.HelpBackColor = System.Drawing.SystemColors.Info;
            this.propGrid.HelpForeColor = System.Drawing.SystemColors.InfoText;
            this.propGrid.Location = new System.Drawing.Point(15, 13);
            this.propGrid.Name = "propGrid";
            this.propGrid.PropertySort = System.Windows.Forms.PropertySort.NoSort;
            this.propGrid.SelectedObject = this._Name;
            this.propGrid.Size = new System.Drawing.Size(661, 391);
            this.propGrid.TabIndex = 2;
            this.propGrid.ToolbarVisible = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.restoreDefaultsToolStripMenuItem,
            this.generateGUIDToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(151, 48);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // restoreDefaultsToolStripMenuItem
            // 
            this.restoreDefaultsToolStripMenuItem.Name = "restoreDefaultsToolStripMenuItem";
            this.restoreDefaultsToolStripMenuItem.ShowShortcutKeys = false;
            this.restoreDefaultsToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.restoreDefaultsToolStripMenuItem.Text = "Reset";
            this.restoreDefaultsToolStripMenuItem.Click += new System.EventHandler(this.restoreDefaultsToolStripMenuItem_Click);
            // 
            // generateGUIDToolStripMenuItem
            // 
            this.generateGUIDToolStripMenuItem.Name = "generateGUIDToolStripMenuItem";
            this.generateGUIDToolStripMenuItem.ShowShortcutKeys = false;
            this.generateGUIDToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.generateGUIDToolStripMenuItem.Text = "Generate GUID";
            this.generateGUIDToolStripMenuItem.Click += new System.EventHandler(this.generateGUIDToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(691, 460);
            this.Controls.Add(this.propGrid);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnSaveAs);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.lstSIS);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MinimumSize = new System.Drawing.Size(336, 175);
            this.Name = "Form1";
            this.Text = "SummaryInformationStream Editor";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lstSIS;
        private System.Windows.Forms.ColumnHeader _Name;
        private System.Windows.Forms.ColumnHeader Value;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnSaveAs;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.PropertyGrid propGrid;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem restoreDefaultsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generateGUIDToolStripMenuItem;
    }
}
