using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectManagementApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (ApplicationIsAlreadyOpen())
            {
                MessageBox.Show("Application Is Already Open Somewhere");
                return;
            } else
            {
                CreateMutex();
                Application.ApplicationExit += Application_ApplicationExit;
            }
            

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new fmProjectManager());
        }

        private static void Application_ApplicationExit(object sender, EventArgs e)
        {
            CloseMutex();
        }

        static bool ApplicationIsAlreadyOpen()
        {
            bool bAlreadyOpen = false;
            try
            {
                Mutex mutex = null;
                bAlreadyOpen = Mutex.TryOpenExisting(m_szMutex, out mutex);
                return mutex != null;
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex);
            }
            return bAlreadyOpen;
        }
        static void CreateMutex()
        {
            try
            {
                m_pMutex = new Mutex(true, m_szMutex);
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
        static void CloseMutex()
        {
            try
            {
                m_pMutex.ReleaseMutex();
            }catch(Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        public static Mutex m_pMutex;
        public const string m_szMutex = "ProjectManagerApp";
        //public const string m_szMutex = "ProjectManagerApp-Dev";
    }
}
