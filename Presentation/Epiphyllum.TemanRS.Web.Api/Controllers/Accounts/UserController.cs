using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Epiphyllum.TemanRS.Repositories.Entity;
using Epiphyllum.TemanRS.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Epiphyllum.TemanRS.Web.Api.Controllers.Accounts
{
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IEnumerable<User>> Get()
        {
            return await _userService.GetUsers();
        }

        [HttpGet("{id}")]
        public async Task<User> Get(int id)
        {
            return await _userService.GetUser(id);
        }
    }
}