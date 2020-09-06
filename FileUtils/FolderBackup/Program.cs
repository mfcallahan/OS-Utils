using System.IO;
using AppConfiguration;

namespace FolderBackup
{
    internal static class Program
    {
        private static void Main()
        {
            var appSettings = Configuration.GetAppSettings<AppSettings>(
                    Directory.GetCurrentDirectory(),
                    "appsettings.json",
                    "Configs"
                );
        }
    }
}
