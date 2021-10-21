using Business.Hubs;
using Business.Hubs.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Entities.DTOs.OutputDtos;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserNotificationService
    {
        public IHubContext<UserNotificationHub,IUserNotificationHub> _hubContext { get; set; }

        public Task SendAsync(string message);

        public Task<int> AddCommentNotification(CommentNotificationDto commentNotificationDto);

        public Task NotifyNumberOfNotificationToUserAsync(UserNotificationStatistic userNotification);

        public Task NotifyContentOfCommentToUserAsync(int userId,CommentContentNotifyDto commentNotification);
    }
}
