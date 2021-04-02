using Core.Entities;

namespace Entities.Concrete
{
    public class CR_Member : IEntity
    {
        public int CRId { get; set; }
        public int C_RoomId { get; set; }
        public int UserId { get; set; }
        public int RankId { get; set; }
    }

}