using Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class PostInfo : IEntity
    {
        public int PostInfoId { get; set; }

        public int CommentCount { get; set; }

        public int LikeCount { get; set; }

        public int StartedContactCount { get; set; }

    }
}
