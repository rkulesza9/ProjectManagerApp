using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementApp
{
    public class CJsonDatabase
    {
        // json ignore
        [JsonIgnore]
        public Hashtable m_pData;
        [JsonIgnore]
        public string m_szFileName;

        //json friendly
        public List<CProject> m_lsProjects;
        public List<CResource> m_lsResources;
        public List<CNotebookPage> m_lsNotebookPages;
        public List<CProjectStatus> m_lsProjectStatuses;
        public List<CProjectType> m_lsProjectTypes;

        public CJsonDatabase() 
        {
            Initialize();
            
        }

        public void Initialize()
        {
            if(m_pData == null) m_pData = new Hashtable();
            if(m_lsProjects == null) m_lsProjects = new List<CProject>();
            if (m_lsResources == null) m_lsResources = new List<CResource>();
            if (m_szFileName == null) m_szFileName = "";
            if (m_lsNotebookPages == null) m_lsNotebookPages = new List<CNotebookPage>();
            if (m_lsProjectTypes == null) m_lsProjectTypes = new List<CProjectType>();
            if (m_lsProjectStatuses == null) m_lsProjectStatuses = new List<CProjectStatus>();
        }

        public void PopulateDataTable()
        {
            Initialize();
            m_pData.Clear();
            foreach(CProject proj in m_lsProjects)
            {
                m_pData.Add(proj.m_szGuid, proj);
            }
            foreach(CResource res in m_lsResources)
            {
                m_pData.Add(res.m_szGuid, res);
            }
            foreach(CNotebookPage pg in m_lsNotebookPages)
            {
                m_pData.Add(pg.m_szGuid, pg);
            }
            foreach (CProjectType tp in m_lsProjectTypes)
            {
                m_pData.Add(tp.m_szGuid, tp);
            }
            foreach (CProjectStatus s in m_lsProjectStatuses)
            {
                m_pData.Add(s.m_szGuid, s);
            }

        }

        public CBaseData Fetch(int nTypeID, string szGuid)
        {
            if (m_pData.ContainsKey(szGuid)) return (CBaseData) m_pData[szGuid];
            else if(szGuid == "")
            {
                return NewData(nTypeID);
            }
            else return null;
        }
        public CBaseData Fetch(int nTypeID, int nID)
        {
            if (nID == -1) return NewData(nTypeID);
            else foreach (CBaseData data in m_pData.Values) if (data.m_nTypeID==nTypeID && data.m_nID == nID) return data;

            return null;
            
        }
        public void PopulateDefaultLabels()
        {
            m_lsProjectTypes.Clear();
            string[] lsProjTypes = new string[]
            {
                "Desktop App", "Web App", "Database", "Gen. Resources",
                "Time Management", "Machine Learning", "Mathematics", "Server Management",
                "Videogame", "Health", "Other"
            };
            foreach (string szLabel in lsProjTypes)
            {
                ((CProjectType)Fetch(CDefines.TYPE_PROJECT_TYPE, -1)).m_szText = szLabel;
            }

            m_lsProjectStatuses.Clear();
            string[] lsStatus = new string[]
            {
                "New",
                "Active",
                "On Hold",
                "Inactive",
                "Completed",
                "Canceled"
            };
            foreach (string szLabel in lsStatus)
            {
                ((CProjectStatus)Fetch(CDefines.TYPE_PROJECT_STATUS, -1)).m_szText = szLabel;
            }
        }
        public int GetIDForLabel(int nLabelTypeID, string szText)
        {
            int nID = -1;

            if (nLabelTypeID == CDefines.TYPE_PROJECT_TYPE)
            {
                List<CProjectType> lsTypes = m_lsProjectTypes.Where((t) =>
                {
                    return t.m_szText.Equals(szText);
                }).ToList();
                if (lsTypes.Count > 0) nID = lsTypes[0].m_nID;
            }
            else if (nLabelTypeID == CDefines.TYPE_PROJECT_STATUS)
            {
                List<CProjectStatus> lsStatus = m_lsProjectStatuses.Where((s) =>
                {
                    return s.m_szText.Equals(szText);
                }).ToList();
                if (lsStatus.Count > 0) nID = lsStatus[0].m_nID;
            }

            return nID;
        }
        public string[] GetProjectTypeLabels()
        {
            List<CProjectType> lsTypes = m_lsProjectTypes;
            string[] labels = new string[lsTypes.Count];
            for (int x = 0; x < labels.Length; x++)
            {
                labels[x] = lsTypes[x].m_szText;
            }
            return labels;
        }
        public string[] GetProjectStatusLabels()
        {
            List<CProjectStatus> lsStatus = m_lsProjectStatuses;
            string[] labels = new string[lsStatus.Count];
            for (int x = 0; x < labels.Length; x++)
            {
                labels[x] = lsStatus[x].m_szText;
            }
            return labels;
        }
        public CProject[] GetProjects(string text="", int type = -1, int status = -1)
        {
            string[] szTerms = text.ToLower().Split(' ');

            return m_lsProjects.Where((proj) =>
            {
                bool bTextFound = true;
                string szSearchArea = (proj.m_szName + proj.m_szShortNote + proj.m_szLongNote+proj.m_szMainContact+proj.m_szMainDeveloper).ToLower();
                foreach (string szTerm in szTerms)
                {
                    bTextFound = szSearchArea.Trim().Contains(szTerm.Trim());
                    if (!bTextFound) break;
                }
                return (text.Equals("") || bTextFound) &&
                       (status == -1 || proj.m_nStatusID == status) &&
                       (type == -1 || proj.m_nProjTypeID == type);
                
            }).ToArray();
        }
        public CResource[] GetResourcesFor(string szProjectGuid, string search = "")
        {
            return m_lsResources.Where((res) =>
            {
                CProject proj = (CProject)Fetch(CDefines.TYPE_PROJECT, szProjectGuid);
                return ((res.m_nProjectID == proj.m_nID) || (res.m_bUniversal)) && 
                       ((res.m_szName.Contains(search)) || (res.m_szDescription.Contains(search)));
            }).ToArray();
        }
        public CNotebookPage[] GetNotebookPagesFor(string szProjectGuid)
        {
            return m_lsNotebookPages.Where((pg) =>
            {
                CProject proj = (CProject)Fetch(CDefines.TYPE_PROJECT, szProjectGuid);
                return proj.m_nID == pg.m_nProjectID;
            }).OrderBy((pg) =>
            {
                return pg.m_nOrder;
            }).ToArray();
        }

        public CBaseData Remove(string szGuid)
        {
            CBaseData result = (CBaseData) m_pData[szGuid];
            m_pData.Remove(szGuid);

            if (result.GetType() == typeof(CProject)) m_lsProjects.Remove((CProject)result);
            if (result.GetType() == typeof(CResource)) m_lsResources.Remove((CResource)result);
            if (result.GetType() == typeof(CNotebookPage)) m_lsNotebookPages.Remove((CNotebookPage)result);
            if (result.GetType() == typeof(CProjectType)) m_lsProjectTypes.Remove((CProjectType)result);
            if (result.GetType() == typeof(CProjectStatus)) m_lsProjectStatuses.Remove((CProjectStatus)result);

            return result;
        }

        public int NewID(int nTypeID)
        {
            int nMaxID = -1;
            int nID = -1;
            switch (nTypeID)
            {
                case CDefines.TYPE_PROJECT:
                    if(m_lsProjects.Count > 0) nMaxID = m_lsProjects.Max((proj) => { return proj.m_nID; });
                    nID = nMaxID + 1;
                    break;
                case CDefines.TYPE_RESOURCE:
                    if (m_lsResources.Count > 0 ) nMaxID = m_lsResources.Max((res) => { return res.m_nID; });
                    nID = nMaxID + 1;
                    break;
                case CDefines.TYPE_NOTEBOOK_PAGE:
                    if (m_lsNotebookPages.Count > 0) nMaxID = m_lsNotebookPages.Max((pg) => { return pg.m_nID; });
                    nID = nMaxID + 1;
                    break;
                case CDefines.TYPE_PROJECT_TYPE:
                    if (m_lsProjectTypes.Count > 0) nMaxID = m_lsProjectTypes.Max((pt) => { return pt.m_nID; });
                    nID = nMaxID + 1;
                    break;
                case CDefines.TYPE_PROJECT_STATUS:
                    if (m_lsProjectStatuses.Count > 0) nMaxID = m_lsProjectStatuses.Max((pt) => { return pt.m_nID; });
                    nID = nMaxID + 1;
                    break;
                default:
                    break;
            }
            return nID;
        }

        public CBaseData NewData(int nTypeID)
        {
            CBaseData data = null;

            switch (nTypeID)
            {
                case CDefines.TYPE_PROJECT:
                    data = new CProject();
                    data.m_nID = NewID(nTypeID);
                    m_lsProjects.Add((CProject) data);
                    break;
                case CDefines.TYPE_RESOURCE:
                    data = new CResource();
                    data.m_nID = NewID(nTypeID);
                    m_lsResources.Add((CResource)data);
                    break;
                case CDefines.TYPE_NOTEBOOK_PAGE:
                    data = new CNotebookPage();
                    data.m_nID = NewID(nTypeID);
                    m_lsNotebookPages.Add((CNotebookPage)data);
                    break;
                case CDefines.TYPE_PROJECT_TYPE:
                    data = new CProjectType();
                    data.m_nID = NewID(nTypeID);
                    m_lsProjectTypes.Add((CProjectType)data);
                    break;
                case CDefines.TYPE_PROJECT_STATUS:
                    data = new CProjectStatus();
                    data.m_nID = NewID(nTypeID);
                    m_lsProjectStatuses.Add((CProjectStatus)data);
                    break;
                default:
                    break;
            }

            m_pData.Add(data.szGuid, data);
            return data;
        }

        public void Save(string szFileName)
        {
            string szJson = JsonConvert.SerializeObject(this, Formatting.Indented);
            File.WriteAllText(szFileName, szJson);
        }

        // static objects and functions
        [JsonIgnore]
        public static CJsonDatabase Instance;
        public static void Initialize(string szFileName)
        {
            try
            {
                if (!File.Exists(szFileName)) File.Create(szFileName).Close();
                string szJson = File.ReadAllText(szFileName);
                Instance = JsonConvert.DeserializeObject<CJsonDatabase>(szJson);
                if (Instance != null) Instance.PopulateDataTable();
                else
                {
                    Instance = new CJsonDatabase();
                    Instance.PopulateDefaultLabels();
                    Instance.PopulateDataTable();

                }
                Instance.m_szFileName = szFileName;

            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        
    }
}
