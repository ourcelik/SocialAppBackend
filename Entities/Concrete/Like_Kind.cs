using Core.Entities;

namespace Entities.Concrete
{
    public class Like_Kind : IEntity
    {
        public int LikeId { get; set; }
        public string Kind { get; set; }
    }

}