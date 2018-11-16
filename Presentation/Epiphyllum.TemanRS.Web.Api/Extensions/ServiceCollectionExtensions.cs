using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Epiphyllum.TemanRS.Common.Helpers;
using Epiphyllum.TemanRS.Repositories;
using Epiphyllum.TemanRS.Repositories.Data;
using Epiphyllum.TemanRS.Repositories.Security;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Epiphyllum.TemanRS.Web.Api.Extensions
{
    /// <summary>
    /// Represents extensions of IServiceCollection
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Add services to the application and configure service provider
        /// </summary>
        /// <param name="services">IServiceCollection</param>
        /// <param name="configuration">IConfiguration</param>
        public static void ConfigureApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigureDbContext(configuration);
            services.ConfigureLocalization();
            services.ConfigureDependencyContainer();
            services.ConfigureMvc();
        }

        /// <summary>
        /// Configure mvc services
        /// </summary>
        /// <param name="services">IServiceCollection</param>
        public static void ConfigureMvc(this IServiceCollection services)
        {
            IMvcBuilder mvcBuilder = services.AddMvc();
            mvcBuilder.SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            mvcBuilder.AddJsonOptions(options =>
            {
                options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });
        }

        /// <summary>
        /// Configure database context services
        /// </summary>
        /// <param name="services">IServiceCollection</param>
        public static void ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<EpiphyllumDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("Default"));
            });
        }

        /// <summary>
        /// Configure localization services
        /// </summary>
        /// <param name="services">IServiceCollection</param>
        public static void ConfigureLocalization(this IServiceCollection services)
        {
            services.AddLocalization();
        }

        /// <summary>
        /// Configure inversion of control.
        /// </summary>
        /// <param name="services">IServiceCollection.</param>
        public static void ConfigureDependencyContainer(this IServiceCollection services)
        {
            services.AddSingleton<IPasswordHasher, PasswordHasher>();
            services.AddSingleton<CommonHelpers>();

            services.AddScoped<IDbContext, EpiphyllumDbContext>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        }
    }
}
