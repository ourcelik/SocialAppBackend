using Core.Entities;

namespace Entities.Concrete
{
    public class UserNotification : IEntity
    {
        public int UserNotificationId { get; set; }

        public int NotifyUserId { get; set; }

        public bool IsViewed { get; set; }
    }
}
