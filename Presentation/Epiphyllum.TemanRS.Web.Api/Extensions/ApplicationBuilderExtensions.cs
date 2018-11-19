﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Epiphyllum.TemanRS.Core.Infrastructures.Middleware;
using Epiphyllum.TemanRS.Core.Localization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;

namespace Epiphyllum.TemanRS.Web.Api.Extensions
{
    /// <summary>
    /// Represents extensions of IApplicationBuilder
    /// </summary>
    public static class ApplicationBuilderExtensions
    {
        /// <summary>
        /// Configure custom application builder
        /// </summary>
        /// <param name="app">IApplicationBuilder</param>
        public static void ConfigureApplicationBuilder(this IApplicationBuilder app)
        {
            app.ConfigureAppLocalization();
            app.UseHsts();
            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseMiddleware<ApiResponseMiddleware>();
            app.UseMvc();
        }

        /// <summary>
        /// Configure custom application localization
        /// </summary>
        /// <param name="app">IApplicationBuilder</param>
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
            //localizationOptions.RequestCultureProviders.Insert(0, new UserLocalizationProvider());
            app.UseRequestLocalization(localizationOptions);
        }
    }
}
