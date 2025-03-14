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
            // Initializes visual styles and default text rendering
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Infinite loop for login/logout cycle
            while (true)
            {
                // Show the Login Form
                using (LoginForm loginForm = new LoginForm())
                {
                    if (loginForm.ShowDialog() != DialogResult.OK)
                    {
                        // If login is not successful, exit the application
                        Application.Exit();
                        return;
                    }
                }

                // If login is successful, start the main form
                using (SaleReportForm mainForm = new SaleReportForm())
                //using (MainForm mainForm = new MainForm())
                {
                    if (mainForm.ShowDialog() == DialogResult.Abort)
                    {
                        // If the user chooses to logout, restart the loop
                        continue;
                    }
                    else
                    {
                        // Otherwise, exit the application
                        Application.Exit();
                        return;
                    }
                }
            }
        }
    }
}
