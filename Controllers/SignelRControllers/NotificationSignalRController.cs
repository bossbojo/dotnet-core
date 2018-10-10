using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AppApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.SignalR;
using AppApi.Hubs;
using AppApi.Models.ModelSignelR;
using Microsoft.AspNetCore.Authorization;

namespace AppApi.Controllers.SignelRControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationSignalRController : ControllerBase
    {
        private NotificationHub hub;

        public NotificationSignalRController(IHubContext<NotificationHub> Hub)
        {
            hub = new NotificationHub(Hub);
        }
        [HttpPost("send")]
        public async Task<IActionResult> Post_SendNotification([FromBody] ModelReceiveNotification request)
        {
            try
            {
                bool res = await this.hub.OnSendNotificationAsync(request.user_id.Trim(), request.channel, request.jsonString);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}