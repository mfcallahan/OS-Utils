using System.IO;
using AppConfiguration;
using Microsoft.Extensions.Configuration;

namespace FolderBackup
{
    internal static class Program
    {
        private static void Main()
        {
            var appSettings = Configuration.GetAppSettings<AppSettings>(Directory.GetCurrentDirectory(), "AppConfiguration");
        }
    }
}
