using Castle.Components.DictionaryAdapter;
using Core.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Concrete.GraphQL
{
    public class ConstantRoomMember : Entities.Concrete.ConstantRoomMember, IEntity
    {
        [NotMapped]
        public ConstantRoom ConstantRoom { get; set; }
        
        [NotMapped]
        public Rank Rank { get; set; }

    }

}