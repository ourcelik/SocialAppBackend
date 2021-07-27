using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class UserUpdateProfileDto
    {
        public int ProfileId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Weight { get; set; }
        public byte GenderId { get; set; }
        public string Height { get; set; }
        public bool RelationshipStatus { get; set; }
        public DateTime Birthdate { get; set; }

    }
}
