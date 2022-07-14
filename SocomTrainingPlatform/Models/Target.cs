using System;
using System.Collections.Generic;

#nullable disable

namespace SocomTrainingPlatform.Models
{
    public partial class Target
    {
        public Target()
        {
            TargetImages = new HashSet<TargetImage>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string Grid { get; set; }
        public bool DaRaid { get; set; }
        public bool Rs { get; set; }
        public bool VehicleIntrediction { get; set; }
        public bool Ambush { get; set; }
        public bool Raa { get; set; }
        public bool VirtualSynthetic { get; set; }
        public bool Gaf { get; set; }
        public bool Haf { get; set; }
        public bool Baf { get; set; }
        public int LocationId { get; set; }

        public virtual Location Location { get; set; }
        public virtual ICollection<TargetImage> TargetImages { get; set; }
    }
}
