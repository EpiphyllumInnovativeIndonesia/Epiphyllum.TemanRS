using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;

namespace Epiphyllum.TemanRS.Web.Api.Extensions.Localization
{
    public class UserLocalizationProvider : RequestCultureProvider
    {
        public override Task<ProviderCultureResult> DetermineProviderCultureResult(HttpContext httpContext)
        {
            if (httpContext == null)
            {
                throw new ArgumentNullException(nameof(httpContext));
            }

            if (!httpContext.User.Identity.IsAuthenticated)
            {
                return Task.FromResult((ProviderCultureResult)null);
            }

            string userCulture = null;
            string userUICulture = null;

            string cultureClaim = "id-ID";
            if (!string.IsNullOrWhiteSpace(cultureClaim))
            {
                userCulture = cultureClaim;
            }

            string uicultureClaim = "id-ID";
            if (!string.IsNullOrWhiteSpace(uicultureClaim))
            {
                userUICulture = uicultureClaim;
            }

            if (userCulture == null && userUICulture == null)
            {
                return Task.FromResult((ProviderCultureResult)null);
            }

            if (userCulture != null && userUICulture == null)
            {
                userUICulture = userCulture;
            }

            if (userCulture == null && userUICulture != null)
            {
                userCulture = userUICulture;
            }

            var requestCulture = new ProviderCultureResult(userCulture, userUICulture);
            return Task.FromResult(requestCulture);
        }
    }
}
