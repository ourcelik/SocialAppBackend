using Core.Entities;

namespace Entities.Concrete
{
    public class Liked : IEntity
    {
        public int LikedId { get; set; }
        public int ReceiverId { get; set; }
        public int SenderId { get; set; }
        public int KindId { get; set; }

    }

}