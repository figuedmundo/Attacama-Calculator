using System.IO;
using Microsoft.Extensions.Configuration;

namespace Captiva.Utils.ConfigurationManager
{
    public class Settings
    {
        private static IConfiguration _config;
        private static IConfiguration Config
        {
            get
            {
                if (_config == null)
                {
                    var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json");

                    _config = builder.Build();
                }

                return _config;
            }
        }

        public static string Url => Config["Url"];
        public static string ReportPath => Config["ReportPath"];
        public static string Browser => Config["Browser"];
        public static string Api => Config["Api"];
    }
}
