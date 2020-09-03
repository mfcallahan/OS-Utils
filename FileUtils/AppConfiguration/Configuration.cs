using Microsoft.Extensions.Configuration;

namespace AppConfiguration
{
    public static class Configuration
    {
        public static IConfigurationRoot GetAppConfig(string basePath)
        {
            return new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json")
                .Build();
        }
    }
}