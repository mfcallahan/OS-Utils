using System.Collections.Generic;

namespace FolderCleanup
{
    public class AppConfigs
    {
        public IEnumerable<CleanupDirs> CleanupDirs { get; set; }
    }

    public class CleanupDirs
    {
        public int DeleteFilesOlderThanDays { get; set; }
        public string Dir { get; set; }
    }
}
