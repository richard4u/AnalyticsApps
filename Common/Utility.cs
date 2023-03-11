using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WemaAnalyticsAPI.Common
{
    public static class Utility
    {
        [DebuggerStepThrough]
        public static IConfigurationRoot AppConfiguration()
        {
            var configurationBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configurationBuilder.AddJsonFile(path, false);

            return configurationBuilder.Build();
        }
    }
}
