using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class CommentNotificationDto:IDto
    {
        public int NotifyUserId { get; set; }

        public int CommentId { get; set; }

        public int PostId { get; set; }

        public int ComeFromUserId { get; set; }

    }
}
