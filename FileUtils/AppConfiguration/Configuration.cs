using Microsoft.Extensions.Configuration;

namespace AppConfiguration
{
    public static class Configuration
    {
        public static T GetAppSettings<T>(string basePath, string appSettingsFileName, string key) where T : new()
        {
            var appSettings = new T();
            
            var config = GetAppConfiguration(basePath, appSettingsFileName);
            config.Bind(key, appSettings);

            return appSettings;
        }
        
        private static IConfigurationRoot GetAppConfiguration(string basePath, string appSettingsFileName)
        {
            return new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile(appSettingsFileName)
                .Build();
        }
    }
}
