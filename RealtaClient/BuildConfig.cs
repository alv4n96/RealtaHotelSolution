using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelConsole
{
    internal class BuildConfig
    {
        private static IConfigurationRoot? Configuration;
        public static IConfigurationRoot Config()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appSettings.json", optional: true, reloadOnChange: true);

            Configuration = builder.Build();

            return Configuration;
        }
    }
}
