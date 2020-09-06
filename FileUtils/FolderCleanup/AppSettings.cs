using System.Collections.Generic;

namespace FolderCleanup
{
    public class AppSettings
    {
        public string LogFile { get; set; }
        public IEnumerable<CleanupDir> CleanupDirs { get; set; }
    }

    public class CleanupDir
    {
        public int DeleteFilesOlderThanDays { get; set; }
        public string Dir { get; set; }
    }
}
