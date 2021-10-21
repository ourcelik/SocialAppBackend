using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.OutputDtos
{
    public class CommentContentNotifyDto
    {
        public string Comment { get; set; }

        public int RelatedPostId { get; set; }

    }
}
