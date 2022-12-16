
namespace ProjectManagementApp
{
    partial class fmLongNote
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tbLongNote = new RicherTextBox.RicherTextBox();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnSave);
            this.flowLayoutPanel1.Controls.Add(this.btnCancel);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 422);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(800, 28);
            this.flowLayoutPanel1.TabIndex = 4;
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
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(84, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // tbLongNote
            // 
            this.tbLongNote.AlignCenterVisible = true;
            this.tbLongNote.AlignLeftVisible = true;
            this.tbLongNote.AlignRightVisible = true;
            this.tbLongNote.BoldVisible = true;
            this.tbLongNote.BulletsVisible = true;
            this.tbLongNote.ChooseFontVisible = true;
            this.tbLongNote.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbLongNote.FindReplaceVisible = true;
            this.tbLongNote.FontColorVisible = true;
            this.tbLongNote.FontFamilyVisible = true;
            this.tbLongNote.FontSizeVisible = true;
            this.tbLongNote.GroupAlignmentVisible = true;
            this.tbLongNote.GroupBoldUnderlineItalicVisible = true;
            this.tbLongNote.GroupFontColorVisible = true;
            this.tbLongNote.GroupFontNameAndSizeVisible = true;
            this.tbLongNote.GroupIndentationAndBulletsVisible = true;
            this.tbLongNote.GroupInsertVisible = true;
            this.tbLongNote.GroupSaveAndLoadVisible = true;
            this.tbLongNote.GroupZoomVisible = true;
            this.tbLongNote.INDENT = 10;
            this.tbLongNote.IndentVisible = true;
            this.tbLongNote.InsertPictureVisible = true;
            this.tbLongNote.ItalicVisible = true;
            this.tbLongNote.LoadVisible = true;
            this.tbLongNote.Location = new System.Drawing.Point(0, 0);
            this.tbLongNote.Name = "tbLongNote";
            this.tbLongNote.OutdentVisible = true;
            this.tbLongNote.Rtf = "{\\rtf1\\ansi\\deff0{\\fonttbl{\\f0\\fnil\\fcharset204 Microsoft Sans Serif;}}\r\n\\viewkin" +
    "d4\\uc1\\pard\\lang1033\\f0\\fs18 richerTextBox1\\par\r\n}\r\n";
            this.tbLongNote.SaveVisible = true;
            this.tbLongNote.SeparatorAlignVisible = true;
            this.tbLongNote.SeparatorBoldUnderlineItalicVisible = true;
            this.tbLongNote.SeparatorFontColorVisible = true;
            this.tbLongNote.SeparatorFontVisible = true;
            this.tbLongNote.SeparatorIndentAndBulletsVisible = true;
            this.tbLongNote.SeparatorInsertVisible = true;
            this.tbLongNote.SeparatorSaveLoadVisible = true;
            this.tbLongNote.Size = new System.Drawing.Size(800, 422);
            this.tbLongNote.TabIndex = 5;
            this.tbLongNote.ToolStripVisible = true;
            this.tbLongNote.UnderlineVisible = true;
            this.tbLongNote.WordWrapVisible = true;
            this.tbLongNote.ZoomFactorTextVisible = true;
            this.tbLongNote.ZoomInVisible = true;
            this.tbLongNote.ZoomOutVisible = true;
            // 
            // fmLongNote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tbLongNote);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "fmLongNote";
            this.Text = "Long Note";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private RicherTextBox.RicherTextBox tbLongNote;
    }
}