using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Timers;
using System.Windows.Forms;
using Timer = System.Timers.Timer;

namespace ProjectManagementApp
{
    public partial class fmNotebook : Form
    {
        public CProject m_pProject;
        public ArrayList m_lsNotebookPages;
        public Hashtable m_lsEditors;
        private Timer m_pAutoSaveThread;
        
        public fmNotebook(CProject proj)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            this.FormClosed += FmNotebook_FormClosed;
            this.Load += FmNotebook_Load;

            pTabControl.Click += PTabControl_Click;
            pTabControl.DoubleClick += PTabControl_DoubleClick;
            pTabControl.SelectedIndexChanged += PTabControl_SelectedIndexChanged;

            m_pProject = proj;
            m_lsNotebookPages = new ArrayList();
            m_lsEditors = new Hashtable();
            Text = $"Notebook - [{m_pProject.m_szName}]";
            lblLastSavedDate.Text += DateTime.Now.ToString();

            SetupAutoSaveThread();

            fmProjectManager.m_pOpenForms.Add(this);
        }

        public void RenameSelectedTab(string name)
        {
            pTabControl.SelectedTab.Text = name;
        }
        public string GetSelectedTabName()
        {
            return pTabControl.SelectedTab.Text;
        }
        public void AddNewPage()
        {
            CNotebookPage nbp = (CNotebookPage)CJsonDatabase.Instance.Fetch(CDefines.TYPE_NOTEBOOK_PAGE, "");
            nbp.nProjectID = m_pProject.m_nID;
            m_lsNotebookPages.Add(nbp);
            pTabControl.SelectedTab = NewPage(nbp);
        }
        public void DeletePage(CNotebookPage page)
        {
            RicherTextBox.RicherTextBox rtb = (RicherTextBox.RicherTextBox)m_lsEditors[page.m_szGuid];
            TabPage tpage = (TabPage)rtb.Parent;
            pTabControl.TabPages.Remove(tpage);

            m_lsNotebookPages.Remove(page);
            m_lsEditors.Remove(page.m_szGuid);
            CJsonDatabase.Instance.Remove(page.m_szGuid);
            CJsonDatabase.Instance.Save(CJsonDatabase.Instance.m_szFileName);
        }


        private void PTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                TabPage tp = pTabControl.SelectedTab;
                ContextMenuStrip = new CNotebookRightClickMenu(this, (CNotebookPage) tp.Tag);
                
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
        private void FmNotebook_Load(object sender, EventArgs e)
        {
            try
            {
                PopulatePages();
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
        private void FmNotebook_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                if (m_pAutoSaveThread != null)
                {
                    m_pAutoSaveThread.Stop();
                    m_pAutoSaveThread.Dispose();
                }

                fmProjectManager.m_pOpenForms.Remove(this);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
        private void PTabControl_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (pTabControl.SelectedTab == pNewPage) return;

                TabPage pTab = pTabControl.SelectedTab;
                CNotebookPage pNbPg = (CNotebookPage)pTab.Tag;
                string szTitle = "Rename Tab";
                string szPrompt = $"What would you like to rename '{pTab.Text}' to? ";
                string szInput = "";
                DialogResult dr = ShowInputDialogBox(ref szInput, szPrompt, szTitle);

                if (dr != DialogResult.OK) return;

                pTab.Text = szInput;
                pNbPg.szName = szInput;

            }
            catch(Exception ex)
            {
                MessageBox.Show("PTabControl_DoubleClick");
                Debug.WriteLine(ex);
            }
        }
        private void PTabControl_Click(object sender, EventArgs e)
        {
            try
            {
                if (pTabControl.SelectedTab == pNewPage)
                {
                    CNotebookPage nbp = (CNotebookPage)CJsonDatabase.Instance.Fetch(CDefines.TYPE_NOTEBOOK_PAGE, "");
                    nbp.nProjectID = m_pProject.m_nID;
                    m_lsNotebookPages.Add(nbp);
                    pTabControl.SelectedTab = NewPage(nbp);
                } 


            }catch(Exception ex)
            {
                MessageBox.Show("PTabControl_Click");
                Debug.WriteLine(ex);
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (CNotebookPage page in m_lsNotebookPages)
                {
                    RicherTextBox.RicherTextBox rtb = (RicherTextBox.RicherTextBox)m_lsEditors[page.m_szGuid];
                    if (!rtb.Rtf.Equals(page.m_szText))
                    {
                        page.szText = rtb.Rtf;
                    }

                }

                lblLastSavedText.Text = "Last Saved: ";
                lblLastSavedDate.Text = DateTime.Now.ToString();

                MessageBox.Show("Save Successful");
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private void SetupAutoSaveThread()
        {
            try
            {
                m_pAutoSaveThread = new Timer(5 * 1000);
                m_pAutoSaveThread.Elapsed += M_pAutoSaveThread_Elapsed;
                m_pAutoSaveThread.AutoReset = true;
                m_pAutoSaveThread.Enabled = true;

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                MessageBox.Show("AutoSave Feature Not Working.");
            }
        }
        public void PopulatePages()
        {
            m_lsNotebookPages = new ArrayList(CJsonDatabase.Instance.GetNotebookPagesFor(m_pProject.m_szGuid));
            m_lsEditors.Clear();

            if(m_lsNotebookPages.Count == 0)
            {
                CNotebookPage nbp = (CNotebookPage)CJsonDatabase.Instance.Fetch(CDefines.TYPE_NOTEBOOK_PAGE, "");
                nbp.nProjectID = m_pProject.m_nID;
                m_lsNotebookPages.Add(nbp);
            }
            
            for (int x = pTabControl.TabCount - 2; x >= 0; x--) pTabControl.TabPages.RemoveAt(x);

            foreach (CNotebookPage pg in m_lsNotebookPages)
            {
                NewPage(pg);
            }

            pTabControl.SelectedIndex = 0;
        }
        public TabPage NewPage(CNotebookPage nbp)
        {
            TabPage pg = new TabPage();
            pg.Tag = nbp;
            RicherTextBox.RicherTextBox tb = new RicherTextBox.RicherTextBox();

            tb.Dock = DockStyle.Fill;
            tb.Rtf = nbp.m_szText;
            pg.Text = nbp.m_szName;
            pg.Controls.Add(tb);

            int index = pTabControl.TabPages.Count - 1;
            if (nbp.m_nOrder == -1) nbp.m_nOrder = index;
            pTabControl.TabPages.Insert(index, pg);

            pg.Tag = nbp;
            m_lsEditors.Add(nbp.m_szGuid, tb);
            return pg;
        }

        private void M_pAutoSaveThread_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                Invoke(new MethodInvoker(() =>
                {
                    foreach(CNotebookPage page in m_lsNotebookPages)
                    {
                        RicherTextBox.RicherTextBox rtb = (RicherTextBox.RicherTextBox)m_lsEditors[page.m_szGuid];
                        if (!rtb.Rtf.Equals(page.m_szText))
                        {
                            page.szText = rtb.Rtf;
                        }

                    }

                    lblLastSavedText.Text = "Last Saved (Autosave): ";
                    lblLastSavedDate.Text = DateTime.Now.ToString();
                }));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Last AutoSave Failed");
                Debug.WriteLine(ex);
            }
        }

        public static DialogResult ShowInputDialogBox(ref string input, string prompt, string title = "Title", int width = 300, int height = 200)
        {
            //This function creates the custom input dialog box by individually creating the different window elements and adding them to the dialog box

            //Specify the size of the window using the parameters passed
            Size size = new Size(width, height);
            //Create a new form using a System.Windows Form
            Form inputBox = new Form();
            inputBox.StartPosition = FormStartPosition.CenterScreen;

            inputBox.FormBorderStyle = FormBorderStyle.FixedDialog;
            inputBox.ClientSize = size;
            //Set the window title using the parameter passed
            inputBox.Text = title;

            //Create a new label to hold the prompt
            Label label = new Label();
            label.Text = prompt;
            label.Location = new Point(5, 5);
            label.Width = size.Width - 10;
            inputBox.Controls.Add(label);

            //Create a textbox to accept the user's input
            TextBox textBox = new TextBox();
            textBox.Size = new Size(size.Width - 10, 23);
            textBox.Location = new Point(5, label.Location.Y + 25);
            textBox.Text = input;
            inputBox.Controls.Add(textBox);

            //Create an OK Button 
            Button okButton = new Button();
            okButton.DialogResult = DialogResult.OK;
            okButton.Name = "okButton";
            okButton.Size = new Size(75, 23);
            okButton.Text = "&OK";
            okButton.Location = new Point(size.Width - 80 - 80, size.Height - 30);
            inputBox.Controls.Add(okButton);

            //Create a Cancel Button
            Button cancelButton = new Button();
            cancelButton.DialogResult = DialogResult.Cancel;
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(75, 23);
            cancelButton.Text = "&Cancel";
            cancelButton.Location = new Point(size.Width - 80, size.Height - 30);
            inputBox.Controls.Add(cancelButton);

            //Set the input box's buttons to the created OK and Cancel Buttons respectively so the window appropriately behaves with the button clicks
            inputBox.AcceptButton = okButton;
            inputBox.CancelButton = cancelButton;

            //Show the window dialog box 
            DialogResult result = inputBox.ShowDialog();
            input = textBox.Text;

            //After input has been submitted, return the input value
            return result;
        }

        public void MovePageLeft(int nIndex)
        {
            if (nIndex <= 0) return;

            CNotebookPage pg = (CNotebookPage)m_lsNotebookPages[nIndex];
            CNotebookPage pg2 = (CNotebookPage)m_lsNotebookPages[nIndex - 1];
            m_lsNotebookPages[nIndex] = m_lsNotebookPages[nIndex - 1];
            m_lsNotebookPages[nIndex - 1] = pg;

            TabPage tab = pTabControl.TabPages[nIndex];
            pTabControl.TabPages[nIndex] = pTabControl.TabPages[nIndex - 1];
            pTabControl.TabPages[nIndex - 1] = tab;

            pg.nOrder = nIndex - 1;
            pg2.nOrder = nIndex;
            pTabControl.SelectedIndex = nIndex - 1;
        }
        public void MovePageRight(int nIndex)
        {
            if (nIndex >= m_lsNotebookPages.Count-1) return;

            CNotebookPage pg = (CNotebookPage)m_lsNotebookPages[nIndex];
            CNotebookPage pg2 = (CNotebookPage)m_lsNotebookPages[nIndex + 1];
            m_lsNotebookPages[nIndex] = m_lsNotebookPages[nIndex + 1];
            m_lsNotebookPages[nIndex + 1] = pg;
              
            TabPage tab = pTabControl.TabPages[nIndex];
            pTabControl.TabPages[nIndex] = pTabControl.TabPages[nIndex + 1];
            pTabControl.TabPages[nIndex + 1] = tab;

            pg.nOrder = nIndex + 1;
            pg2.nOrder = nIndex;
            pTabControl.SelectedIndex = nIndex + 1;
        }

    }

    public class CNotebookRightClickMenu : ContextMenuStrip
    {
        public fmNotebook m_fmParent;
        public CNotebookPage m_pNotebookPage;

        public CNotebookRightClickMenu() : base()
        {
            Initialize(null, null);
        }
        public CNotebookRightClickMenu(fmNotebook parent, CNotebookPage pg)
        {
            Initialize(parent, pg);
        }
        private void Initialize(fmNotebook parent, CNotebookPage pg)
        {
            m_pNotebookPage = pg;
            m_fmParent = parent;

            Items.Add("New Page");
            Items.Add("Rename Page");
            Items.Add("Delete Page");
            Items.Add("Move Left");
            Items.Add("Move Right");

            int x = 0;
            Items[x++].Click += NewPage_Click;
            Items[x++].Click += RenamePage_Click;
            Items[x++].Click += DeletePage_Click;
            Items[x++].Click += MoveLeft_Click;
            Items[x++].Click += MoveRight_Click;
        }

        private void MoveRight_Click(object sender, EventArgs e)
        {
            try
            {
                m_fmParent.MovePageRight(m_pNotebookPage.m_nOrder);
                
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private void MoveLeft_Click(object sender, EventArgs e)
        {
            try
            {
                m_fmParent.MovePageLeft(m_pNotebookPage.m_nOrder);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private void NewPage_Click(object sender, EventArgs e)
        {
            try
            {
                m_fmParent.AddNewPage();
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private void RenamePage_Click(object sender, EventArgs e)
        {
            try
            {
                string szTitle = "Rename Tab";
                string szPrompt = $"What would you like to rename '{m_fmParent.GetSelectedTabName()}' to? ";
                string szInput = "";
                DialogResult dr = fmNotebook.ShowInputDialogBox(ref szInput, szPrompt, szTitle);

                if (dr != DialogResult.OK) return;

                m_fmParent.RenameSelectedTab(szInput);
                m_pNotebookPage.szName = szInput;
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private void DeletePage_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult pResponse = MessageBox.Show($"Are you sure you want to delete the page '{m_pNotebookPage.m_szName}' ?", "Delete Page", MessageBoxButtons.YesNo);
                if(pResponse == DialogResult.Yes)
                {
                    m_fmParent.DeletePage(m_pNotebookPage);
                }
            } catch(Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }
}
