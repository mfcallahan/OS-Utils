using Microsoft.Extensions.Configuration;

namespace AppConfiguration
{
    public static class Configuration
    {
        public static T GetAppSettings<T>(string basePath, string appSettingsSection) where T : new()
        {
            var appSettings = new T();
            
            var config = GetAppConfiguration(basePath);
            config.Bind(appSettingsSection, appSettings);

            return appSettings;
        }
        
        private static IConfigurationRoot GetAppConfiguration(string basePath)
        {
            return new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json")
                .Build();
        }
    }
}
