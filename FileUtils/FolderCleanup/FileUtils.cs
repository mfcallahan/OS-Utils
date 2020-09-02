using System;
using System.Collections.Generic;
using System.IO;
using System.Security;

namespace FolderCleanup
{
    public static class FileUtils
    {
        public static void DeleteFiles(string dir, int days, ICollection<string> errors)
        {
            var files = Directory.EnumerateFiles(dir, "*.*", SearchOption.AllDirectories);

            foreach (var file in files)
            {
                var fi = new FileInfo(file);

                if (fi.CreationTime <= DateTime.Now.AddDays(days))
                {
                    continue;
                }

                try
                {
                    fi.Delete();
                    Console.WriteLine($"{fi.Name} deleted.");
                }
                catch(IOException)    
                {
                    errors.Add($"File {fi.Name} can't be deleted: file is in use.");
                }
                catch(SecurityException)
                {
                    errors.Add($"File {fi.Name} can't be deleted: insufficient permission.");
                }
                catch(UnauthorizedAccessException)
                {
                    errors.Add($"File {fi.Name} can't be deleted: access denied.");
                }
            }
        }
    }
}