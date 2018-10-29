using Epiphyllum.TemanRS.Services.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Epiphyllum.TemanRS.Web.Api.Controllers
{
    [Route("/")]
    [AllowAnonymous]
    public class IndexController : ControllerBase
    {
        private readonly StartupViewModel _startupViewModel;

        public IndexController(IOptionsSnapshot<StartupViewModel> startupViewModel)
        {
            _startupViewModel = startupViewModel.Value;
        }

        [HttpGet]
        public string Get()
        {
            return _startupViewModel.Message;
        }
    }
}