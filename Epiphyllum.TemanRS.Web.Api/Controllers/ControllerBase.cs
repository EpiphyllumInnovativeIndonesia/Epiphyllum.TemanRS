using Microsoft.AspNetCore.Authorization;
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
