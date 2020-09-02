using System;
using System.Collections.ObjectModel;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace FolderCleanup
{
    internal static class Program
    {
        private static void Main()
        {
            var appConfigs = GetAppConfigs();
            var errors = new Collection<string>();

            // call DeleteFiles() for each dir
            foreach (var cleanupDir in appConfigs.CleanupDirs)
            {
                FileUtils.DeleteFiles(cleanupDir.Dir, cleanupDir.DeleteFilesOlderThanDays, errors);
            }

            // handle errors..
            if (errors.Count == 0)
            {
                Environment.Exit(0);
            }

            foreach (var error in errors)
            {
                Console.WriteLine(error);
            }

            Console.ReadLine();
            Environment.Exit(-1);
        }

        private static AppSettings GetAppConfigs()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var appSettings = new AppSettings();
            
            builder.Bind("AppSettings", appSettings);

            return appSettings;
        }
    }
}
