using Core.Entities;

namespace Entities.Concrete
{
    public class Prefer : IEntity
    {
        public int PreferId { get; set; }
        public int Min_age { get; set; }
        public int Max_age { get; set; }
        public int Max_distance { get; set; }
        public int Gender_prefer { get; set; }
        public byte Universal { get; set; }
        public byte Show_me { get; set; }
        public byte Autoplay { get; set; }
        public byte Last_seen { get; set; }
        public byte App_voice { get; set; }

    }

}