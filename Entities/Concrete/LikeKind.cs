using Core.Entities;

namespace Entities.Concrete
{
    public class LikeKind : IEntity
    {
        public byte LikeKindId { get; set; }
        public string Kind { get; set; }
    }

}