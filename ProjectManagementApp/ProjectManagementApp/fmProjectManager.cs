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
    public partial class fmProjectManager : Form
    {
        public fmProjectManager()
        {
            try
            {
                InitializeComponent();
                StartPosition = FormStartPosition.CenterScreen;
                lvProjects.ListViewItemSorter = new CListViewComparer(CDefines.UI_LISTVIEW_PROJECTS, 0, SortOrder.Ascending);
                lvProjects.ColumnClick += LvProjects_ColumnClick;
                lvProjects.ContextMenuStrip = new CRightClickMenu();
                pgProject.PropertyValueChanged += PgProject_PropertyValueChanged;
                CJsonDatabase.Initialize(CDefines.JSON_FILE_NAME);

                PopulateStatusDropDown();
                PopulateProjectListViewHeaders();
                PopulateProjectListView();

            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        #region "Events"
        private void PgProject_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            try
            {
                RefreshColumnWidths();
            }catch(Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
        private void LvProjects_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            try
            {
                CListViewComparer comparer = (CListViewComparer)lvProjects.ListViewItemSorter;
                int nColumn = e.Column;
                SortOrder pOrder = comparer.m_pSortOrder == SortOrder.Ascending ? SortOrder.Descending : SortOrder.Ascending;

                lvProjects.ListViewItemSorter = new CListViewComparer(CDefines.UI_LISTVIEW_PROJECTS, nColumn, pOrder);

            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                string szName = tbName.Text;
                int nStatusID = cbStatus.SelectedIndex - 1;

                PopulateProjectListView(szName, nStatusID);
            }catch(Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private void lvProjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (lvProjects.SelectedItems.Count == 0) return;

                CListViewItem pSelItem = (CListViewItem)lvProjects.SelectedItems[0];
                CProject project = (CProject)pSelItem.Tag;

                pgProject.SelectedObject = project;

                if (lvProjects.ContextMenuStrip != null)
                {
                    CRightClickMenu menu = (CRightClickMenu)lvProjects.ContextMenuStrip;
                    menu.m_pProject = project;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private void btnPin_Click(object sender, EventArgs e)
        {
            try
            {
                if (lvProjects.SelectedItems.Count == 0) return;
                CListViewItem pSelItem = (CListViewItem)lvProjects.SelectedItems[0];
                CProject project = (CProject)pSelItem.Tag;

                project.bPinned = !project.bPinned;

                CListViewComparer lvc = (CListViewComparer) lvProjects.ListViewItemSorter;
                lvProjects.ListViewItemSorter = null;
                lvProjects.ListViewItemSorter = lvc;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private void btnAddProject_Click(object sender, EventArgs e)
        {
            try
            {
                CProject proj = (CProject) CJsonDatabase.Instance.Fetch(CDefines.TYPE_PROJECT, "");
                CListViewItem item = proj.CreateListViewItem(CDefines.UI_LISTVIEW_PROJECTS);

                lvProjects.Items.Add(item);
                lvProjects.SelectedItems.Clear();
                item.Selected = true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private void btnDeleteProject_Click(object sender, EventArgs e)
        {
            try
            {
                if (lvProjects.SelectedItems.Count == 0) return;
                if (DialogResult.Yes != MessageBox.Show("Are You Sure You Want To Delete This Project?", "Delete Selected Project", MessageBoxButtons.YesNo)) return;

                CListViewItem pSelItem = (CListViewItem)lvProjects.SelectedItems[0];
                CProject project = (CProject)pSelItem.Tag;

                lvProjects.Items.Remove(pSelItem);
                CJsonDatabase.Instance.Remove(project.szGuid);
                CJsonDatabase.Instance.Save(CDefines.JSON_FILE_NAME);

                pgProject.SelectedObject = null;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
        #endregion

        #region "UI Functions"
        private void PopulateProjectListView(string name = "", int status=-1)
        {
            CProject[] projects = CJsonDatabase.Instance.GetProjects(name, status);

            lvProjects.BeginUpdate();
            lvProjects.Items.Clear();
            foreach(CProject proj in projects)
            {
                lvProjects.Items.Add(proj.CreateListViewItem(CDefines.UI_LISTVIEW_PROJECTS));
            }
            lvProjects.EndUpdate();
        }
        private void PopulateStatusDropDown()
        {
            cbStatus.BeginUpdate();
            cbStatus.Items.Clear();
            cbStatus.Items.Add("Any Status");
            cbStatus.Items.AddRange(CDefines.PROJ_STATUS_LABELS);
            cbStatus.SelectedIndex = 0;
            cbStatus.EndUpdate();
        }
        private void PopulateProjectListViewHeaders()
        {
            lvProjects.BeginUpdate();
            lvProjects.Columns.Clear();
            CColHdr[] hdrs = CDefines.UI_COLUMNS_PROJECTS;
            lvProjects.Columns.AddRange(hdrs);
            RefreshColumnWidths();
            lvProjects.EndUpdate();
        }

        private void RefreshColumnWidths()
        {
            foreach(ColumnHeader hdr in lvProjects.Columns)
            {
                hdr.Width = -2;
            }
        }
        #endregion
    }
}
