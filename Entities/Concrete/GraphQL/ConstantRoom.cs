using Core.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Concrete.GraphQL
{
    public class ConstantRoom : Entities.Concrete.ConstantRoom, IEntity
    {
        [NotMapped]
        public ChatLevel ChatLevel { get; set; }
        [NotMapped]
        public List<ConstantRoomMember> ConstantRoomMembers { get; set; }
    }

}