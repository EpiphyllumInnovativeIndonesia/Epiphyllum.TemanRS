using Epiphyllum.TemanRS.Common.Configuration;
using Epiphyllum.TemanRS.Models;
using Microsoft.AspNetCore.Hosting;
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
            services.ConfigureAppSettings(configuration);
            services.ConfigureMvc();
            services.ConfigureDbContext();
            services.ConfigureLocalization();
        }

        private static void ConfigureAppSettings(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ConnectionStrings>(configuration.GetSection("ConnectionStrings"));
            services.AddSingleton(provider => provider.GetService<IOptions<ConnectionStrings>>().Value);
        }

        private static void ConfigureMvc(this IServiceCollection services)
        {
            IMvcBuilder mvcBuilder = services.AddMvc();
            mvcBuilder.SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            mvcBuilder.AddJsonOptions(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());
        }

        private static void ConfigureDbContext(this IServiceCollection services)
        {
            IServiceProvider serviceProvider = services.BuildServiceProvider();
            ConnectionStrings connectionStrings = serviceProvider.GetService<ConnectionStrings>();
            services.AddDbContext<TemanRSContext>(options => options.UseSqlServer(connectionStrings.Master));
        }

        private static void ConfigureLocalization(this IServiceCollection services)
        {
            services.AddLocalization();
        }
    }
}
