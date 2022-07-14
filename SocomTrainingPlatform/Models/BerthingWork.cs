using System;
using System.Collections.Generic;

#nullable disable

namespace SocomTrainingPlatform.Models
{
    public partial class BerthingWork
    {
        public BerthingWork()
        {
            BerthingImages = new HashSet<BerthingImage>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Grid { get; set; }
        public string Type { get; set; }
        public bool Ecg { get; set; }
        public bool SotfHq { get; set; }
        public bool Company { get; set; }
        public bool TeamSite { get; set; }
        public int LocationId { get; set; }

        public virtual Location Location { get; set; }
        public virtual ICollection<BerthingImage> BerthingImages { get; set; }
    }
}
