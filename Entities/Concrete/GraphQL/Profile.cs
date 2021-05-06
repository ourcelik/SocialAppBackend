using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Concrete.GraphQL
{
    public class Profile : Entities.Concrete.Profile, IEntity
    {
        [NotMapped]
        public Photo ProfilePhoto { get; set; }
        [NotMapped]
        public Notification notification { get; set; }
        [NotMapped]
        public Prefer Prefer { get; set; }
        [NotMapped]
        public Gender Gender { get; set; }
        [NotMapped]
        public List<Photo> Photos { get; set; }

    }

}