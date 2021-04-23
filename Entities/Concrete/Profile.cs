using Core.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class Profile : IEntity
    {
        public int ProfileId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Weight { get; set; }
        public string Height { get; set; }
        public bool RelationshipStatus { get; set; }
        public int ProfilePhotoId { get; set; }
        public DateTime Birthdate { get; set; }
        public int NotificationId { get; set; }
        public int PreferId { get; set; }
        public byte GenderId { get; set; }
    }

}