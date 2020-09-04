using Microsoft.Extensions.Configuration;

namespace AppConfiguration
{
    public static class Configuration
    {
        public static T GetAppSettings<T>(string basePath, string appSettingsFileName, string key) where T : class, new()
        {
            var configBuilder = GetConfiguration(basePath, appSettingsFileName);
            var appSettings = new T();
            configBuilder.Bind(key, appSettings);

            return appSettings;
        }

        private static IConfigurationRoot GetConfiguration(string basePath, string appSettingsFileName)
        {
            return new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile(appSettingsFileName)
                .Build();
        }
    }
}
