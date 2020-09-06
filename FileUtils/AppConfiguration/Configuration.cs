using Microsoft.Extensions.Configuration;

namespace AppConfiguration
{
    public static class Configuration
    {
        public static T GetAppSettings<T>(string basePath, string appSettingsFile, string key) where T : class, new()
        {
            var configBuilder = GetConfiguration(basePath, appSettingsFile);
           
            var appSettings = new T();
            configBuilder.GetSection(key).Bind(appSettings);

            return appSettings;
        }

        private static IConfigurationRoot GetConfiguration(string basePath, string appSettingsFile)
        {
            return new ConfigurationBuilder().SetBasePath(basePath).AddJsonFile(appSettingsFile).Build();
        }
    }
}
