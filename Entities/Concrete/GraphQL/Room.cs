using Core.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Concrete.GraphQL
{
    public class Room : Entities.Concrete.Room, IEntity
    {
        [NotMapped]
        public ChatLevel ChatLevel { get; set; }
        [NotMapped]
        public List<RoomMember> RoomMembers { get; set; }
    }

}