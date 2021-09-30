using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class UpdatePostDto : IDto
    {
        public int PostId { get; set; }

        public string ContentMessage { get; set; }

        public bool ShowPost { get; set; }

    }
}
