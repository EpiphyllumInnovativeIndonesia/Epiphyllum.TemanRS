using Epiphyllum.TemanRS.Common.Configuration;
using Epiphyllum.TemanRS.Models;
using Epiphyllum.TemanRS.Services.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Epiphyllum.TemanRS.Web.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void ConfigureApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigureMvc();
            services.ConfigureAppSettings(configuration);
            services.ConfigureDbContext(configuration);
        }

        private static void ConfigureMvc(this IServiceCollection services)
        {
            IMvcBuilder mvcBuilder = services.AddMvc();
            mvcBuilder.SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            mvcBuilder.AddJsonOptions(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());
        }

        private static void ConfigureAppSettings(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<StartupViewModel>(configuration.GetSection("Startup"));
            services.Configure<ConnectionStrings>(configuration.GetSection("ConnectionStrings"));
        }

        private static void ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TemanRSContext>(options => options.UseSqlServer(configuration.GetConnectionString("Master")));
        }
    }
}
