﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Epiphyllum.TemanRS.Core.Infrastructures;
using Epiphyllum.TemanRS.Services.Accounts;
using Epiphyllum.TemanRS.Web.Api.Models.Accounts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Epiphyllum.TemanRS.Web.Api.Controllers.Accounts
{
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IUserManager _userManager;

        public AuthenticationController(IAuthenticationService authenticationService, IUserManager userManager)
        {
            _authenticationService = authenticationService;
            _userManager = userManager;
        }

        [HttpPost("/login")]
        [AllowAnonymous]
        public async Task<object> Login(LoginRequest request)
        {
            return await _authenticationService.Login(request.Username, request.Password);
        }

        [HttpGet("/current")]
        public object Current()
        {
            var current = EngineContext.Current.UserManager;
            return current;
        }
    }
}