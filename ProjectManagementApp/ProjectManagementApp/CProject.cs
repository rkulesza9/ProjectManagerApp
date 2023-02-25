using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectManagementApp
{
    public class CProject : CBaseData
    {
        // json friendly
        public string m_szName;
        public int m_nStatusID;
        public DateTime m_dtLastWorkedOn;
        public string m_szProjectDir;
        public string m_szWrikeUrl;
        public string m_szShortNote;
        public string m_szLongNote;
        public string m_szSourceControlPath;
        public int m_nSourceControlID;
        public string m_szMainDeveloper;
        public string m_szMainContact;
        public int m_nProjTypeID;
        public Color m_pColor;
        
        public CProject() : base()
        {

        }

        public override void Clear()
        {
            base.Clear();

            try
            {
                m_nTypeID = CDefines.TYPE_PROJECT;
                m_szName = "New Project";
                m_nStatusID = -1;
                m_dtLastWorkedOn = DateTime.Now;
                m_szProjectDir = "";
                m_szWrikeUrl = "";
                m_szShortNote = "";
                m_szLongNote = "";
                m_szSourceControlPath = "";
                m_nSourceControlID = CDefines.PROJ_SRCCTRL_GIT;
                m_szMainContact = "N/A";
                m_szMainDeveloper = "N/A";
                m_nProjTypeID = -1;
                m_pColor = Color.White;
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
        public override void UpdateListViewItem(ref CListViewItem item)
        {
            int nListViewTypeID = item.m_nListViewTypeID;

            item.Text = "";
            item.SubItems.Clear();
            switch(nListViewTypeID)
            {
                case CDefines.UI_LISTVIEW_PROJECTS:
                    item.Text = m_szName;
                    item.SubItems.Add(szProjType);
                    item.SubItems.Add(szStatus);
                    item.SubItems.Add(m_dtLastWorkedOn.ToShortDateString());
                    item.SubItems.Add(m_szShortNote);
                    //item.SubItems.Add(m_szMainDeveloper);
                    //item.SubItems.Add(m_szMainContact);
                    break;
                default:
                    break;
            }

            // highlight pinned items
            if (m_bPinned) item.BackColor = Color.Yellow;
            else item.BackColor = m_pColor;
        }

        #region "propertygrid"
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
        [TypeConverter(typeof(CTypeConverters.CProjectTypeConverter))]
        [Category("Properties")]
        [DisplayName("Type")]
        public string szProjType
        {
            get
            {
                CProjectType type = null;
                if (m_nProjTypeID != -1) type = (CProjectType)CJsonDatabase.Instance.Fetch(CDefines.TYPE_PROJECT_TYPE, m_nProjTypeID);

                if (type != null) return type.m_szText;
                else return "";
            }
            set
            {
                List<CProjectType> lsProjTypes = CJsonDatabase.Instance.m_lsProjectTypes;
                List<CProjectType> matches = new List<CProjectType>(lsProjTypes.Where((type) =>
                {
                    return type.m_szText.Equals(value);
                }));
                m_nProjTypeID = matches[0].m_nID;

                m_dtLastUpdated = DateTime.Now;
                CJsonDatabase.Instance.Save(CJsonDatabase.Instance.m_szFileName);
                UpdateUI();
            }
        }

        [JsonIgnore]
        [ReadOnly(false)]
        [Browsable(true)]
        [TypeConverter(typeof(CTypeConverters.CProjectStatusConverter))]
        [Category("Properties")]
        [DisplayName("Status")]
        public string szStatus
        {
            get
            {
                CProjectStatus status = null;
                if (m_nStatusID != -1) status = (CProjectStatus)CJsonDatabase.Instance.Fetch(CDefines.TYPE_PROJECT_STATUS, m_nStatusID);

                if (status != null) return status.m_szText;
                else return "";
            }
            set
            {
                List<CProjectStatus> lsProjStatus = CJsonDatabase.Instance.m_lsProjectStatuses;
                List<CProjectStatus> matches = new List<CProjectStatus>(lsProjStatus.Where((s) =>
                {
                    return s.m_szText.Equals(value);
                }));
                m_nStatusID = matches[0].m_nID;

                m_dtLastUpdated = DateTime.Now;
                CJsonDatabase.Instance.Save(CJsonDatabase.Instance.m_szFileName);
                UpdateUI();
            }
        }

        [JsonIgnore]
        [ReadOnly(false)]
        [Browsable(true)]
        [Category("Properties")]
        [DisplayName("Last Worked On")]
        public DateTime dtLastWorkedOn
        {
            get { return m_dtLastWorkedOn; }
            set
            {
                m_dtLastWorkedOn = value;
                m_dtLastUpdated = DateTime.Now;
                CJsonDatabase.Instance.Save(CJsonDatabase.Instance.m_szFileName);
                UpdateUI();
            }
        }

        [JsonIgnore]
        [ReadOnly(false)]
        [Browsable(true)]
        [Category("Properties")]
        [DisplayName("Project Directory")]
        public string szProjectDir
        {
            get { return m_szProjectDir; }
            set
            {
                m_szProjectDir = value;
                m_dtLastUpdated = DateTime.Now;
                CJsonDatabase.Instance.Save(CJsonDatabase.Instance.m_szFileName);
                UpdateUI();
            }
        }

        [JsonIgnore]
        [ReadOnly(false)]
        [Browsable(false)]
        [Category("Properties")]
        [DisplayName("Wrike Url")]
        public string szWrikeUrl
        {
            get { return m_szWrikeUrl; }
            set
            {
                m_szWrikeUrl = value;
                m_dtLastUpdated = DateTime.Now;
                CJsonDatabase.Instance.Save(CJsonDatabase.Instance.m_szFileName);
                UpdateUI();
            }
        }

        [JsonIgnore]
        [ReadOnly(false)]
        [Browsable(true)]
        [Category("Properties")]
        [DisplayName("Short Note")]
        public string szShortNote
        {
            get { return m_szShortNote; }
            set
            {
                m_szShortNote = value;
                m_dtLastUpdated = DateTime.Now;
                CJsonDatabase.Instance.Save(CJsonDatabase.Instance.m_szFileName);
                UpdateUI();
            }
        }
        [JsonIgnore]
        [ReadOnly(false)]
        [Browsable(false)]
        [Category("Properties")]
        [DisplayName("Long Note")]
        public string szLongNote
        {
            get
            {
                return m_szLongNote;
            }
            set
            {
                m_szLongNote = value;
                m_dtLastUpdated = DateTime.Now;
                CJsonDatabase.Instance.Save(CJsonDatabase.Instance.m_szFileName);
                UpdateUI();
            }
        }
        [JsonIgnore]
        [ReadOnly(false)]
        [Browsable(true)]
        [Category("Properties")]
        [DisplayName("Source Control")]
        [TypeConverter(typeof(CTypeConverters.CProjectSourceControlConverter))]
        public string szSourceControl
        {
            get { return CDefines.PROJ_SRCCTRL_LABELS[m_nSourceControlID]; }
            set
            {
                for(int x = 0; x < CDefines.PROJ_SRCCTRL_LABELS.Length; x++) if(CDefines.PROJ_SRCCTRL_LABELS[x].Equals(value)) m_nSourceControlID=x;
                m_dtLastUpdated = DateTime.Now;
                CJsonDatabase.Instance.Save(CJsonDatabase.Instance.m_szFileName);
                UpdateUI();
            }
        }
        [JsonIgnore]
        [Browsable(false)]
        public int nSourceControlID
        {
            get { return m_nSourceControlID;  }
            set
            {
                m_nSourceControlID = value;
                m_dtLastUpdated = DateTime.Now;
                CJsonDatabase.Instance.Save(CJsonDatabase.Instance.m_szFileName);
                UpdateUI();
            }
        }

        [JsonIgnore]
        [ReadOnly(false)]
        [Browsable(true)]
        [Category("Properties")]
        [DisplayName("Source Control Path")]
        public string szSourceControlPath
        {
            get
            {
                return m_szSourceControlPath;
            }
            set
            {
                m_szSourceControlPath = value;
                m_dtLastUpdated = DateTime.Now;
                CJsonDatabase.Instance.Save(CJsonDatabase.Instance.m_szFileName);
                UpdateUI();
            }
        }
        [JsonIgnore]
        [ReadOnly(false)]
        [Browsable(false)]
        [Category("Properties")]
        [DisplayName("Main Developer")]
        public string szMainDeveloper
        {
            get { return m_szMainDeveloper; }
            set
            {
                m_szMainDeveloper = value;
                m_dtLastUpdated = DateTime.Now;
                CJsonDatabase.Instance.Save(CJsonDatabase.Instance.m_szFileName);
                UpdateUI();

            }
        }
        [JsonIgnore]
        [ReadOnly(false)]
        [Browsable(false)]
        [Category("Properties")]
        [DisplayName("Main Contact")]
        public string szMainContact
        {
            get { return m_szMainContact; }
            set
            {
                m_szMainContact = value;
                m_dtLastUpdated = DateTime.Now;
                CJsonDatabase.Instance.Save(CJsonDatabase.Instance.m_szFileName);
                UpdateUI();
            }
        }
        [JsonIgnore]
        [ReadOnly(false)]
        [Browsable(false)]
        [Category("Properties")]
        [DisplayName("Color")]
        public Color pColor
        {
            get { return m_pColor; }
            set
            {
                m_pColor = value;
                m_dtLastUpdated = DateTime.Now;
                CJsonDatabase.Instance.Save(CJsonDatabase.Instance.m_szFileName);
                UpdateUI();
            }
        }
        #endregion
    }
}
