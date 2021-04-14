using Core.Entities;

namespace Entities.Concrete
{
    public class Photo : IEntity
    {
        public int PhotoId { get; set; }
        public string Url { get; set; }
        public int ProfileId { get; set; }
    }

}