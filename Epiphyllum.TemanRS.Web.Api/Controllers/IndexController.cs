using Epiphyllum.TemanRS.Common.Localization.Message;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace Epiphyllum.TemanRS.Web.Api.Controllers
{
    [Route("/")]
    [AllowAnonymous]
    public class IndexController : ControllerBase
    {
        private readonly IStringLocalizer<StartupMessage> _localizer;

        public IndexController(IStringLocalizer<StartupMessage> localizer)
        {
            _localizer = localizer;
        }

        [HttpGet]
        public string Get()
        {
            return _localizer[StartupMessage.Hello];
        }
    }
}