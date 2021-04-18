using Core.Entities;
using System;

namespace Entities.Concrete
{
    public class Prefer : IEntity
    {
        public int PreferId { get; set; }
        public byte MinAge { get; set; }
        public byte MaxAge { get; set; }
        public Int16 MaxDistance { get; set; }
        public byte GenderPreferId { get; set; }
        public bool Universal { get; set; }
        public bool ShowMe { get; set; }
        public bool Autoplay { get; set; }
        public bool LastSeen { get; set; }
        public bool AppVoice { get; set; }

    }

}