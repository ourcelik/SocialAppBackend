using Business.Abstract;
using Business.Hubs;
using Business.Hubs.Abstract;
using Business.Hubs.Sources;
using Core.Aspects.Autofac.Transaction;
using Core.Utilities.IoC;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Entities.DTOs.OutputDtos;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    class UserNotificationManager : IUserNotificationService
    {
        public IHubContext<UserNotificationHub,IUserNotificationHub> _hubContext { get;set; }

        readonly private IUserNotificationDal _userNotificationDal;

        readonly private ICommentNotificationDal _commentNotificationDal;

      

        public UserNotificationManager(IUserNotificationDal userNotificationDal,
            ICommentNotificationDal commentNotificationDal)
        {
            _userNotificationDal = userNotificationDal;
            _commentNotificationDal = commentNotificationDal;
        }
        public UserNotificationManager()
        {

        }

        public async Task SendAsync(string message)
        {
            await _hubContext.Clients.All.receiveMessage(message);
        }

        public Task NotifyNumberOfNotificationToUserAsync(UserNotificationStatistic userNotification)
        {
            ExecuteIfUserExist(userNotification.UserId,async(clientId) =>
            {
                await _hubContext.Clients.Client(clientId).NotifyUserForNumberOfNoViewedNotification(userNotification.NoViewedNotificationCount);
            });

            return Task.CompletedTask;
            
        }

        public Task NotifyContentOfCommentToUserAsync(int userId, CommentContentNotifyDto commentContent)
        {
            
            ExecuteIfUserExist(userId, async (clientId) => {
                await _hubContext.Clients.Client(clientId).NotifyUserForCommentContent(commentContent);            
            });

            return Task.CompletedTask;

        }



        private void ExecuteIfUserExist(int userId,Action<string> operation)
        {
            string clientId;
            if (OnlineUserSource.Users.TryGetValue(userId, out clientId))
            {
                operation?.Invoke(clientId);
            }
        }

        public async Task<int> AddCommentNotification(CommentNotificationDto commentNotificationDto)
        {
            UserNotification notification = CreateNotificationInstance(commentNotificationDto);

            var notificationId = await AddNewNotification(notification);
            CommentNotification commentNotification = CreateCommentNotificationInstance(commentNotificationDto, notificationId);
            var result = await _commentNotificationDal.AddAsync(commentNotification);
            return result.CommentNotificationId;

        }

        private static UserNotification CreateNotificationInstance(CommentNotificationDto commentNotificationDto)
        {
            return new()
            {
                NotifyUserId = commentNotificationDto.NotifyUserId,
            };
        }

        private static CommentNotification CreateCommentNotificationInstance(CommentNotificationDto commentNotificationDto, int notificationId)
        {
            return new()
            {
                ComeFromUserId = commentNotificationDto.ComeFromUserId,
                UserNotificationId = notificationId,
                CommentId = commentNotificationDto.CommentId,
                PostId = commentNotificationDto.PostId
            };
        }

        private async Task<int> AddNewNotification(UserNotification notification)
        {
            var result =  await _userNotificationDal.AddAsync(notification);

            return result.UserNotificationId;
        }

        
    }
}
