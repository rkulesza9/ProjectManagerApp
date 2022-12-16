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
    public partial class fmResources : Form
    {
        public string m_szProjectGuid;
        public fmResources(string szProjectGuid)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            lvRes.ListViewItemSorter = new CListViewComparer(CDefines.UI_LISTVIEW_RESOURCES, 0, SortOrder.Ascending);
            lvRes.ColumnClick += LvRes_ColumnClick;
            lvRes.DoubleClick += LvRes_DoubleClick;
            pgRes.PropertyValueChanged += PgRes_PropertyValueChanged;

            m_szProjectGuid = szProjectGuid;
            PopulateResListViewHeaders();
            PopulateResListView();
        }

        #region "Events"
        private void LvRes_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (lvRes.SelectedItems.Count == 0) return;

                CListViewItem pSelItem = (CListViewItem)lvRes.SelectedItems[0];
                CResource pRes = (CResource)pSelItem.Tag;

                Process.Start(pRes.m_szPath);

            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private void PgRes_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            try
            {
                RefreshColumnWidths();
            } catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
        private void LvRes_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            try
            {
                CListViewComparer comparer = (CListViewComparer)lvRes.ListViewItemSorter;
                int nColumn = e.Column;
                SortOrder pOrder = comparer.m_pSortOrder == SortOrder.Ascending ? SortOrder.Descending : SortOrder.Ascending;

                lvRes.ListViewItemSorter = new CListViewComparer(CDefines.UI_LISTVIEW_RESOURCES, nColumn, pOrder);

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
        private void lvRes_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (lvRes.SelectedItems.Count == 0) return;

                CListViewItem pSelItem = (CListViewItem)lvRes.SelectedItems[0];
                CResource pRes = (CResource)pSelItem.Tag;

                pgRes.SelectedObject = pRes;
                
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

        }
        private void btnAddRes_Click(object sender, EventArgs e)
        {
            try
            {
                CResource res = (CResource)CJsonDatabase.Instance.Fetch(CDefines.TYPE_RESOURCE, "");
                res.nProjectID = CJsonDatabase.Instance.Fetch(CDefines.TYPE_PROJECT, m_szProjectGuid).m_nID;
                CListViewItem item = res.CreateListViewItem(CDefines.UI_LISTVIEW_RESOURCES);

                lvRes.Items.Add(item);
                lvRes.SelectedItems.Clear();
                item.Selected = true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private void btnDeleteRes_Click(object sender, EventArgs e)
        {
            try
            {
                if (lvRes.SelectedItems.Count == 0) return;
                if (DialogResult.Yes != MessageBox.Show("Are You Sure You Want To Delete This Resource?", "Delete Selected Resource", MessageBoxButtons.YesNo)) return;
                CListViewItem pSelItem = (CListViewItem)lvRes.SelectedItems[0];
                CResource pRes = (CResource)pSelItem.Tag;

                lvRes.Items.Remove(pSelItem);
                CJsonDatabase.Instance.Remove(pRes.szGuid);
                CJsonDatabase.Instance.Save(CDefines.JSON_FILE_NAME);

                pgRes.SelectedObject = null;
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

                if (lvRes.SelectedItems.Count == 0) return;

                CListViewItem pSelItem = (CListViewItem)lvRes.SelectedItems[0];
                CResource pRes = (CResource)pSelItem.Tag;

                pRes.bPinned = !pRes.bPinned;

                CListViewComparer lvc = (CListViewComparer)lvRes.ListViewItemSorter;
                lvRes.ListViewItemSorter = null;
                lvRes.ListViewItemSorter = lvc;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                PopulateResListView(tbSearch.Text);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                PopulateResListView("");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
        #endregion

        #region "UI Functions"
        public void PopulateResListView(string search="")
        {
            CResource[] resources = CJsonDatabase.Instance.GetResourcesFor(m_szProjectGuid, search);

            lvRes.BeginUpdate();
            lvRes.Items.Clear();
            foreach(CResource res in resources)
            {
                lvRes.Items.Add(res.CreateListViewItem(CDefines.UI_LISTVIEW_RESOURCES));
            }
            lvRes.EndUpdate();
        }
        public void PopulateResListViewHeaders()
        {
            lvRes.BeginUpdate();
            lvRes.Columns.Clear();
            CColHdr[] hdrs = CDefines.UI_COLUMNS_RESOURCES;
            lvRes.Columns.AddRange(hdrs);
            RefreshColumnWidths();
            lvRes.EndUpdate();
        }
        private void RefreshColumnWidths()
        {
            foreach (ColumnHeader hdr in lvRes.Columns)
            {
                hdr.Width = -2;
            }
        }
        #endregion

    }
}
