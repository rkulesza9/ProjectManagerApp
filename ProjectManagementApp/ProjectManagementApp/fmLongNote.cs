using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace ProjectManagementApp
{
    public partial class fmLongNote : Form
    {
        public CProject m_pProject;
        public fmLongNote(CProject proj)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;

            m_pProject = proj;
            Text = $"Long Note - [{m_pProject.m_szName}]";
            szText = m_pProject.m_szLongNote;
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
                m_pProject.szLongNote = szText;
                MessageBox.Show("Save Successful", "Save Successful");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Save Failed", "Save Failed");
                Debug.WriteLine(ex);
            }
        }
    }
}
