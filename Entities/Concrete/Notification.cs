using Core.Entities;

namespace Entities.Concrete
{
    public class Notification : IEntity
    {
        public int NotificationId { get; set; }
        public byte Message { get; set; }
        public byte Message_like { get; set; }
        public byte New_match { get; set; }
        public byte New_in_app { get; set; }
        public byte Other { get; set; }
        public byte Superlike { get; set; }
    }

}