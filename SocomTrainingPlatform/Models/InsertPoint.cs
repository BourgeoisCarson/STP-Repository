using System;
using System.Collections.Generic;

#nullable disable

namespace SocomTrainingPlatform.Models
{
    public partial class InsertPoint
    {
        public InsertPoint()
        {
            InsertImages = new HashSet<InsertImage>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Grid { get; set; }
        public string Type { get; set; }
        public bool AirfieldRunway { get; set; }
        public bool Dz { get; set; }
        public bool Hlz { get; set; }
        public bool Bls { get; set; }
        public bool SplashPoint { get; set; }
        public bool VdoLagger { get; set; }
        public int LocationId { get; set; }

        public virtual Location Location { get; set; }
        public virtual ICollection<InsertImage> InsertImages { get; set; }
    }
}
