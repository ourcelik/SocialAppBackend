using Core.Entities;

namespace Entities.Concrete
{
    public class Prefer : IEntity
    {
        public int PreferId { get; set; }
        public int MinAge { get; set; }
        public int MaxAge { get; set; }
        public int MaxDistance { get; set; }
        public int GenderPrefer { get; set; }
        public bool Universal { get; set; }
        public bool ShowMe { get; set; }
        public bool Autoplay { get; set; }
        public bool LastSeen { get; set; }
        public bool AppVoice { get; set; }

    }

}