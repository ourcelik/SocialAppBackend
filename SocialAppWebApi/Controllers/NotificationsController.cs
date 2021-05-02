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
    public class NotificationsController : ControllerBase
    {
        INotificationService _notificationService;

        public NotificationsController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpGet("getbyid/{id}")]
        async public Task<IActionResult> GetById(int id)
        {
            var data = await _notificationService.GetNotificationSettingById(id);
            return data.Success ? Ok(data) : BadRequest(data);
        }
    }
}
