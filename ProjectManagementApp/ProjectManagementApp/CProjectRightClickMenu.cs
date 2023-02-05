using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectManagementApp
{
    public class CProjectRightClickMenu : ContextMenuStrip
    {
        public CProject m_pProject;
        public CProjectRightClickMenu() : base()
        {
            Initialize(null);
        }

        public CProjectRightClickMenu(CProject proj) : base()
        {
            Initialize(proj);
        }

        private void Initialize(CProject proj)
        {
            m_pProject = proj;
            string m_szSCText = proj == null ? "Source Control" : CDefines.PROJ_SRCCTRL_LABELS[m_pProject.m_nSourceControlID];

            //Items.Add("View Long Note");
            Items.Add("View Notebook");
            Items.Add("View Resources");
            Items.Add("Open Project Directory");
            //Items.Add("Open Wrike");
            Items.Add($"Open {m_szSCText}");
            Items.Add($"Change Background Color");

            int x = 0;
            //Items[x++].Click += LongNote_Click;
            Items[x++].Click += Notebook_Click;
            Items[x++].Click += Resources_Click;
            Items[x++].Click += ProjectDir_Click;
            //Items[x++].Click += Wrike_Click;
            Items[x++].Click += SourceControl_Click;
            Items[x++].Click += Highlight_Click;
        }

        private void Highlight_Click(object sender, EventArgs e)
        {
            try
            {
                ColorDialog dlg = new ColorDialog();
                dlg.AllowFullOpen = false;
                dlg.ShowHelp = true;
                dlg.Color = m_pProject.pColor;

                if(dlg.ShowDialog() == DialogResult.OK)
                {
                    m_pProject.pColor = dlg.Color;
                }
            }catch(Exception ex)
            {
                MessageBox.Show("Highlight_Click");
                Debug.WriteLine(ex);
            }
        }

        private void Notebook_Click(object sender, EventArgs e)
        {
            try
            {
                foreach(Form pExistingForm in fmProjectManager.m_pOpenForms)
                {
                    if (pExistingForm.GetType(). Equals(typeof(fmNotebook)))
                    {
                        fmNotebook fmNtbk = (fmNotebook)pExistingForm;
                        if(fmNtbk.m_pProject.m_nID == m_pProject.m_nID)
                        {
                            fmNtbk.WindowState = FormWindowState.Normal;
                            fmNtbk.Select();
                            return;
                        }
                    }
                }

                fmNotebook fm = new fmNotebook(m_pProject);
                fm.Show();
            }catch(Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private void SourceControl_Click(object sender, EventArgs e)
        {
            try
            {
                string szpath = m_pProject.m_szSourceControlPath;
                int nColonIndex = szpath.IndexOf(":");
                string szDrive = szpath.Substring(0, nColonIndex);
                string szCmd = String.Format(CDefines.PROJ_SRCCTRL_CMDS[m_pProject.m_nSourceControlID], szDrive, szpath);

                if (nColonIndex > -1)
                {
                    Process.Start("CMD.exe", szCmd);
                } else
                {
                    MessageBox.Show("The Source Control Path must be complete starting from drive letter.");
                }

                
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private void Resources_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Form pExistingForm in fmProjectManager.m_pOpenForms)
                {
                    if (pExistingForm.GetType().Equals(typeof(fmResources)))
                    {
                        fmResources fmRes = (fmResources)pExistingForm;
                        if (fmRes.m_pProject.m_nID == m_pProject.m_nID)
                        {
                            fmRes.WindowState = FormWindowState.Normal;
                            fmRes.Select();
                            return;
                        }
                    }
                }
                fmResources fm = new fmResources(m_pProject);
                fm.Show();
            }catch(Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private void LongNote_Click(object sender, EventArgs e)
        {
            try
            {
                fmLongNote fm = new fmLongNote(m_pProject);
                fm.szText = m_pProject.m_szLongNote;
                fm.Show();

            }catch(Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private void Wrike_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(m_pProject.m_szWrikeUrl);
            }catch(Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private void ProjectDir_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(m_pProject.m_szProjectDir);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }
}
