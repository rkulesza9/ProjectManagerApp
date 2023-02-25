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
    public class CProjectType : CBaseData
    {
        // json friendly
        public string m_szText;

        public CProjectType() : base()
        {

        }
        public CProjectType(string szText) : base()
        {
            m_szText = szText;
        }

        public override void Clear()
        {
            base.Clear();

            try
            {
                m_nTypeID = CDefines.TYPE_PROJECT_TYPE;
                m_szText = "< New Type >";

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
