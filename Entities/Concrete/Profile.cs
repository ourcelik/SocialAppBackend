using Core.Entities;
using System;

namespace Entities.Concrete
{
    public class Profile : IEntity
    {
        public int ProfileId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Profile_photo_url { get; set; }
        public string Weight { get; set; }
        public string Height { get; set; }
        public byte Relation_status { get; set; }
        public DateTime Birthdate { get; set; }
        public int NotificationId { get; set; }
        public int PreferId { get; set; }
    }

}