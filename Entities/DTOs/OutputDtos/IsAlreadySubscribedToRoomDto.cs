using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.OutputDtos
{
    public class IsAlreadySubscribedToRoomDto : IDto
    {
        public bool IsSubscribed { get; set; }

    }
}
