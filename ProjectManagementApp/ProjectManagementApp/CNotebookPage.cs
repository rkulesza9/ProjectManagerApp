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
    public class CNotebookPage : CBaseData
    {
        // json friendly
        public string m_szName;
        public string m_szText;
        public int m_nProjectID;

        public CNotebookPage()
        {

        }

        public override void Clear()
        {
            base.Clear();
            try
            {
                m_nTypeID = CDefines.TYPE_NOTEBOOK_PAGE;
                m_szName = "New Page";
                m_szText = "";
                m_nProjectID = -1;
            }catch(Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        public override void UpdateListViewItem(ref CListViewItem item)
        {
            return;
        }


        [JsonIgnore]
        [ReadOnly(false)]
        [Browsable(true)]
        [Category("Properties")]
        [DisplayName("Name")]
        public string szName
        {
            get { return m_szName; }
            set
            {
                m_szName = value;
                m_dtLastUpdated = DateTime.Now;
                CJsonDatabase.Instance.Save(CJsonDatabase.Instance.m_szFileName);
                UpdateUI();
            }
        }
        [JsonIgnore]
        [ReadOnly(false)]
        [Browsable(true)]
        [Category("Properties")]
        [DisplayName("Text")]
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
        [JsonIgnore]
        [ReadOnly(true)]
        [Browsable(true)]
        [Category("Properties")]
        [DisplayName("Project")]
        public string szProject
        {
            get { return ((CProject)CJsonDatabase.Instance.Fetch(CDefines.TYPE_PROJECT, m_nProjectID)).m_szName;  }
        }
        [JsonIgnore]
        [ReadOnly(true)]
        [Browsable(false)]
        [Category("Properties")]
        [DisplayName("Project ID")]
        public int nProjectID
        {
            get { return m_nProjectID; }
            set
            {
                m_nProjectID = value;
                m_dtLastUpdated = DateTime.Now;
                CJsonDatabase.Instance.Save(CJsonDatabase.Instance.m_szFileName);
                UpdateUI();
            }
        }
    }
}
