using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Epiphyllum.TemanRS.Web.Api.Extensions
{
    public static class HostingEnvironmentExtensions
    {
        public static IConfiguration BuildConfiguration(this IHostingEnvironment env)
        {
            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder();

            configurationBuilder = configurationBuilder
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);

            if (env.IsDevelopment())
            {
                string commonPath = Path.Combine(env.ContentRootPath, "..", "Epiphyllum.TemanRS.Common");
                configurationBuilder = configurationBuilder
                    .AddJsonFile($"{commonPath}/ConnectionStrings.json", optional: false, reloadOnChange: true);
            }
            else
            {
                configurationBuilder = configurationBuilder
                    .AddJsonFile($"ConnectionStrings.json", optional: false, reloadOnChange: false);
            }

            configurationBuilder = configurationBuilder.AddEnvironmentVariables();
            return configurationBuilder.Build();
        }
    }
}
