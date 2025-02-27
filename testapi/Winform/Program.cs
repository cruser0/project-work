using Winform.Forms;
using Winform.Services;

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
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            UserService userService = new UserService();
            LoginForm form = new LoginForm();

            if (form.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new MainForm());
                var startTimeSpan = TimeSpan.Zero;
                var periodTimeSpan = TimeSpan.FromMinutes(12);

                var timer = new System.Threading.Timer((e) =>
                {
                    userService.RefreshToken();
                }, null, startTimeSpan, periodTimeSpan);
            }
            else
                Application.Exit();


        }
    }
}