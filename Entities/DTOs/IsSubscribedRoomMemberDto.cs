using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class IsSubscribedRoomMemberDto : IDto
    {
        public int UserId { get; set; }

        public int RoomId { get; set; }
    }
}
