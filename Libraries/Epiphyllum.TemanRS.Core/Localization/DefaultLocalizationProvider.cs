using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Epiphyllum.TemanRS.Core.Configuration;
using Epiphyllum.TemanRS.Core.Infrastructures;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;

namespace Epiphyllum.TemanRS.Core.Localization
{
    /// <summary>
    /// Represents a default localization provider
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

            var configuration = EngineContext.Current.Resolve<CultureInfo>();
            string defaultCulture = configuration.Default;
            string defaultUICulture = configuration.DefaultUI;

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
