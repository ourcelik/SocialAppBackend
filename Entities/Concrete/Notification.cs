using Core.Entities;

namespace Entities.Concrete
{
    public class Notification : IEntity
    {
        public int NotificationId { get; set; }
        public bool Message { get; set; }
        public bool Messagelike { get; set; }
        public bool NewMatch { get; set; }
        public bool NewInApp { get; set; }
        public bool Other { get; set; }
        public bool Superlike { get; set; }
    }

}