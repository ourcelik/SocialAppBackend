using Entities.DTOs.OutputDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Hubs.Abstract
{
    public interface IUserNotificationHub
    {
        Task receiveMessage(string message);

        Task NotifyUserForNumberOfNoViewedNotification(int countOfNotification);

        Task NotifyUserForCommentContent(CommentContentNotifyDto contentNotifyDto);
    }
}
