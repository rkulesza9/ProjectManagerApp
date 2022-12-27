using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectManagementApp
{
    public abstract class CBaseData
    {
        #region "Members & Constructors"
        // Not Stored In JSON
        [JsonIgnore]
        public ArrayList m_lsUIControls;
        [JsonIgnore]
        public int m_nTypeID;

        // Stored In Json
        public int m_nID;
        public bool m_bPinned;
        public string m_szGuid;
        public DateTime m_dtLastUpdated;
        
        public CBaseData()
        {
            try
            {
                Clear();
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
        #endregion

        #region "override me"
        public virtual void Clear()
        {
            try
            {
                m_lsUIControls = new ArrayList();
                m_nTypeID = -1;
                m_nID = -1;
                m_bPinned = false;
                m_szGuid = Guid.NewGuid().ToString();
                m_dtLastUpdated = DateTime.Now;
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
        #endregion

        #region "Front End"
        public CListViewItem CreateListViewItem(int nListViewTypeID)
        {
            CListViewItem item = new CListViewItem();
            item.m_nListViewTypeID = nListViewTypeID;
            item.Tag = this;

            m_lsUIControls.Add(item);
            UpdateListViewItem(ref item);

            return item;
        }

        public abstract void UpdateListViewItem(ref CListViewItem item);
        
        public void UpdateUI()
        {
            foreach(object control in m_lsUIControls)
            {
                if(control.GetType() == typeof(CListViewItem))
                {
                    CListViewItem item = (CListViewItem)control;
                    UpdateListViewItem(ref item);
                }
            }
        }

        #endregion

        #region "PropertyGrid Properties"	
        [JsonIgnore]
        [ReadOnly(true)]
        [Browsable(true)]
        [Category("System")]
        [DisplayName("Guid")]
        public string szGuid
        {
            get
            {
                return m_szGuid;
            }
        }

        [JsonIgnore]
        [ReadOnly(true)]
        [Browsable(true)]
        [Category("System")]
        [DisplayName("Date Last Updated")]
        public DateTime dtLastUpdated
        {
            get
            {
                return m_dtLastUpdated;
            }
            set
            {
                m_dtLastUpdated = DateTime.Now;
                CJsonDatabase.Instance.Save(CJsonDatabase.Instance.m_szFileName);
                UpdateUI();
            }
        }

        [JsonIgnore]
        [ReadOnly(true)]
        [Browsable(true)]
        [Category("System")]
        [DisplayName("Pinned")]
        public bool bPinned
        {
            get
            {
                return m_bPinned;
            }
            set
            {
                m_bPinned = value;
                CJsonDatabase.Instance.Save(CJsonDatabase.Instance.m_szFileName);
                UpdateUI();
            }
        }
        #endregion
    }
    public class CListViewItem : ListViewItem
    {
        public CListViewItem()
        {

        }

        public int m_nListViewTypeID = -1;
    }
}
