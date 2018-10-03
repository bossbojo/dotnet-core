using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using dotnetcore_micro.Models;
namespace AppApi.Controllers
{
    /// <summary>
    /// SimpleController RESTFul API 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class SimpleController : ControllerBase
    {
        /// <summary>
        /// Get Method Api Example
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetMethod()
        {
            return Ok("Success Get Method");
        }

        /// <summary>
        /// Get Method By {id} Api Example
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetMethodById(int id)
        {
            return Ok($"Success Get by id = {id} Method");
        }

        /// <summary>
        /// Post Method Api Example 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult PostMethod([FromBody] ModelSimple request)
        {
            return Ok(request);
        }

        /// <summary>
        /// Put Method by {id} Api Example 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        [HttpPut("{id}")]
        public IActionResult PutMethod(int id, [FromBody] ModelSimple request)
        {
            return Ok(request);
        }

        /// <summary>
        /// Delete Method by {id} Api Example 
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public IActionResult DeleteMethod(int id)
        {
            return Ok($"Success Delete by id = {id} Method");
        }
    }
}
