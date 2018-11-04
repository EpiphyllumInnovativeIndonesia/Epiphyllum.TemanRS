using System;
using Epiphyllum.TemanRS.Common.Configuration;
using Epiphyllum.TemanRS.Models;
using Epiphyllum.TemanRS.Repositories;
using Epiphyllum.TemanRS.Repositories.Master;
using Epiphyllum.TemanRS.Services.Master;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Epiphyllum.TemanRS.Web.Api.Extensions
{
    /// <summary>
    /// Custom service collection extensions.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Configure custom application services.
        /// </summary>
        /// <param name="services">IServiceCollection.</param>
        /// <param name="configuration">IConfiguration.</param>
        public static void ConfigureApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigureAppSettings(configuration);
            services.ConfigureMvc();
            services.ConfigureDbContext();
            services.ConfigureLocalization();
            services.ConfigureIoC();
        }

        /// <summary>
        /// Configure appsettings services.
        /// </summary>
        /// <param name="services">IServiceCollection.</param>
        /// <param name="configuration">IConfiguration.</param>
        public static void ConfigureAppSettings(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ConnectionStrings>(configuration.GetSection("ConnectionStrings"));
            services.AddSingleton(provider => provider.GetService<IOptions<ConnectionStrings>>().Value);
        }

        /// <summary>
        /// Configure mvc services.
        /// </summary>
        /// <param name="services">IServiceCollection.</param>
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
        /// Configure database context services.
        /// </summary>
        /// <param name="services">IServiceCollection.</param>
        public static void ConfigureDbContext(this IServiceCollection services)
        {
            IServiceProvider serviceProvider = services.BuildServiceProvider();
            ConnectionStrings connectionStrings = serviceProvider.GetService<ConnectionStrings>();
            services.AddDbContext<TemanRSContext>(options =>
            {
                options.UseSqlServer(connectionStrings.Master);
            });
        }

        /// <summary>
        /// Configure localization services.
        /// </summary>
        /// <param name="services">IServiceCollection.</param>
        public static void ConfigureLocalization(this IServiceCollection services)
        {
            services.AddLocalization();
        }

        /// <summary>
        /// Configure inversion of control.
        /// </summary>
        /// <param name="services">IServiceCollection.</param>
        public static void ConfigureIoC(this IServiceCollection services)
        {
            // Add DbContext
            services.AddScoped<IDbContext, TemanRSContext>();

            // Add Repository
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();

            // Add Service
            services.AddScoped<IDepartmentService, DepartmentService>();
        }
    }
}
