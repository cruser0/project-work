using Winform.Forms;

namespace Winform
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            while (true)  // Infinite loop for login/logout cycle
            {
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
                using (MainForm mainForm = new MainForm())
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