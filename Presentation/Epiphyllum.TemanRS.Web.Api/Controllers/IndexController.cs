using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Epiphyllum.TemanRS.Core.Localization.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace Epiphyllum.TemanRS.Web.Api.Controllers
{
    [Route("/")]
    [AllowAnonymous]
    public class IndexController : ControllerBase
    {
        private readonly IStringLocalizer<Message> _stringLocalizer;

        public IndexController(IStringLocalizer<Message> stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
        }

        [HttpGet]
        public string Get()
        {
            return _stringLocalizer[Message.Hello];
        }
    }
}