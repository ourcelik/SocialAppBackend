using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class UserProfile
    {
        public int ProfileId { get; set; }
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Mail { get; set; }
        public string TelNo { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int ProfilePhotoId { get; set; }
        public string Weight { get; set; }
        public string Height { get; set; }
        public bool RelationStatus { get; set; }
        public DateTime Birthdate { get; set; }
    }
}
