using System;
using System.Linq;
using AppApi.Libraries.Pagination;
using AppApi.Models;
using AppApi.Repositories.Interfaces;
using AppApi.Services.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace NamespaceName
{
    [Authorize]
    [Route("api/[controller]")]
    public class AuthenController : ControllerBase
    {
        private IUserService _userService;
        private readonly IUsers _IUsers;
        public AuthenController(IUserService userService, IUsers IUsers_)
        {
            _IUsers = IUsers_;
            _userService = userService;
        }
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]ModelAuthen userParam)
        {
            var user = _userService.Authenticate(userParam.Username, userParam.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user);
        }
    }
}