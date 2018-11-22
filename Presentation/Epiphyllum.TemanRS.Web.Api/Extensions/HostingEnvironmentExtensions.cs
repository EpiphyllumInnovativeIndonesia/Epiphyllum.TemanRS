using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace Epiphyllum.TemanRS.Web.Api.Extensions
{
    /// <summary>
    /// Represents extensions of IHostingEnvironment
    /// </summary>
    public static partial class HostingEnvironmentExtensions
    {
        /// <summary>
        /// Build custom configuration
        /// </summary>
        /// <param name="env">IHostingEnvironment</param>
        /// <returns>Configuration</returns>
        public static IConfiguration BuildConfiguration(this IHostingEnvironment env)
        {
            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder();

            configurationBuilder = configurationBuilder
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);

            configurationBuilder = configurationBuilder.AddEnvironmentVariables();

            return configurationBuilder.Build();
        }
    }
}
