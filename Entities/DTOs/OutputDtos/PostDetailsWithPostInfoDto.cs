using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.OutputDtos
{
    public class PostDetailsWithPostInfoDto : IDto
    {
        public int PostId { get; set; }

        public DateTime CreatedTime { get; set; }

        public int CreatorId { get; set; }

        public int RelatedRoomId { get; set; }

        public string ContentMessage { get; set; }

        public int RelatedInfoId { get; set; }

        public int CommentCount { get; set; }

        public int LikeCount { get; set; }

        public int StartedContactCount { get; set; }

    }
}
