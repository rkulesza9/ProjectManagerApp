using Microsoft.Office.Interop.Excel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace ProjectManagementApp
{
    public  class CExporter
    {
        public static void ToExcel(CProject proj, string szProjNotes, string szFile)
        {
            Excel.Application app = null;
            Workbook wkbk = null;
            try
            {
                app = new Excel.Application();
                wkbk = CreateWorkbook(app, szFile);

                Worksheet shtProj = wkbk.ActiveSheet;
                ExportProjectDetails(proj, szProjNotes, ref shtProj);

                wkbk.Save();
            }catch(Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                if (wkbk != null) wkbk.Close();
                if(app != null) app.Quit();
                
            }
        }

        #region "Export to Excel"
        public static Workbook CreateWorkbook(Excel.Application app, string szFile)
        {
            Workbook wb = app.Workbooks.Add();
            if(File.Exists(szFile)) File.Delete(szFile);
            wb.SaveAs(szFile);

            return wb;

        }

        private static void ExportProjectDetails(CProject proj, string szNotes, ref Worksheet shtProj)
        {
            CResource[] lsRes = CJsonDatabase.Instance.GetResourcesFor(proj.m_szGuid);
            shtProj.Name = proj.m_szName;

            string[] headers = new string[] { "Name", "Status", "Last Worked On", "Project Directory", "Wrike URL", "Short Note" };
            string[] data = new string[] { proj.m_szName, proj.szStatus, proj.m_dtLastWorkedOn.ToString(), proj.m_szProjectDir, proj.m_szWrikeUrl, proj.m_szShortNote };
            string[] headers2 = new string[] { "Name", "Description", "Path" };
            string[,] data2 = new string[lsRes.Length, headers2.Length];
            string[] szNoteLines;

            RichTextBox rtb = new RichTextBox();
            rtb.Rtf = szNotes;
            szNotes = rtb.Text;
            szNoteLines = szNotes.Split(new char[] { '\n' });
            rtb.Dispose();

            int x = 0;
            foreach(CResource res in lsRes)
            {
                data2[x, 0] = res.m_szName;
                data2[x, 1] = res.m_szDescription;
                data2[x, 2] = res.m_szPath;

                x++;
            }

            char col = 'A';
            Range rngTitle = shtProj.Range[$"{col}1", $"{col}1"];
            Range rngHeaders = shtProj.Range[$"{col}2", $"{(char)(col + 5)}2"];
            Range rngData = shtProj.Range[$"{col}3", $"{(char)(col + 5)}3"];
            Range rngTitle2 = shtProj.Range[$"{col}5", $"{col}5"];
            Range rngHeaders2 = shtProj.Range[$"{col}6", $"{(char)(col + 2)}6"];
            Range rngTitle3;

            rngTitle.Value2 = "Project Details";
            rngTitle2.Value2 = "Project Resources";
            
            rngHeaders.Value2 = headers;
            rngData.Value2 = data;
            rngHeaders2.Value2 = headers2;

            for(x=7; x < data2.GetLength(0)+7; x++)
            {
                shtProj.Range[$"{col}{x}", $"{(char)(col+2)}{x}"].Value2 = new string[] { data2[x-7, 0], data2[x-7,1], data2[x - 7,2] };
            }

            rngTitle3 = shtProj.Range[$"{col}{x + 1}", $"{col}{x + 1}"];

            for(int x2 = x+1; x2 < szNoteLines.Length+x+1; x2++)
            {
                Range rng = shtProj.Range[$"{col}{x2}", $"{(char)(col + 5)}{x2}"];
                rng.Merge();
                rng.Value = szNoteLines[x2 - (x + 1)];
            }

            rngTitle3.Value = "Project Notes";

            Range[] boldRanges = new Range[] { rngTitle, rngTitle2, rngTitle3, rngHeaders, rngHeaders2 };
            foreach (Range rng in boldRanges) rng.Font.Bold = true;

            shtProj.UsedRange.Columns.AutoFit();
            shtProj.UsedRange.Rows.AutoFit();
        }
        #endregion


    }
}
