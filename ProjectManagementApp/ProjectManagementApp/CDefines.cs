using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementApp
{
    public class CDefines
    {
        public static string JSON_FILE_NAME = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\ProjectManagerConfig.json";

        public const int TYPE_PROJECT = 0;
        public const int TYPE_RESOURCE = 1;

        public const int UI_LISTVIEW_PROJECTS = 0;
        public const int UI_LISTVIEW_RESOURCES = 1;
        public static CColHdr[] UI_COLUMNS_PROJECTS
        {
                get {
                    return new CColHdr[]
                        {
                            new CColHdr("Name"),
                            new CColHdr("Status"),
                            new CColHdr("Last Worked On"),
                            new CColHdr("Short Note")
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


        public const int PROJ_STATUS_NEW = 0;
        public const int PROJ_STATUS_ACTIVE = 1;
        public const int PROJ_STATUS_ON_HOLD = 2;
        public const int PROJ_STATUS_INACTIVE = 3;
        public const int PROJ_STATUS_COMPLETED = 4;
        public const int PROJ_STATUS_CANCELED = 5;

        public static string[] PROJ_STATUS_LABELS = new string[]
        {
            "New",
            "Active",
            "On Hold",
            "Inactive",
            "Completed",
            "Canceled"
        };
    }
}
