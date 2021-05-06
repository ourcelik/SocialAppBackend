using Core.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Entities.Concrete.GraphQL
{
    public class ChatLevel : Entities.Concrete.ChatLevel,IEntity
    {
  
        [NotMapped]
        public List<ConstantRoom> ConstantRooms { get; set; }
        [NotMapped]
        public List<Room> Rooms { get; set; }

    }

}