using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementApp
{
    public class CProjectStatus : CBaseData
    {
        // json friendly
        public string m_szText;

        public CProjectStatus() : base()
        {

        }
        public CProjectStatus(string szText) : base()
        {
            m_szText = szText;
        }

        public override void Clear()
        {
            base.Clear();

            try
            {
                m_nTypeID = CDefines.TYPE_PROJECT_STATUS;
                m_szText = "< New Status >";

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        public override void UpdateListViewItem(ref CListViewItem item)
        {
            int nListViewTypeID = item.m_nListViewTypeID;

            item.Text = "";
            item.SubItems.Clear();
            switch (nListViewTypeID)
            {
                case CDefines.UI_LISTVIEW_LABELS:
                    item.Text = m_szText;
                    break;
                default:
                    break;
            }
        }

        #region "propertygrid"
        [JsonIgnore]
        [ReadOnly(false)]
        [Browsable(true)]
        [Category("Properties")]
        [DisplayName("Label Text")]
        public string szText
        {
            get { return m_szText; }
            set
            {
                m_szText = value;
                m_dtLastUpdated = DateTime.Now;
                CJsonDatabase.Instance.Save(CJsonDatabase.Instance.m_szFileName);
                UpdateUI();
            }
        }
        #endregion
    }

}