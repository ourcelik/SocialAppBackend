using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialAppWebApi.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class NotificationsControllercs : ControllerBase
    {
        INotificationService _notificationService;

        public NotificationsControllercs(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpGet("getbyid")]
        async public Task<IActionResult> GetById(int id)
        {
            var data = await _notificationService.GetNotificationSettingById(id);
            if (data.Success)
            {
                return Ok(data);
            }
            return BadRequest(data);
        }
    }
}
