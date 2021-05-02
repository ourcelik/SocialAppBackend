using Castle.Components.DictionaryAdapter;
using Core.Entities;

namespace Entities.Concrete
{
    public class ConstantRoomMember : IEntity
    {
        public int ConstantRoomMemberId { get; set; }
        public int ConstantRoomId { get; set; }
        public int UserId { get; set; }
        public byte RankId { get; set; }
    }

}