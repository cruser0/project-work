using System;
using System.Windows.Forms;
using WinformDotNetFramework.Forms;

namespace WinformDotNetFramework
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            while (true)
            {
                using (LoginForm loginForm = new LoginForm())
                {
                    if (loginForm.ShowDialog() != DialogResult.OK)
                    {
                        Application.Exit();
                        return;
                    }
                }

                //using (SaleReportForm mainForm = new SaleReportForm())
                //using (Form1 mainForm = new Form1())
                using (MainForm mainForm = new MainForm())
                {
                    if (mainForm.ShowDialog() == DialogResult.Abort)
                    {
                        continue;
                    }
                    else
                    {
                        Application.Exit();
                        return;
                    }
                }
            }
        }
    }
}
