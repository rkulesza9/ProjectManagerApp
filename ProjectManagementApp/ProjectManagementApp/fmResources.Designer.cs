
namespace ProjectManagementApp
{
    partial class fmResources
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnPin = new System.Windows.Forms.ToolStripButton();
            this.btnDeleteRes = new System.Windows.Forms.ToolStripButton();
            this.btnAddRes = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lvRes = new System.Windows.Forms.ListView();
            this.pgRes = new System.Windows.Forms.PropertyGrid();
            this.btnSearch = new System.Windows.Forms.Button();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnPin,
            this.btnDeleteRes,
            this.btnAddRes});
            this.toolStrip1.Location = new System.Drawing.Point(0, 28);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 25);
            this.toolStrip1.TabIndex = 9;
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
            // btnDeleteRes
            // 
            this.btnDeleteRes.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnDeleteRes.Image = global::ProjectManagementApp.Properties.Resources.delete_new;
            this.btnDeleteRes.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDeleteRes.Name = "btnDeleteRes";
            this.btnDeleteRes.Size = new System.Drawing.Size(111, 22);
            this.btnDeleteRes.Text = "Delete Resource";
            this.btnDeleteRes.Click += new System.EventHandler(this.btnDeleteRes_Click);
            // 
            // btnAddRes
            // 
            this.btnAddRes.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnAddRes.Image = global::ProjectManagementApp.Properties.Resources.add;
            this.btnAddRes.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddRes.Name = "btnAddRes";
            this.btnAddRes.Size = new System.Drawing.Size(100, 22);
            this.btnAddRes.Text = "Add Resource";
            this.btnAddRes.ToolTipText = "Add Resource";
            this.btnAddRes.Click += new System.EventHandler(this.btnAddRes_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 53);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lvRes);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pgRes);
            this.splitContainer1.Size = new System.Drawing.Size(800, 397);
            this.splitContainer1.SplitterDistance = 220;
            this.splitContainer1.TabIndex = 10;
            // 
            // lvRes
            // 
            this.lvRes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvRes.FullRowSelect = true;
            this.lvRes.GridLines = true;
            this.lvRes.HideSelection = false;
            this.lvRes.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lvRes.Location = new System.Drawing.Point(0, 0);
            this.lvRes.Name = "lvRes";
            this.lvRes.Size = new System.Drawing.Size(800, 220);
            this.lvRes.TabIndex = 8;
            this.lvRes.UseCompatibleStateImageBehavior = false;
            this.lvRes.View = System.Windows.Forms.View.Details;
            this.lvRes.SelectedIndexChanged += new System.EventHandler(this.lvRes_SelectedIndexChanged);
            // 
            // pgRes
            // 
            this.pgRes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pgRes.HelpVisible = false;
            this.pgRes.Location = new System.Drawing.Point(0, 0);
            this.pgRes.Name = "pgRes";
            this.pgRes.PropertySort = System.Windows.Forms.PropertySort.Categorized;
            this.pgRes.Size = new System.Drawing.Size(800, 173);
            this.pgRes.TabIndex = 1;
            this.pgRes.ToolbarVisible = false;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(406, 3);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // tbSearch
            // 
            this.tbSearch.Location = new System.Drawing.Point(53, 3);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(347, 20);
            this.tbSearch.TabIndex = 2;
            // 
            // lblSearch
            // 
            this.lblSearch.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(3, 8);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(44, 13);
            this.lblSearch.TabIndex = 1;
            this.lblSearch.Text = "Search:";
            this.lblSearch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.lblSearch);
            this.flowLayoutPanel2.Controls.Add(this.tbSearch);
            this.flowLayoutPanel2.Controls.Add(this.btnSearch);
            this.flowLayoutPanel2.Controls.Add(this.btnRefresh);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(800, 28);
            this.flowLayoutPanel2.TabIndex = 6;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(487, 3);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 6;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // fmResources
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Name = "fmResources";
            this.Text = "fmResources";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnPin;
        private System.Windows.Forms.ToolStripButton btnDeleteRes;
        private System.Windows.Forms.ToolStripButton btnAddRes;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListView lvRes;
        private System.Windows.Forms.PropertyGrid pgRes;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button btnRefresh;
    }
}