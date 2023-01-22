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
    public class CResRightClickMenu : ContextMenuStrip
    {
        public CResource m_pResource;
        public CResRightClickMenu() : base()
        {
            Initialize(null);
        }

        public CResRightClickMenu(CResource res) : base()
        {
            Initialize(res);
        }

        private void Initialize(CResource res)
        {
            m_pResource = res;

            Items.Add($"Change Background Color");

            int x = 0;
            Items[x++].Click += Highlight_Click;
        }

        private void Highlight_Click(object sender, EventArgs e)
        {
            try
            {
                ColorDialog dlg = new ColorDialog();
                dlg.AllowFullOpen = false;
                dlg.ShowHelp = true;
                dlg.Color = m_pResource.pColor;

                if(dlg.ShowDialog() == DialogResult.OK)
                {
                    m_pResource.pColor = dlg.Color;
                }
            }catch(Exception ex)
            {
                MessageBox.Show("Highlight_Click");
                Debug.WriteLine(ex);
            }
        }

   
    }
}
