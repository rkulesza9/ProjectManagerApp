using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementApp
{
    public class CDefines
    {
        public static readonly string JSON_DEFAULT_FILE_NAME = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\ProjectManagerConfig.json";

        public const int TYPE_PROJECT = 0;
        public const int TYPE_RESOURCE = 1;
        public const int TYPE_NOTEBOOK_PAGE = 2;
        public const int TYPE_PROJECT_TYPE = 3;
        public const int TYPE_PROJECT_STATUS = 4;

        public const int UI_LISTVIEW_PROJECTS = 0;
        public const int UI_LISTVIEW_RESOURCES = 1;
        public const int UI_LISTVIEW_LABELS = 2;

        public static CColHdr[] UI_COLUMNS_PROJECTS
        {
                get {
                    return new CColHdr[]
                        {
                            new CColHdr("Name"),
                            new CColHdr("Type"),
                            new CColHdr("Status"),
                            new CColHdr("Last Worked On"),
                            new CColHdr("Short Note"),
                            //new CColHdr("Main Developer"),
                            //new CColHdr("Main Contact"),
                        };
                }
        }

        public static CColHdr[] UI_COLUMNS_RESOURCES
        {
            get
            {
                return new CColHdr[]
                {
                    new CColHdr("Name"),
                    new CColHdr("Description")

                };
            }
        }

        public static CColHdr[] UI_COLUMNS_LABEL
        {
            get
            {
                return new CColHdr[]
                {
                    new CColHdr("Sort Order"),
                    new CColHdr("Label Text")
                };
            }
        }

        //⦁	Add "Type" to project manager including "Desktop Application", "Web Application", "Access Application", "Database", "SSRS Report"

        //public const int PROJ_TYPE_DESKTOP = 0;
        //public const int PROJ_TYPE_WEB = 1;
        //public const int PROJ_TYPE_DATABASE = 2;
        //public const int PROJ_TYPE_RESOURCES = 3;
        //public const int PROJ_TYPE_TIME_MNGMT = 4;
        //public const int PROJ_TYPE_ML = 5;
        //public const int PROJ_TYPE_MATH = 6;
        //public const int PROJ_TYPE_SERVER_MGMT = 7;
        //public const int PROJ_TYPE_VIDEOGAME = 8;
        //public const int PROJ_TYPE_HEALTH = 9;
        //public const int PROJ_TYPE_OTHER = 10;

        //public static readonly string[] PROJ_TYPE_LABELS =
        //{
        //    "Desktop App",
        //    "Web App",
        //    "Database",
        //    "Gen. Resources",
        //    "Time Management",
        //    "Machine Learning",
        //    "Mathematics",
        //    "Server Management",
        //    "Videogame",
        //    "Health",
        //    "Other"
        //};

        //public const int PROJ_STATUS_NEW = 0;
        //public const int PROJ_STATUS_ACTIVE = 1;
        //public const int PROJ_STATUS_ON_HOLD = 2;
        //public const int PROJ_STATUS_INACTIVE = 3;
        //public const int PROJ_STATUS_COMPLETED = 4;
        //public const int PROJ_STATUS_CANCELED = 5;

        //public static readonly string[] PROJ_STATUS_LABELS = new string[]
        //{
        //    "New",
        //    "Active",
        //    "On Hold",
        //    "Inactive",
        //    "Completed",
        //    "Canceled"
        //};

        public const int PROJ_SRCCTRL_GIT = 0;
        public const int PROJ_SRCCTRL_SOURCESAFE = 1;

        public static readonly string[] PROJ_SRCCTRL_LABELS = new string[]
        {
            "Git",
            "Source Safe"
        };

        public static readonly string[] PROJ_SRCCTRL_CMDS = new string[]
        {
            "/K \"{0}: && cd {1} && git status\"",
            ""
        };

        

        public const string SETTINGS_LAST_OPENED_FILE = "szLastOpenedFile";

        
    }
}
