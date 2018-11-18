using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Epiphyllum.TemanRS.Core.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Epiphyllum.TemanRS.Web.Api.Controllers
{
    [Route("/")]
    [AllowAnonymous]
    public class IndexController : ControllerBase
    {
        private readonly EpiphyllumConfig _configuration;

        public IndexController(EpiphyllumConfig configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public ActionResult<object> Get()
        {
            EpiphyllumConfig config = null;
            return config;
        }
    }
}