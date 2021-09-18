using Business.Abstract;
using Entities.Concrete;
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
        [HttpGet("GetByUserId/{id}")]
         public IActionResult GetByUserId(int id)
        {
            var data = _notificationService.GetNotificationsByUserId(id);
            return data.Success ? Ok(data) : BadRequest(data);
        }
        [HttpPost("UpdateNotification")]
        async public Task<IActionResult> UpdateNotificationById(Notification notification)
        {
            var data = await _notificationService.UpdateNotificationSettingsAsync(notification);
            return data.Success ? Ok(data) : BadRequest(data);
        }
    }
}
