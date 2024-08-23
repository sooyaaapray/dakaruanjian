using ClockIn.Server.IConfiguration;
using Microsoft.Extensions.Configuration;

namespace ClockIn.Server.Configuration
{
    public class Configuration : IConfiguration.IConfiguration
    {
        private static IConfigurationRoot _iConfigurationRoot;

        static Configuration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
            _iConfigurationRoot = builder.Build();
        }
        public string Read(string key)
        {
            return _iConfigurationRoot[key];
        }
    }
}
