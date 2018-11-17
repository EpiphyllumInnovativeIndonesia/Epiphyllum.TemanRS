using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epiphyllum.TemanRS.Core.Infrastructures;
using Epiphyllum.TemanRS.Core.Infrastructures.DependencyInjection;
using Epiphyllum.TemanRS.Repositories.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
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
            services.AddHttpContextAccessor();
            services.AddDependencyContainer();

            var engine = EngineContext.Create();
            engine.Initialize(services);
            services = engine.ConfigureServices(services, configuration);

            services.ConfigureDbContext(configuration);
            services.ConfigureLocalization();
            services.ConfigureAuthentication(configuration);
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
        /// Configure authentication
        /// </summary>
        /// <param name="services">This services</param>
        internal static void ConfigureAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            var key = Encoding.ASCII.GetBytes(configuration["SecretKey"]);
            services.AddAuthentication(auth =>
            {
                auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(jwt =>
            {
                jwt.RequireHttpsMetadata = false;
                jwt.SaveToken = true;
                jwt.TokenValidationParameters = new TokenValidationParameters {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
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
        public static void AddDependencyContainer(this IServiceCollection services)
        {
            services.AddSingleton<IDependencyManagement, DependencyManagement>();
        }
    }
}
