using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfNotificationDal : EfEntityRepositoryBase<Notification, SocialNetworkContext>,INotificationDal
    {
        public Notification GetNotificationsByUserId(int id)
        {
            using SocialNetworkContext context = new();
            var data = from u in context.Users
                       join p in context.Profiles
                       on u.ProfileId equals p.ProfileId
                       join n in context.Notifications
                       on p.NotificationId equals n.NotificationId
                       where u.UserId == id
                       select new Notification
                       {
                           Message = n.Message,
                           Messagelike = n.Messagelike,
                           NewInApp = n.NewInApp,
                           NewMatch = n.NewMatch,
                           NotificationId = n.NotificationId,
                           Other = n.Other,
                           Superlike = n.Superlike
                       };
            return data.SingleOrDefault();

        }
    }
}
