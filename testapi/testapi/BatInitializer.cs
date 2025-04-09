using System.Diagnostics;

namespace API
{
    public static class BatInitializer
    {
        static string binDirectory = AppDomain.CurrentDomain.BaseDirectory;

        static string projectRoot = Directory.GetParent(binDirectory)!.Parent!.Parent!.Parent!.FullName;

        public static void ExecuteBat()
        {

            string filePath = Path.Combine(projectRoot, "Temp", "hmailserver.bat");
            try
            {
                if (File.Exists(filePath))
                {
                    Process.Start(filePath);
                }
                else
                {
                    throw new FileNotFoundException($"{filePath} was not found");
                }
            }
            catch
            {
                throw;
            }
        }

        public static bool CheckInf()
        {
            string filePath = Path.Combine(projectRoot, "Temp", "hmailserver_config.inf");

            return File.Exists(filePath);
        }
    }
}
