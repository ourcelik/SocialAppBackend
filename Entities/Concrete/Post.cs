using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Post : IEntity
    {

        public int PostId { get; set; }

        public DateTime CreatedTime { get; set; }

        public int RelatedRoomId { get; set; }

        public int CreatorId { get; set; }

        public string ContentMessage { get; set; }

        public int RelatedInfoId { get; set; }

        public bool ShowPost { get; set; }

        public bool IsDeleted { get; set; }


    }
}
