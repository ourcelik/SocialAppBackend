using Core.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Concrete.GraphQL
{
    public class RoomMember : Entities.Concrete.RoomMember, IEntity
    {
        [NotMapped]
        public Room Room { get; set; }
 
        [NotMapped]
        public Rank Rank { get; set; }
    }

}