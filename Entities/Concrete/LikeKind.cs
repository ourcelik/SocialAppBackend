using Core.Entities;

namespace Entities.Concrete
{
    public class LikeKind : IEntity
    {
        public int LikeId { get; set; }
        public string Kind { get; set; }
    }

}