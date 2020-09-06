using System;
using System.Collections.Generic;
using System.IO;
using System.Security;
using NLog;

namespace FolderCleanup
{
    public static class FileOperations
    {
        public static void DeleteFiles(string dir, int days, Logger logger)
        {
            var files = Directory.EnumerateFiles(dir, "*.*", SearchOption.AllDirectories);

            foreach (var file in files)
            {
                var fi = new FileInfo(file);

                if (fi.CreationTime >= DateTime.Now.AddDays(-days))
                {
                    continue;
                }

                try
                {
                    fi.Delete();
                }
                catch(IOException)    
                {
                    logger.Error($"File \"{fi.Name}\" can't be deleted: file is in use.");
                }
                catch(SecurityException)
                {
                    logger.Error($"File \"{fi.Name}\" can't be deleted: insufficient permission.");
                }
                catch(UnauthorizedAccessException)
                {
                    logger.Error($"File \"{fi.Name}\" can't be deleted: access denied.");
                }
            }
        }
    }
}
