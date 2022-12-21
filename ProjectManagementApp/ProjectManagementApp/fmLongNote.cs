using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace ProjectManagementApp
{
    public partial class fmLongNote : Form
    {
        public CProject m_pProject;
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
                if (m_pProject == null)
                {
                    DialogResult = DialogResult.OK;
                } else
                {
                    m_pProject.szLongNote = szText;
                }
            }catch(Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_pProject == null)
                {
                    DialogResult = DialogResult.Cancel;
                }
                else
                {
                    m_pProject.szLongNote = szText;
                    Close();
                    Dispose();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }
}
