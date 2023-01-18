using Microsoft.Office.Interop.Excel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
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

        public static void ToZip(CProject proj, string szFile, Action<string> UpdateStatus)
        {
            try
            {
                // 1. create a working temp directory
                UpdateStatus("Setting up temp directory...");
                string szTempDir = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString().Substring(0, 6));
                string szTempProjDir = Path.Combine(szTempDir, "Project Directory");
                Directory.CreateDirectory(szTempDir);
                Directory.CreateDirectory(szTempProjDir);
                UpdateStatus("Setting up temp directory... Completed.");


                // 2. copy project dir to working temp directory
                UpdateStatus("Copying Project Directory...");
                string szProjectDir = proj.m_szProjectDir;
                Copy(szProjectDir, szTempProjDir);
                UpdateStatus("Copying Project Directory... Completed.");

                // 3. create "notebook" folder and save each notebook page as rtf file
                UpdateStatus("Copying Notebook...");
                string szTempNotebook = Path.Combine(szTempDir, "Notebook");
                Directory.CreateDirectory(szTempNotebook);
                string szTempNtbkPg = "";
                string szTempWordPg = "";
                CNotebookPage[] lsPages = CJsonDatabase.Instance.GetNotebookPagesFor(proj.m_szGuid);
                foreach (CNotebookPage pg in lsPages)
                {
                    szTempNtbkPg = Path.Combine(szTempNotebook, ToSafeFileNm($"{pg.m_szName}.rtf"));
                    File.WriteAllText(szTempNtbkPg, pg.m_szText);

                    szTempWordPg = Path.Combine(szTempNotebook, ToSafeFileNm($"{pg.m_szName}.docx"));
                    SaveAsDocx(szTempNtbkPg, szTempWordPg);
                    File.Delete(szTempNtbkPg);
                }
                UpdateStatus("Copying Notebook... Completed");

                // 4. create "local resources" folder and copy local resources to it (ONLY directories and files; entire directories)
                UpdateStatus("Copying local resources...");
                string szTempLocalRes = Path.Combine(szTempDir, "Resources");
                Directory.CreateDirectory(szTempLocalRes);
                string szResourcePath = "";
                string szTempResPath = "";
                string szExt = "";
                CResource[] lsResources = CJsonDatabase.Instance.GetResourcesFor(proj.m_szGuid);
                foreach (CResource res in lsResources)
                {
                    szResourcePath = res.m_szPath;

                    if (File.Exists(szResourcePath))
                    {
                        szExt = GetExtension(szResourcePath);
                        szTempResPath = Path.Combine(szTempLocalRes, ToSafeFileNm($"{res.m_szName}.{szExt}"));
                        File.Copy(szResourcePath, szTempResPath);
                    }
                    else if (Directory.Exists(szResourcePath))
                    {
                        szTempResPath = Path.Combine(szTempLocalRes, ToSafeFileNm(res.m_szName));
                        Directory.CreateDirectory(szTempResPath);
                        Copy(szResourcePath, szTempResPath);
                    }

                }
                UpdateStatus("Copying local resources... Completed.");

                // 5. create xlsx export and include it
                UpdateStatus("Copying Project Details Into Excel File...");
                string szExcelPath = Path.Combine(szTempDir, "Project Description.xlsx");
                ToExcel(proj, "", szExcelPath);
                UpdateStatus("Copying Project Details Into Excel File... Completed.");

                // 6. zip the working dir and save it as whatever the employee wants
                UpdateStatus("Zipping temp directory...");
                ZipFile.CreateFromDirectory(szTempDir, szFile);
                UpdateStatus("Done.");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        public static void ToZip(CProject[] lsProjs, string szFile, Action<string> UpdateStatus)
        {
            try
            {
                // 1. create a working temp directory
                UpdateStatus("Setting up temp directory...");
                string szTempDir = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString().Substring(0, 6));
                Directory.CreateDirectory(szTempDir);
                UpdateStatus("Setting up temp directory... Completed.");

                foreach (CProject proj in lsProjs)
                {
                    UpdateStatus($"({proj.m_szName}) Setting up temp directory...");
                    string szTempDirProj = Path.Combine(szTempDir, ToSafeFileNm(proj.m_szName));
                    string szTempProjDir = Path.Combine(szTempDirProj, "Project Directory");

                    Directory.CreateDirectory(szTempDirProj);
                    Directory.CreateDirectory(szTempProjDir);
                    UpdateStatus($"({proj.m_szName}) Setting up temp directory... Completed.");

                    // 2. copy project dir to working temp directory
                    UpdateStatus($"({proj.m_szName}) Copying Project Directory...");
                    string szProjectDir = proj.m_szProjectDir;
                    if(File.Exists(szProjectDir) || Directory.Exists(szProjectDir)) Copy(szProjectDir, szTempProjDir);
                    UpdateStatus($"({proj.m_szName}) Copying Project Directory... Completed.");

                    // 3. create "notebook" folder and save each notebook page as rtf file
                    UpdateStatus($"({proj.m_szName}) Copying Notebook...");
                    string szTempNotebook = Path.Combine(szTempDirProj, "Notebook");
                    Directory.CreateDirectory(szTempNotebook);
                    string szTempNtbkPg = "";
                    string szTempWordPg = "";
                    CNotebookPage[] lsPages = CJsonDatabase.Instance.GetNotebookPagesFor(proj.m_szGuid);
                    foreach (CNotebookPage pg in lsPages)
                    {
                        szTempNtbkPg = Path.Combine(szTempNotebook, ToSafeFileNm($"{pg.m_szName}.rtf"));
                        File.WriteAllText(szTempNtbkPg, pg.m_szText);

                        szTempWordPg = Path.Combine(szTempNotebook, ToSafeFileNm($"{pg.m_szName}.docx"));
                        SaveAsDocx(szTempNtbkPg, szTempWordPg);
                        File.Delete(szTempNtbkPg);
                    }
                    UpdateStatus($"({proj.m_szName}) Copying Notebook... Completed.");

                    // 4. create "local resources" folder and copy local resources to it (ONLY directories and files; entire directories)
                    UpdateStatus($"({proj.m_szName}) Copying local resources...");
                    string szTempLocalRes = Path.Combine(szTempDirProj, "Resources");
                    Directory.CreateDirectory(szTempLocalRes);
                    string szResourcePath = "";
                    string szTempResPath = "";
                    string szExt = "";
                    CResource[] lsResources = CJsonDatabase.Instance.GetResourcesFor(proj.m_szGuid);
                    foreach (CResource res in lsResources)
                    {
                        szResourcePath = res.m_szPath;

                        if (File.Exists(szResourcePath))
                        {
                            szExt = GetExtension(szResourcePath);
                            szTempResPath = Path.Combine(szTempLocalRes, ToSafeFileNm($"{res.m_szName}.{szExt}"));
                            File.Copy(szResourcePath, szTempResPath);
                        }
                        else if (Directory.Exists(szResourcePath))
                        {
                            szTempResPath = Path.Combine(szTempLocalRes, ToSafeFileNm(res.m_szName));
                            Directory.CreateDirectory(szTempResPath);
                            Copy(szResourcePath, szTempResPath);
                        }

                    }
                    UpdateStatus($"({proj.m_szName}) Copying local resources... Completed.");

                    // 5. create xlsx export and include it
                    UpdateStatus($"({proj.m_szName}) Copying Project Details Into Excel File...");
                    string szExcelPath = Path.Combine(szTempDirProj, "Project Description.xlsx");
                    ToExcel(proj, "", szExcelPath);
                    UpdateStatus($"({proj.m_szName}) Copying Project Details Into Excel File... Completed.");
                }

                // 6. zip the working dir and save it as whatever the employee wants
                UpdateStatus("Zipping temp directory...");
                ZipFile.CreateFromDirectory(szTempDir, szFile);
                UpdateStatus("Done.");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
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
            int nSheetNameLen = proj.m_szName.Length < 31 ? proj.m_szName.Length : 31;
            string szSheetName = $"{proj.m_szName.Substring(0, nSheetNameLen)}";
            foreach (string c in new string[] { ":", "\\", "/", "?", "*", "[", "]" }) szSheetName = szSheetName.Replace(c, "");
            shtProj.Name = szSheetName;

            string[] headers = new string[] { "Name", "Type", "Status", "Last Worked On", "Project Directory", "Wrike URL", "Short Note", "Main Developer", "Main Contact" };
            string[] data = new string[] { proj.m_szName, proj.szProjType, proj.szStatus, proj.m_dtLastWorkedOn.ToString(), proj.m_szProjectDir, proj.m_szWrikeUrl, proj.m_szShortNote, proj.m_szMainDeveloper, proj.m_szMainContact };
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
            Range rngHeaders = shtProj.Range[$"{col}2", $"{(char)(col + 8)}2"];
            Range rngData = shtProj.Range[$"{col}3", $"{(char)(col + 8)}3"];
            Range rngTitle2 = shtProj.Range[$"{col}5", $"{col}5"];
            Range rngHeaders2 = shtProj.Range[$"{col}6", $"{(char)(col + 2)}6"];
            Range rngTitle3 = shtProj.Range[$"{col}7", $"{col}7"];
            Range rngTitle4;

            rngTitle.Value2 = "Project Details";
            rngTitle2.Value2 = "Project Resources";
            
            rngHeaders.Value2 = headers;
            rngData.Value2 = data;
            rngHeaders2.Value2 = headers2;

            for(x=7; x < data2.GetLength(0)+7; x++)
            {
                shtProj.Range[$"{col}{x}", $"{(char)(col+2)}{x}"].Value2 = new string[] { data2[x-7, 0], data2[x-7,1], data2[x - 7,2] };
            }

            rngTitle4 = shtProj.Range[$"{col}{x + 1}", $"{col}{x + 1}"];

            for(int x2 = x+1; x2 < szNoteLines.Length+x+1; x2++)
            {
                Range rng = shtProj.Range[$"{col}{x2}", $"{(char)(col + 5)}{x2}"];
                rng.Merge();
                rng.Value = szNoteLines[x2 - (x + 1)];
            }

            rngTitle4.Value = "Project Notes";

            Range[] boldRanges = new Range[] { rngTitle, rngTitle2, rngTitle4, rngHeaders, rngHeaders2 };
            foreach (Range rng in boldRanges) rng.Font.Bold = true;

            shtProj.UsedRange.Columns.AutoFit();
            shtProj.UsedRange.Rows.AutoFit();
        }
        #endregion

        #region "Export To Zip"
        public static void Copy(string sourceDirectory, string targetDirectory)
        {
            DirectoryInfo diSource = new DirectoryInfo(sourceDirectory);
            DirectoryInfo diTarget = new DirectoryInfo(targetDirectory);

            CopyAll(diSource, diTarget);
        }
        public static void CopyAll(DirectoryInfo source, DirectoryInfo target)
        {
            Directory.CreateDirectory(target.FullName);

            // Copy each file into the new directory.
            foreach (FileInfo fi in source.GetFiles())
            {
                try
                {
                    Debug.WriteLine(@"Copying {0}\{1}", target.FullName, fi.Name);
                    fi.CopyTo(Path.Combine(target.FullName, fi.Name), true);
                }
                catch(Exception ex)
                {
                    Debug.WriteLine(ex);
                }
            }

            // Copy each subdirectory using recursion.
            foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
            {
                try
                {
                    DirectoryInfo nextTargetSubDir =
                        target.CreateSubdirectory(diSourceSubDir.Name);
                    CopyAll(diSourceSubDir, nextTargetSubDir);
                }catch(Exception ex)
                {
                    Debug.WriteLine(ex);
                }
            }
        }
        public static string ToSafeFileNm(string text)
        {
            string szFilename = text;
            foreach (char c in System.IO.Path.GetInvalidFileNameChars())
            {
                szFilename = szFilename.Replace(c, '_');
            }
            return szFilename;
        }
        public static string GetExtension(string filename)
        {
            int nLastDotIndex = filename.LastIndexOf(".");
            int nExtLength = filename.Length - nLastDotIndex;
            return filename.Substring(nLastDotIndex, nExtLength);
        }
        public static void SaveAsDocx(string szRtfFile, string szWordFile)
        {
            try
            {
                var wordApp = new Microsoft.Office.Interop.Word.Application();
                var currentDoc = wordApp.Documents.Open(szRtfFile);
                currentDoc.SaveAs(szWordFile, Microsoft.Office.Interop.Word.WdSaveFormat.wdFormatDocumentDefault);
                currentDoc.Close();
                wordApp.Quit();
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
        #endregion
    }
}
