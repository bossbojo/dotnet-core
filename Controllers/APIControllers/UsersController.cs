using System;
using System.Linq;
using System.Security.Claims;
using WebApi.Libraries.Pagination;
using WebApi.Models;
using WebApi.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace NamespaceName
{

    [Authorize]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUsers _IUsers;
        public UsersController(IUsers IUsers_)
        {
            _IUsers = IUsers_;
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var UserId = this.User.Identity.Name;
                var page = new PaginationAndFilter(HttpContext);
                var response = page.queryPaginationJSON("Users");
                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [AllowAnonymous]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var response = _IUsers.GetUsers(id);
                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Post([FromBody] ModelUsers model)
        {
            try
            {
                var response = _IUsers.CreateUsers(model);
                return Created("Success Created", response);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromBody] ModelUsers model, int id)
        {
            try
            {
                var response = _IUsers.UpdateUsers(model, id);
                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                var response = _IUsers.DeleteUsers(id);
                return Ok($"Success delete id {id} SimpleTable");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}