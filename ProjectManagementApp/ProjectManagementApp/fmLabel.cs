using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectManagementApp
{
    public partial class fmLabel : Form
    {
        public int m_nLabelTypeID;
        public delegate void LabelsUpdated();
        public LabelsUpdated OnLabelsUpdated;
        public fmLabel(int nLabelTypeID)
        {
            InitializeComponent();
            m_nLabelTypeID = nLabelTypeID;
            StartPosition = FormStartPosition.CenterScreen;
            FormClosed += FmLabel_FormClosed;
            pgLabel.PropertyValueChanged += PgLabel_PropertyValueChanged;
            lvLabels.ListViewItemSorter = new CListViewComparer(CDefines.UI_LISTVIEW_LABELS, 0, SortOrder.Ascending);
            lvLabels.ColumnClick += LvLabels_ColumnClick;
            lvLabels.SelectedIndexChanged += LvLabels_SelectedIndexChanged;
            btnAddLabel.Click += btnAddLabel_Click;
            btnDeleteLabel.Click += btnDeleteLabel_Click;

            PopulateListViewHeaders();
            PopulateListView(m_nLabelTypeID);

            Text = m_nLabelTypeID == CDefines.TYPE_PROJECT_TYPE ? "Project Types" :
                   m_nLabelTypeID == CDefines.TYPE_PROJECT_STATUS ? "Project Status" : "Something's Not Right";

            fmProjectManager.m_pOpenForms.Add(this);
        }

        private void LvLabels_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (lvLabels.SelectedItems.Count == 0) return;

                CListViewItem pSelItem = (CListViewItem)lvLabels.SelectedItems[0];
                CBaseData pLabel = (CBaseData)pSelItem.Tag;

                pgLabel.SelectedObject = pLabel;

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private void LvLabels_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            try
            {
                CListViewComparer comparer = (CListViewComparer)lvLabels.ListViewItemSorter;
                int nColumn = e.Column;
                SortOrder pOrder = comparer.m_pSortOrder == SortOrder.Ascending ? SortOrder.Descending : SortOrder.Ascending;

                lvLabels.ListViewItemSorter = new CListViewComparer(CDefines.UI_LISTVIEW_LABELS, nColumn, pOrder);

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private void PgLabel_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            try
            {
                RefreshColumnWidths();
                OnLabelsUpdated();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
        private void FmLabel_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                fmProjectManager.m_pOpenForms.Remove(this);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private void PopulateListViewHeaders()
        {
            lvLabels.BeginUpdate();
            lvLabels.Columns.Clear();
            CColHdr[] hdrs = CDefines.UI_COLUMNS_LABEL;
            lvLabels.Columns.AddRange(hdrs);
            RefreshColumnWidths();
            lvLabels.EndUpdate();

        }
        private void PopulateListView(int nLabelTypeID)
        {
            List<CBaseData> lsLabels = new List<CBaseData>();
            if (nLabelTypeID == CDefines.TYPE_PROJECT_TYPE)
            {
                lsLabels = new List<CBaseData>(CJsonDatabase.Instance.m_lsProjectTypes);
            }
            else if (nLabelTypeID == CDefines.TYPE_PROJECT_STATUS)
            {
                lsLabels = new List<CBaseData>(CJsonDatabase.Instance.m_lsProjectStatuses);
            }

            lvLabels.BeginUpdate();
            lvLabels.Items.Clear();
            foreach (CBaseData lbl in lsLabels)
            {
                lvLabels.Items.Add(lbl.CreateListViewItem(CDefines.UI_LISTVIEW_LABELS));
            }
            lvLabels.EndUpdate();
        }
        private void RefreshColumnWidths()
        {
            foreach (ColumnHeader hdr in lvLabels.Columns)
            {
                hdr.Width = -2;
            }
        }

        private void btnAddLabel_Click(object sender, EventArgs e)
        {
            try
            {
                CBaseData label = CJsonDatabase.Instance.Fetch(m_nLabelTypeID, "");
                CListViewItem item = label.CreateListViewItem(CDefines.UI_LISTVIEW_LABELS);

                lvLabels.Items.Add(item);
                lvLabels.SelectedItems.Clear();
                item.Selected = true;

                OnLabelsUpdated();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private void btnDeleteLabel_Click(object sender, EventArgs e)
        {
            try
            {
                if (lvLabels.SelectedItems.Count == 0) return;
                if (DialogResult.Yes != MessageBox.Show("Are You Sure You Want To Delete This Label?", "Delete Selected Label", MessageBoxButtons.YesNo)) return;
                CListViewItem pSelItem = (CListViewItem)lvLabels.SelectedItems[0];
                CBaseData pLabel = (CBaseData)pSelItem.Tag;

                lvLabels.Items.Remove(pSelItem);
                CJsonDatabase.Instance.Remove(pLabel.m_szGuid);
                CJsonDatabase.Instance.Save(CJsonDatabase.Instance.m_szFileName);

                pgLabel.SelectedObject = null;

                OnLabelsUpdated();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }
}
