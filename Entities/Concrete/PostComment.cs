using Core.Entities;

namespace Entities.Concrete
{
    public class PostComment : IEntity
    {
        public int PostCommentId { get; set; }

        public string Comment { get; set; }

        public bool ShowComment { get; set; }

        public int RelatedPostId { get; set; }

        public int CreatorId { get; set; }

    }
}
