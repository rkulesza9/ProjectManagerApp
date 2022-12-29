using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectManagementApp
{
    public class CListViewComparer : IComparer
    {
        public int m_nListViewTypeID;
        public int m_nColumn;
        public SortOrder m_pSortOrder;
        public CListViewComparer(int nListViewTypeID, int nColumn, SortOrder pOrder)
        {
            m_nListViewTypeID = nListViewTypeID;
            m_nColumn = nColumn;
            m_pSortOrder = pOrder;
        }

        public int Compare(object x, object y)
        {
            CBaseData xData = GetData(x);
            CBaseData yData = GetData(y);
            CProject xProj, yProj;
            CResource xRes, yRes;
            int nOrder = m_pSortOrder == SortOrder.Ascending ? 1 : -1;

            // pinned should always appear on top
            if (xData.m_bPinned && !yData.m_bPinned) return -1;
            if (yData.m_bPinned && !xData.m_bPinned) return 1;

            switch (m_nListViewTypeID)
            {
                case CDefines.UI_LISTVIEW_PROJECTS:
                    xProj = (CProject)xData;
                    yProj = (CProject)yData;
                    if (m_nColumn == 0) return nOrder * xProj.m_szName.CompareTo(yProj.m_szName);
                    if (m_nColumn == 1) return nOrder * xProj.szStatus.CompareTo(yProj.szStatus);
                    if (m_nColumn == 2) return nOrder * xProj.m_dtLastWorkedOn.CompareTo(yProj.m_dtLastWorkedOn);
                    if (m_nColumn == 3) return nOrder * xProj.m_szShortNote.CompareTo(yProj.m_szShortNote);
                    break;
                case CDefines.UI_LISTVIEW_RESOURCES:
                    xRes = (CResource)xData;
                    yRes = (CResource)yData;
                    if (m_nColumn == 0) return nOrder * xRes.m_szName.CompareTo(yRes.m_szName);
                    if (m_nColumn == 1) return nOrder * xRes.m_szDescription.CompareTo(yRes.m_szDescription);
                    break;
                default:
                    break;
            }

            return -1;
        }

        public CBaseData GetData(object x)
        {
            CListViewItem item = (CListViewItem)x;
            CBaseData data = (CBaseData)item.Tag;
            return data;
        }
    }
}
