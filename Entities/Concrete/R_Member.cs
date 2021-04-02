using Core.Entities;

namespace Entities.Concrete
{
    public class R_Member : IEntity
    {
        public int RId { get; set; }
        public int RoomId { get; set; }
        public int UserId { get; set; }
        public int RankId { get; set; }
    }

}