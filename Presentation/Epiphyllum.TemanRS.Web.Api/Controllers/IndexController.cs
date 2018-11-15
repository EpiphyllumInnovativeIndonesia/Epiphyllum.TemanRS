using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        private readonly IConfiguration _configuration;

        public IndexController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public ActionResult<string> Get()
        {
            var x = _configuration;
            return _configuration.GetConnectionString("Default");
        }
    }
}