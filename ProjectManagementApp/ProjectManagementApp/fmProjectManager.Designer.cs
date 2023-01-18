
namespace ProjectManagementApp
{
    partial class fmProjectManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmProjectManager));
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblName = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cbStatus = new System.Windows.Forms.ComboBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lvProjects = new System.Windows.Forms.ListView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnPin = new System.Windows.Forms.ToolStripButton();
            this.btnDeleteProject = new System.Windows.Forms.ToolStripButton();
            this.btnAddProject = new System.Windows.Forms.ToolStripButton();
            this.pgProject = new System.Windows.Forms.PropertyGrid();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblLoadStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.pbLoadingBar = new System.Windows.Forms.ToolStripProgressBar();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.filesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportAllToExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToZipToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportAllToZipToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.lblName);
            this.flowLayoutPanel2.Controls.Add(this.tbName);
            this.flowLayoutPanel2.Controls.Add(this.label1);
            this.flowLayoutPanel2.Controls.Add(this.cbType);
            this.flowLayoutPanel2.Controls.Add(this.lblStatus);
            this.flowLayoutPanel2.Controls.Add(this.cbStatus);
            this.flowLayoutPanel2.Controls.Add(this.btnRefresh);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 24);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(897, 28);
            this.flowLayoutPanel2.TabIndex = 5;
            // 
            // lblName
            // 
            this.lblName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(3, 8);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(68, 13);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Search Text:";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(77, 3);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(157, 20);
            this.tbName.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(240, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Type:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbType
            // 
            this.cbType.FormattingEnabled = true;
            this.cbType.Location = new System.Drawing.Point(280, 3);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(121, 21);
            this.cbType.TabIndex = 7;
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(407, 8);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(40, 13);
            this.lblStatus.TabIndex = 3;
            this.lblStatus.Text = "Status:";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbStatus
            // 
            this.cbStatus.FormattingEnabled = true;
            this.cbStatus.Location = new System.Drawing.Point(453, 3);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(121, 21);
            this.cbStatus.TabIndex = 4;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(580, 3);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 5;
            this.btnRefresh.Text = "Search";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 52);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lvProjects);
            this.splitContainer1.Panel1.Controls.Add(this.toolStrip1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pgProject);
            this.splitContainer1.Panel2.Controls.Add(this.statusStrip1);
            this.splitContainer1.Size = new System.Drawing.Size(897, 407);
            this.splitContainer1.SplitterDistance = 272;
            this.splitContainer1.TabIndex = 6;
            // 
            // lvProjects
            // 
            this.lvProjects.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvProjects.FullRowSelect = true;
            this.lvProjects.GridLines = true;
            this.lvProjects.HideSelection = false;
            this.lvProjects.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lvProjects.Location = new System.Drawing.Point(0, 25);
            this.lvProjects.Name = "lvProjects";
            this.lvProjects.Size = new System.Drawing.Size(897, 247);
            this.lvProjects.TabIndex = 7;
            this.lvProjects.UseCompatibleStateImageBehavior = false;
            this.lvProjects.View = System.Windows.Forms.View.Details;
            this.lvProjects.SelectedIndexChanged += new System.EventHandler(this.lvProjects_SelectedIndexChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnPin,
            this.btnDeleteProject,
            this.btnAddProject});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(897, 25);
            this.toolStrip1.TabIndex = 8;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnPin
            // 
            this.btnPin.Image = global::ProjectManagementApp.Properties.Resources.About_new;
            this.btnPin.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPin.Name = "btnPin";
            this.btnPin.Size = new System.Drawing.Size(44, 22);
            this.btnPin.Text = "Pin";
            this.btnPin.Click += new System.EventHandler(this.btnPin_Click);
            // 
            // btnDeleteProject
            // 
            this.btnDeleteProject.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnDeleteProject.Image = global::ProjectManagementApp.Properties.Resources.delete_new;
            this.btnDeleteProject.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDeleteProject.Name = "btnDeleteProject";
            this.btnDeleteProject.Size = new System.Drawing.Size(100, 22);
            this.btnDeleteProject.Text = "Delete Project";
            this.btnDeleteProject.Click += new System.EventHandler(this.btnDeleteProject_Click);
            // 
            // btnAddProject
            // 
            this.btnAddProject.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnAddProject.Image = global::ProjectManagementApp.Properties.Resources.add;
            this.btnAddProject.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddProject.Name = "btnAddProject";
            this.btnAddProject.Size = new System.Drawing.Size(89, 22);
            this.btnAddProject.Text = "Add Project";
            this.btnAddProject.Click += new System.EventHandler(this.btnAddProject_Click);
            // 
            // pgProject
            // 
            this.pgProject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pgProject.HelpVisible = false;
            this.pgProject.Location = new System.Drawing.Point(0, 0);
            this.pgProject.Name = "pgProject";
            this.pgProject.PropertySort = System.Windows.Forms.PropertySort.Categorized;
            this.pgProject.Size = new System.Drawing.Size(897, 109);
            this.pgProject.TabIndex = 0;
            this.pgProject.ToolbarVisible = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblLoadStatus,
            this.pbLoadingBar});
            this.statusStrip1.Location = new System.Drawing.Point(0, 109);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(897, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblLoadStatus
            // 
            this.lblLoadStatus.Name = "lblLoadStatus";
            this.lblLoadStatus.Size = new System.Drawing.Size(780, 17);
            this.lblLoadStatus.Spring = true;
            this.lblLoadStatus.Text = "Done";
            this.lblLoadStatus.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // pbLoadingBar
            // 
            this.pbLoadingBar.Name = "pbLoadingBar";
            this.pbLoadingBar.Size = new System.Drawing.Size(100, 16);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filesToolStripMenuItem,
            this.editToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.toolsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(897, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // filesToolStripMenuItem
            // 
            this.filesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newFileToolStripMenuItem,
            this.openFileToolStripMenuItem,
            this.saveAsToolStripMenuItem});
            this.filesToolStripMenuItem.Name = "filesToolStripMenuItem";
            this.filesToolStripMenuItem.Size = new System.Drawing.Size(42, 20);
            this.filesToolStripMenuItem.Text = "Files";
            // 
            // newFileToolStripMenuItem
            // 
            this.newFileToolStripMenuItem.Name = "newFileToolStripMenuItem";
            this.newFileToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.newFileToolStripMenuItem.Text = "New File";
            this.newFileToolStripMenuItem.Click += new System.EventHandler(this.newFileToolStripMenuItem_Click);
            // 
            // openFileToolStripMenuItem
            // 
            this.openFileToolStripMenuItem.Name = "openFileToolStripMenuItem";
            this.openFileToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.openFileToolStripMenuItem.Text = "Open File";
            this.openFileToolStripMenuItem.Click += new System.EventHandler(this.openFileToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.saveAsToolStripMenuItem.Text = "Save As";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportToExcelToolStripMenuItem,
            this.exportAllToExcelToolStripMenuItem,
            this.exportToZipToolStripMenuItem,
            this.exportAllToZipToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.editToolStripMenuItem.Text = "Export";
            // 
            // exportToExcelToolStripMenuItem
            // 
            this.exportToExcelToolStripMenuItem.Name = "exportToExcelToolStripMenuItem";
            this.exportToExcelToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.exportToExcelToolStripMenuItem.Text = "Export to Excel";
            this.exportToExcelToolStripMenuItem.Click += new System.EventHandler(this.exportToExcelToolStripMenuItem_Click);
            // 
            // exportAllToExcelToolStripMenuItem
            // 
            this.exportAllToExcelToolStripMenuItem.Name = "exportAllToExcelToolStripMenuItem";
            this.exportAllToExcelToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.exportAllToExcelToolStripMenuItem.Text = "Export All To Excel";
            this.exportAllToExcelToolStripMenuItem.Click += new System.EventHandler(this.exportAllToExcelToolStripMenuItem_Click);
            // 
            // exportToZipToolStripMenuItem
            // 
            this.exportToZipToolStripMenuItem.Name = "exportToZipToolStripMenuItem";
            this.exportToZipToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.exportToZipToolStripMenuItem.Text = "Export To Zip";
            this.exportToZipToolStripMenuItem.Click += new System.EventHandler(this.exportToZipToolStripMenuItem_Click);
            // 
            // exportAllToZipToolStripMenuItem
            // 
            this.exportAllToZipToolStripMenuItem.Name = "exportAllToZipToolStripMenuItem";
            this.exportAllToZipToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.exportAllToZipToolStripMenuItem.Text = "Export All To Zip";
            this.exportAllToZipToolStripMenuItem.Click += new System.EventHandler(this.exportAllToZipToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // fmProjectManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(897, 459);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "fmProjectManager";
            this.Text = "Project Manager";
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cbStatus;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListView lvProjects;
        private System.Windows.Forms.PropertyGrid pgProject;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnPin;
        private System.Windows.Forms.ToolStripButton btnDeleteProject;
        private System.Windows.Forms.ToolStripButton btnAddProject;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem filesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToExcelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportAllToExcelToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblLoadStatus;
        private System.Windows.Forms.ToolStripProgressBar pbLoadingBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbType;
        private System.Windows.Forms.ToolStripMenuItem exportToZipToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportAllToZipToolStripMenuItem;
    }
}

