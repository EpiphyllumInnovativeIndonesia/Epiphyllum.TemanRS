using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Epiphyllum.TemanRS.Web.Api.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Epiphyllum.TemanRS.Web.Api
{
    /// <summary>
    /// Represents startup class of application
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Get Configuration of the application
        /// </summary>
        public IConfiguration Configuration { get; }

        public Startup(IHostingEnvironment env)
        {
            Configuration = env.BuildConfiguration();
        }

        /// <summary>
        /// Add services to the application and configure service provider
        /// </summary>
        /// <param name="services">Collection of service descriptors</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureApplicationServices(Configuration);
        }

        /// <summary>
        /// Configure the application HTTP request pipeline
        /// </summary>
        /// <param name="app">Builder for configuring an application's request pipeline</param>
        public void Configure(IApplicationBuilder app)
        {
            app.ConfigureApplicationBuilder();
        }
    }
}
