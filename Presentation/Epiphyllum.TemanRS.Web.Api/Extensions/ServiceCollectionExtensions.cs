using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epiphyllum.TemanRS.Core.Configuration;
using Epiphyllum.TemanRS.Core.Infrastructures;
using Epiphyllum.TemanRS.Core.Infrastructures.DependencyInjection;
using Epiphyllum.TemanRS.Repositories.Data;
using Epiphyllum.TemanRS.Services.Accounts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
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
            services.AddStartupConfig<EpiphyllumConfig>(configuration.GetSection(nameof(EpiphyllumConfig)));

            var engine = EngineContext.Create();
            engine.Initialize(services);
            services = engine.ConfigureServices(services, configuration);

            services.ConfigureDbContext();
            services.ConfigureAuthentication();
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
        public static void ConfigureDbContext(this IServiceCollection services)
        {
            var config = EngineContext.Current.Resolve<EpiphyllumConfig>();
            services.AddDbContext<EpiphyllumDbContext>(options =>
            {
                options.UseSqlServer(config.ConnectionStrings.Default);
            });
        }

        /// <summary>
        /// Configure authentication
        /// </summary>
        /// <param name="services">This services</param>
        public static void ConfigureAuthentication(this IServiceCollection services)
        {
            services.AddAuthentication(auth =>
            {
                auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(jwt =>
            {
                var config = EngineContext.Current.Resolve<EpiphyllumConfig>();
                var key = Encoding.ASCII.GetBytes(config.JwtAuthentication.Key);
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
        /// Create, bind and register as service the specified configuration parameters 
        /// </summary>
        /// <typeparam name="TConfig">Configuration parameters</typeparam>
        /// <param name="services">Collection of service descriptors</param>
        /// <param name="configuration">Set of key/value application configuration properties</param>
        /// <param name="reloadOnChange">Whether the configuration should be reloaded if file changes (default is false)</param>
        /// <returns>Instance of configuration parameters</returns>
        public static TConfig AddStartupConfig<TConfig>(this IServiceCollection services, IConfiguration configuration, bool reloadOnChange = false) where TConfig : class, new()
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            if (configuration == null)
                throw new ArgumentNullException(nameof(configuration));

            //create instance of config
            var config = new TConfig();

            if (reloadOnChange)
            {
                //configure it to the appropriate section of configuration
                services.Configure<TConfig>(configuration);

                //and register it as a scoped options snapshot service
                services.AddScoped(option => option.GetService<IOptionsSnapshot<TConfig>>().Value);
            }
            else
            {
                //bind it to the appropriate section of configuration
                configuration.Bind(config);

                //and register it as a singleton service
                services.AddSingleton(config);
            }

            return config;
        }
    }
}
