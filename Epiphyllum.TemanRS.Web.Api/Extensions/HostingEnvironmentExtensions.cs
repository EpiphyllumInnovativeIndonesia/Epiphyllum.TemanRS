using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace Epiphyllum.TemanRS.Web.Api.Extensions
{
    /// <summary>
    /// Custom hosting environment extensions.
    /// </summary>
    public static class HostingEnvironmentExtensions
    {
        /// <summary>
        /// Build custom configuration.
        /// </summary>
        /// <param name="env">IHostingEnvironment.</param>
        /// <returns>IConfiguration.</returns>
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
                    .AddJsonFile($"{commonPath}/ConnectionStrings.json", optional: false, reloadOnChange: false);
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
