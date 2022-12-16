using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectManagementApp
{
    public partial class fmLongNote : Form
    {
        public fmLongNote()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        public string szText
        {
            get { return tbLongNote.Rtf; }
            set { tbLongNote.Rtf = value; }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult = DialogResult.OK;
            }catch(Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult = DialogResult.Cancel;

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }
}
