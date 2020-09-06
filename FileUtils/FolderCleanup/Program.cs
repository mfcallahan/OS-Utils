using System;
using System.IO;
using NLog;
using AppConfiguration;
using NLog.Targets;

namespace FolderCleanup
{
    internal static class Program
    {
        private static Logger Logger;

        private static void Main()
        {
            Console.WriteLine("Starting FileCleanup...");
            
            var appSettings = Configuration.GetAppSettings<AppSettings>(
                    Directory.GetCurrentDirectory(),
                    "appsettings.json",
                    "AppConfigs"
                );
            
            Setup(appSettings);
            
            foreach (var cleanupDir in appSettings.CleanupDirs)
            {
                Console.WriteLine($"Cleaning dir: {cleanupDir.Dir}");
                FileOperations.DeleteFiles(cleanupDir.Dir, cleanupDir.DeleteFilesOlderThanDays, Logger);
            }
            Logger.Info("FileCleanup complete.");
            Environment.Exit(0);
        }

        private static void Setup(AppSettings appConfigs)
        {
            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
            {
                appConfigs.LogFile = Path.Combine(Directory.GetCurrentDirectory(), appConfigs.LogFile);
            }

            File.Delete(appConfigs.LogFile);

            Logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
            
            LogManager.ReconfigExistingLoggers(); 
            var target = (FileTarget)LogManager.Configuration.FindTargetByName("FileLog");
            target.FileName = "new_path_to_filename";
            
            LogManager.ReconfigExistingLoggers(); 
        }
    }
}
