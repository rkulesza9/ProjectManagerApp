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

        //json friendly
        public List<CProject> m_lsProjects;
        public List<CResource> m_lsResources;

        public CJsonDatabase() 
        {
            Initialize();
            
        }

        public void Initialize()
        {
            if(m_pData == null) m_pData = new Hashtable();
            if(m_lsProjects == null) m_lsProjects = new List<CProject>();
            if (m_lsResources == null) m_lsResources = new List<CResource>();
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

        public CProject[] GetProjects(string text="", int status = -1)
        {
            string[] szTerms = text.ToLower().Split(' ');

            return m_lsProjects.Where((proj) =>
            {
                bool bTextFound = true;
                string szSearchArea = (proj.m_szName + proj.m_szShortNote + proj.m_szLongNote).ToLower();
                foreach (string szTerm in szTerms)
                {
                    bTextFound = szSearchArea.Contains(szTerm);
                    if (!bTextFound) break;
                }
                return (text.Equals("") || bTextFound ) && 
                       ( status == -1 || proj.m_nStatusID==status );
                
            }).ToArray();
        }
        public CResource[] GetResourcesFor(string szProjectGuid, string search = "")
        {
            return m_lsResources.Where((res) =>
            {
                CProject proj = (CProject)Fetch(CDefines.TYPE_PROJECT, szProjectGuid);
                return (res.m_nProjectID == proj.m_nID) && ((res.m_szName.Contains(search)) || (res.m_szDescription.Contains(search)));
            }).ToArray();
        }

        public CBaseData Remove(string szGuid)
        {
            CBaseData result = (CBaseData) m_pData[szGuid];
            m_pData.Remove(szGuid);

            if (result.GetType() == typeof(CProject)) m_lsProjects.Remove((CProject)result);
            if (result.GetType() == typeof(CResource)) m_lsResources.Remove((CResource)result);

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
                if(Instance != null) Instance.PopulateDataTable();
                else
                {
                    Instance = new CJsonDatabase();
                    Instance.PopulateDataTable();
                }

            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        
    }
}
