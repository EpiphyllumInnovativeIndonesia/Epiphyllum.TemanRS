using Epiphyllum.TemanRS.Web.Api.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Epiphyllum.TemanRS.Web.Api
{
    public class Startup
    {
        /// <summary>
        /// Configuration property.
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Startup constructor.
        /// </summary>
        /// <param name="env">Inject IHostingEnvironment.</param>
        public Startup(IHostingEnvironment env)
        {
            Configuration = env.BuildConfiguration();
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services">Inject IServiceCollection.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureApplicationServices(Configuration);
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app">Inject IApplicationBuilder.</param>
        /// <param name="env">Inject IHostingEnvironment.</param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.ConfigureApplicationBuilder(env);
        }
    }
}
