using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Epiphyllum.TemanRS.Web.Api.Extensions.Localization
{
    /// <summary>
    /// Default localization provider.
    /// Get culture info from "appsettings.json" in directory.
    /// </summary>
    public class DefaultLocalizationProvider : RequestCultureProvider
    {
        /// <summary>
        /// Determining custom culture result.
        /// </summary>
        /// <param name="httpContext">Inject HttpContext.</param>
        /// <returns>Task<ProviderCultureResult></returns>
        public override Task<ProviderCultureResult> DetermineProviderCultureResult(HttpContext httpContext)
        {
            if (httpContext == null)
            {
                throw new ArgumentNullException(nameof(httpContext));
            }

            var configuration = httpContext.RequestServices.GetRequiredService<IConfiguration>().GetSection("CultureInfo");
            string defaultCulture = configuration["Default"];
            string defaultUICulture = configuration["DefaultUI"];

            if (defaultCulture == null && defaultUICulture == null)
            {
                return Task.FromResult((ProviderCultureResult)null);
            }

            if (defaultCulture != null && defaultUICulture == null)
            {
                defaultUICulture = defaultCulture;
            }

            if (defaultCulture == null && defaultUICulture != null)
            {
                defaultCulture = defaultUICulture;
            }

            var requestCulture = new ProviderCultureResult(defaultCulture, defaultUICulture);
            return Task.FromResult(requestCulture);
        }
    }
}
