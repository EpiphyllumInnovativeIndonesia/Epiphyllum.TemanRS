using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Epiphyllum.TemanRS.Web.Api.Controllers
{
    /// <summary>
    /// Controller base inherit from Microsoft.AspNetCore.Mvc.ControllerBase.
    /// Applying ApiController and Authorize annotation.
    /// Has default route "/api/[controller]".
    /// </summary>
    [Route("/api/[controller]")]
    [ApiController]
    [Authorize]
    public class ControllerBase : Microsoft.AspNetCore.Mvc.ControllerBase
    {
    }
}