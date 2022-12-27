using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using Timer = System.Timers.Timer;

namespace ProjectManagementApp
{
    public partial class fmLongNote : Form
    {
        public CProject m_pProject;
        private Timer m_pAutoSaveThread;
        public fmLongNote(CProject proj)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            this.FormClosed += FmLongNote_FormClosed;

            m_pProject = proj;
            Text = $"Long Note - [{m_pProject.m_szName}]";
            szText = m_pProject.m_szLongNote;
            lblLastSavedDate.Text = DateTime.Now.ToString();

            SetupAutoSaveThread();

            fmProjectManager.m_pOpenForms.Add(this);
        }

        private void FmLongNote_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                if(m_pAutoSaveThread != null)
                {
                    m_pAutoSaveThread.Stop();
                    m_pAutoSaveThread.Dispose();
                }

                fmProjectManager.m_pOpenForms.Remove(this);
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex);
            }
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
                lblLastSavedText.Text = "Last Saved: ";
                lblLastSavedDate.Text = DateTime.Now.ToString();
                MessageBox.Show("Save Successful", "Save Successful");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Save Failed", "Save Failed");
                Debug.WriteLine(ex);
            }
        }

        private void SetupAutoSaveThread()
        {
            try
            {
                m_pAutoSaveThread = new Timer(5*1000);
                m_pAutoSaveThread.Elapsed += M_pAutoSaveThread_Elapsed;
                m_pAutoSaveThread.AutoReset = true;
                m_pAutoSaveThread.Enabled = true;
                
            }catch(Exception ex)
            {
                Debug.WriteLine(ex);
                MessageBox.Show("AutoSave Feature Not Working.");
            }
        }

        private void M_pAutoSaveThread_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                Invoke(new MethodInvoker(() =>
                {
                    if (m_pProject.szLongNote.Equals(szText)) return; // if no changes, no need to save

                    m_pProject.szLongNote = szText;
                    lblLastSavedText.Text = "Last Saved (Autosave): ";
                    lblLastSavedDate.Text = DateTime.Now.ToString();
                }));
            }
            catch(Exception ex)
            {
                MessageBox.Show("Last AutoSave Failed");
                Debug.WriteLine(ex);
            }
        }
    }
}
