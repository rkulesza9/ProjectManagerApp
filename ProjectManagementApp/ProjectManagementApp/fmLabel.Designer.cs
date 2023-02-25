namespace ProjectManagementApp
{
    partial class fmLabel
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
            this.btnAddLabel = new System.Windows.Forms.ToolStripButton();
            this.btnDeleteLabel = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lvLabels = new System.Windows.Forms.ListView();
            this.pgLabel = new System.Windows.Forms.PropertyGrid();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddLabel,
            this.btnDeleteLabel});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnAddLabel
            // 
            this.btnAddLabel.Image = global::ProjectManagementApp.Properties.Resources.add;
            this.btnAddLabel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddLabel.Name = "btnAddLabel";
            this.btnAddLabel.Size = new System.Drawing.Size(80, 22);
            this.btnAddLabel.Text = "Add Label";
            // 
            // btnDeleteLabel
            // 
            this.btnDeleteLabel.Image = global::ProjectManagementApp.Properties.Resources.delete_new;
            this.btnDeleteLabel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDeleteLabel.Name = "btnDeleteLabel";
            this.btnDeleteLabel.Size = new System.Drawing.Size(91, 22);
            this.btnDeleteLabel.Text = "Delete Label";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lvLabels);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pgLabel);
            this.splitContainer1.Size = new System.Drawing.Size(800, 425);
            this.splitContainer1.SplitterDistance = 266;
            this.splitContainer1.TabIndex = 1;
            // 
            // lvLabels
            // 
            this.lvLabels.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvLabels.FullRowSelect = true;
            this.lvLabels.GridLines = true;
            this.lvLabels.HideSelection = false;
            this.lvLabels.Location = new System.Drawing.Point(0, 0);
            this.lvLabels.Name = "lvLabels";
            this.lvLabels.Size = new System.Drawing.Size(800, 266);
            this.lvLabels.TabIndex = 0;
            this.lvLabels.UseCompatibleStateImageBehavior = false;
            this.lvLabels.View = System.Windows.Forms.View.Details;
            // 
            // pgLabel
            // 
            this.pgLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pgLabel.HelpVisible = false;
            this.pgLabel.Location = new System.Drawing.Point(0, 0);
            this.pgLabel.Name = "pgLabel";
            this.pgLabel.Size = new System.Drawing.Size(800, 155);
            this.pgLabel.TabIndex = 0;
            this.pgLabel.ToolbarVisible = false;
            // 
            // fmLabel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "fmLabel";
            this.Text = "fmLabel";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnAddLabel;
        private System.Windows.Forms.ToolStripButton btnDeleteLabel;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListView lvLabels;
        private System.Windows.Forms.PropertyGrid pgLabel;
    }
}