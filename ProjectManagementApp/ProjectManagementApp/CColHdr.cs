using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectManagementApp
{
    public class CColHdr : ColumnHeader
    {
        public CColHdr(string szText) : base() 
        {
            Text = szText;
            
        }
    }
}
