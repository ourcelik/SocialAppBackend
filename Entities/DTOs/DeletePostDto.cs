using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class DeletePostDto:IDto
    {
        public int PostId { get; set; }

        public int UserId { get; set; }

    }
}
