using Winform.Forms;
using Winform.Forms.FInalForms;

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



            LoginForm form = new LoginForm();

            if (form.ShowDialog() == DialogResult.OK)
                Application.Run(new MainForm());
            else
                Application.Exit();










        }
    }
}