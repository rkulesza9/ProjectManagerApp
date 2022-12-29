﻿using System;
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
            string m_szSCText = proj == null ? "Source Control" : CDefines.PROJ_SRCCTRL_LABELS[m_pProject.m_nSourceControlID];

            Items.Add("View Long Note");
            Items.Add("View Resources");
            Items.Add("Open Project Directory");
            Items.Add("Open Wrike");
            Items.Add($"Open {m_szSCText}");

            int x = 0;
            Items[x++].Click += LongNote_Click;
            Items[x++].Click += Resources_Click;
            Items[x++].Click += ProjectDir_Click;
            Items[x++].Click += Wrike_Click;
            Items[x++].Click += SourceControl_Click;
        }

        private void SourceControl_Click(object sender, EventArgs e)
        {
            try
            {
                string szPath;
                string szDrive;

                switch (m_pProject.m_nSourceControlID)
                {
                    case CDefines.PROJ_SRCCTRL_GIT:
                        szPath = m_pProject.m_szSourceControlPath;
                        szDrive = $"{szPath.Substring(0, szPath.IndexOf(':') + 1)} && ";
                        Process.Start("CMD.exe", String.Format(CDefines.PROJ_SRCCTRL_CMDS[m_pProject.m_nSourceControlID], szDrive, szPath));

                        break;
                    case CDefines.PROJ_SRCCTRL_SOURCESAFE:

                        break;
                    default:
                        break;
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
