using System.Collections.Generic;
using System.Globalization;
using Epiphyllum.TemanRS.Web.Api.Extensions.Localization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;

namespace Epiphyllum.TemanRS.Web.Api.Extensions
{
    /// <summary>
    /// Custom application builder extensions.
    /// </summary>
    public static class ApplicationBuilderExtensions
    {
        /// <summary>
        /// Configure custom application builder.
        /// </summary>
        /// <param name="app">IApplicationBuilder.</param>
        /// <param name="env">IHostingEnvironment.</param>
        public static void ConfigureApplicationBuilder(this IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.ConfigureAppLocalization();
            app.UseHttpsRedirection();
            app.UseMvc();
        }

        /// <summary>
        /// Configure custom application localization.
        /// </summary>
        /// <param name="app">IApplicationBuilder.</param>
        public static void ConfigureAppLocalization(this IApplicationBuilder app)
        {
            IList<CultureInfo> supportedCultures = new List<CultureInfo>
            {
                new CultureInfo("en-US"),
                new CultureInfo("id-ID"),
            };

            RequestLocalizationOptions localizationOptions = new RequestLocalizationOptions {
                DefaultRequestCulture = new RequestCulture("en-US"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            };

            localizationOptions.RequestCultureProviders.Insert(0, new DefaultLocalizationProvider());
            localizationOptions.RequestCultureProviders.Insert(0, new UserLocalizationProvider());
            app.UseRequestLocalization(localizationOptions);
        }

    }
}
