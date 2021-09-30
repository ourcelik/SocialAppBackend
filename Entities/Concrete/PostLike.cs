using Core.Entities;

namespace Entities.Concrete
{
    public class PostLike : IEntity
    {
        public int PostLikeId { get; set; }

        public int LikeUserId { get; set; }

        public int RelatedPostId { get; set; }
    }
}
