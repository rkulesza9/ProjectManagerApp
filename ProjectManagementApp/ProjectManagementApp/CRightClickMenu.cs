using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectManagementApp
{
    public class CRightClickMenu : ContextMenuStrip
    {
        public CProject m_pProject;
        public CRightClickMenu() : base()
        {
            Initialize(null);
        }

        public CRightClickMenu(CProject proj) : base()
        {
            Initialize(proj);
        }

        private void Initialize(CProject proj)
        {
            m_pProject = proj;

            Items.Add("View Long Note");
            Items.Add("View Resources");
            Items.Add("Open Project Directory");
            Items.Add("Open Wrike");

            int x = 0;
            Items[x++].Click += LongNote_Click;
            Items[x++].Click += Resources_Click;
            Items[x++].Click += ProjectDir_Click;
            Items[x++].Click += Wrike_Click;
        }

        private void Resources_Click(object sender, EventArgs e)
        {
            try
            {
                fmResources fm = new fmResources(m_pProject.m_szGuid);
                fm.ShowDialog();
            }catch(Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private void LongNote_Click(object sender, EventArgs e)
        {
            try
            {
                fmLongNote fm = new fmLongNote();
                fm.szText = m_pProject.m_szLongNote;
                if(fm.ShowDialog() == DialogResult.OK)
                {
                    m_pProject.szLongNote = fm.szText;
                }

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
