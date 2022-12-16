﻿using Newtonsoft.Json;
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
                m_nStatusID = CDefines.PROJ_STATUS_NEW;
                m_dtLastWorkedOn = DateTime.Now;
                m_szProjectDir = "C:\\";
                m_szWrikeUrl = "https://wrike.com";
                m_szShortNote = "";
                m_szLongNote = $"Project Created On {m_dtLastWorkedOn}.";
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
                    item.SubItems.Add(szStatus);
                    item.SubItems.Add(m_dtLastWorkedOn.ToShortDateString());
                    item.SubItems.Add(m_szShortNote);
                    break;
                default:
                    break;
            }

            // highlight pinned items
            if (m_bPinned) item.BackColor = Color.Yellow;
            else item.BackColor = Color.White;
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
                CJsonDatabase.Instance.Save(CDefines.JSON_FILE_NAME);
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
            get { return CDefines.PROJ_STATUS_LABELS[m_nStatusID]; }
            set
            {
                for (int x = 0; x < CDefines.PROJ_STATUS_LABELS.Length; x++)
                {
                    if (CDefines.PROJ_STATUS_LABELS[x].Equals(value))
                    {
                        m_nStatusID = x;
                        break;
                    }
                }

                CJsonDatabase.Instance.Save(CDefines.JSON_FILE_NAME);
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
                CJsonDatabase.Instance.Save(CDefines.JSON_FILE_NAME);
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
                CJsonDatabase.Instance.Save(CDefines.JSON_FILE_NAME);
                UpdateUI();
            }
        }

        [JsonIgnore]
        [ReadOnly(false)]
        [Browsable(true)]
        [Category("Properties")]
        [DisplayName("Wrike Url")]
        public string szWrikeUrl
        {
            get { return m_szWrikeUrl; }
            set
            {
                m_szWrikeUrl = value;
                CJsonDatabase.Instance.Save(CDefines.JSON_FILE_NAME);
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
                CJsonDatabase.Instance.Save(CDefines.JSON_FILE_NAME);
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
                CJsonDatabase.Instance.Save(CDefines.JSON_FILE_NAME);
                UpdateUI();
            }
        }

        #endregion
    }
}
