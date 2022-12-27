using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementApp
{
    public class CResource : CBaseData
    {
        // json friendly
        public string m_szName;
        public string m_szDescription;
        public string m_szPath;
        public int m_nProjectID;
        public bool m_bUniversal;

        public CResource() : base() { }


        public override void Clear()
        {
            base.Clear();
            try
            {
                m_nTypeID = CDefines.TYPE_RESOURCE;
                m_szName = "New Resource";
                m_szDescription = "This is a new resource.";
                m_szPath = "C:\\";
                m_nProjectID = -1;
                m_bUniversal = false;
                
            }catch(Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        public override void UpdateListViewItem(ref CListViewItem item)
        {
            try
            {
                int nListViewTypeID = item.m_nListViewTypeID;

                item.Text = "";
                item.SubItems.Clear();
                switch (nListViewTypeID)
                {
                    case CDefines.UI_LISTVIEW_RESOURCES:
                        item.Text = m_szName;
                        item.SubItems.Add(m_szDescription);
                        break;
                    default:
                        break;
                }


                // highlight pinned items
                if (m_bPinned) item.BackColor = Color.Yellow;
                else if (m_bUniversal) item.BackColor = Color.Beige;
                else item.BackColor = Color.White;
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        #region "property grid"
        [JsonIgnore]
        [ReadOnly(true)]
        [Browsable(false)]
        [Category("Properties")]
        [DisplayName("Project")]
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
        [JsonIgnore]
        [ReadOnly(true)]
        [Browsable(true)]
        [Category("Properties")]
        [DisplayName("Project")]
        public string szProject
        {
            get {
                if (m_nProjectID == -1) return "";
                return ((CProject) CJsonDatabase.Instance.Fetch(CDefines.TYPE_PROJECT, m_nProjectID)).m_szName; 
            }
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
        [DisplayName("Description")]
        public string szDescription
        {
            get { return m_szDescription; }
            set
            {
                m_szDescription = value;
                m_dtLastUpdated = DateTime.Now;
                CJsonDatabase.Instance.Save(CJsonDatabase.Instance.m_szFileName);
                UpdateUI();
            }
        }
        [JsonIgnore]
        [ReadOnly(false)]
        [Browsable(true)]
        [Category("Properties")]
        [DisplayName("Path")]
        public string szPath
        {
            get { return m_szPath; }
            set
            {
                m_szPath = value;
                m_dtLastUpdated = DateTime.Now;
                CJsonDatabase.Instance.Save(CJsonDatabase.Instance.m_szFileName);
                UpdateUI();
            }
        }
        [JsonIgnore]
        [ReadOnly(false)]
        [Browsable(true)]
        [Category("Properties")]
        [DisplayName("Is Universal Resource")]
        public bool bUniversal
        {
            get { return m_bUniversal; }
            set
            {
                m_bUniversal = value;
                m_dtLastUpdated = DateTime.Now;
                CJsonDatabase.Instance.Save(CJsonDatabase.Instance.m_szFileName);
                UpdateUI();
            }
        }
        
        #endregion
    }
}
