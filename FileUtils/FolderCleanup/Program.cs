﻿using System;
using System.Collections.ObjectModel;
using System.IO;
using AppConfiguration;
using Microsoft.Extensions.Configuration;

namespace FolderCleanup
{
    internal static class Program
    {
        private static void Main()
        {
            Console.WriteLine("Starting FileCleanup...");

            var appSettings = Configuration.GetAppSettings<AppSettings>(Directory.GetCurrentDirectory(), "AppConfiguration");
            var errors = new Collection<string>();

            foreach (var cleanupDir in appSettings.CleanupDirs)
            {
                Console.WriteLine($"Cleaning dir: {cleanupDir.Dir}");
                FileUtils.DeleteFiles(cleanupDir.Dir, cleanupDir.DeleteFilesOlderThanDays, errors);
            }
            
            if (errors.Count == 0)
            {
                Environment.Exit(0);
            }

            foreach (var error in errors)
            {
                Console.WriteLine("FileCleanup completed with errors:");
                Console.WriteLine(error);
            }

            Console.ReadLine();
            Environment.Exit(-1);
        }
    }
}
