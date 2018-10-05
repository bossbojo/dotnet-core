using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using dotnetcore_micro.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
namespace AppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SimpleController : ControllerBase
    {
        /// <summary>
        /// Get Method Api Example
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetMethodAsync()
        {
            try
            {
                using (var context = new ConnectDB())
                {
                    var model = context.SimpleTable.ToList();
                    return Ok(model);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Get Method By {id} Api Example
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetMethodById(int id)
        {
            try
            {
                using (var context = new ConnectDB())
                {
                    var model = context.SimpleTable.FirstOrDefault(c => c.Id == id);
                    return Ok(model);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Post Method Api Example 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> PostMethodAsync([FromBody] ModelSimple request)
        {
            try
            {
                using (var context = new ConnectDB())
                {
                    var add = context.SimpleTable.Add(new AppApi.Models.Table.SimpleTable
                    {
                        Firstname = request.firstname,
                        Lastname = request.lastname
                    });
                    int save = await context.SaveChangesAsync();
                    if (save > 0)
                    {
                        return Ok(add.Entity);
                    }
                    throw new Exception("save to database failed");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Put Method by {id} Api Example 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMethodAsync(int id, [FromBody] ModelSimple request)
        {
            try
            {
                using (var context = new ConnectDB())
                {
                    var update = context.SimpleTable.FirstOrDefault(c => c.Id == id);
                    update.Firstname = request.firstname;
                    update.Lastname = request.lastname;
                    int save = await context.SaveChangesAsync();
                    if (save > 0)
                    {
                        return Ok(update);
                    }
                    throw new Exception("save to database failed");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Delete Method by {id} Api Example 
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMethodAsync(int id)
        {
            try
            {
                using (var context = new ConnectDB())
                {
                    var delete = context.SimpleTable.FirstOrDefault(c => c.Id == id);
                    context.SimpleTable.Remove(delete);
                    int save = await context.SaveChangesAsync();
                    if (save > 0)
                    {
                        return Ok($"Success delete id {id} SimpleTable");
                    }
                    throw new Exception("save to database failed");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
