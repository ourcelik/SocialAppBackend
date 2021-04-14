using Core.Entities;

namespace Entities.Concrete
{
    public class RoomMember : IEntity
    {
        public int RoomMemberId { get; set; }
        public int RoomId { get; set; }
        public int UserId { get; set; }
        public int RankId { get; set; }
    }

}