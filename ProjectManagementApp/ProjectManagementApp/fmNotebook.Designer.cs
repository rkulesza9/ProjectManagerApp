namespace ProjectManagementApp
{
    partial class fmNotebook
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblLastSavedText = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblLastSavedDate = new System.Windows.Forms.ToolStripStatusLabel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnSave = new System.Windows.Forms.Button();
            this.pTabControl = new System.Windows.Forms.TabControl();
            this.pNewPage = new System.Windows.Forms.TabPage();
            this.statusStrip1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.pTabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblLastSavedText,
            this.lblLastSavedDate});
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblLastSavedText
            // 
            this.lblLastSavedText.Name = "lblLastSavedText";
            this.lblLastSavedText.Size = new System.Drawing.Size(65, 17);
            this.lblLastSavedText.Text = "Last Saved:";
            // 
            // lblLastSavedDate
            // 
            this.lblLastSavedDate.Name = "lblLastSavedDate";
            this.lblLastSavedDate.Size = new System.Drawing.Size(10, 17);
            this.lblLastSavedDate.Text = " ";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnSave);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 396);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(800, 32);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(3, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // pTabControl
            // 
            this.pTabControl.Controls.Add(this.pNewPage);
            this.pTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pTabControl.Location = new System.Drawing.Point(0, 0);
            this.pTabControl.Name = "pTabControl";
            this.pTabControl.SelectedIndex = 0;
            this.pTabControl.Size = new System.Drawing.Size(800, 396);
            this.pTabControl.TabIndex = 2;
            // 
            // pNewPage
            // 
            this.pNewPage.Location = new System.Drawing.Point(4, 22);
            this.pNewPage.Name = "pNewPage";
            this.pNewPage.Padding = new System.Windows.Forms.Padding(3);
            this.pNewPage.Size = new System.Drawing.Size(792, 370);
            this.pNewPage.TabIndex = 0;
            this.pNewPage.Text = "New (+)";
            this.pNewPage.UseVisualStyleBackColor = true;
            // 
            // fmNotebook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pTabControl);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "fmNotebook";
            this.Text = "fmNotebook";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.pTabControl.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblLastSavedText;
        private System.Windows.Forms.ToolStripStatusLabel lblLastSavedDate;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TabControl pTabControl;
        private System.Windows.Forms.TabPage pNewPage;
    }
}