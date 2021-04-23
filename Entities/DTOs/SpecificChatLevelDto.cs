using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class SpecificChatLevelDto :IDto
    {
        public string Level { get; set; }
        public int MatchUser { get; set; }
        public int MatchedUser { get; set; }
    }
}
