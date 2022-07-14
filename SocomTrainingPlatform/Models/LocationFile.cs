using System;
using System.Collections.Generic;

#nullable disable

namespace SocomTrainingPlatform.Models
{
    public partial class LocationFile
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] FileData { get; set; }
        public int LocationId { get; set; }

        public virtual Location Location { get; set; }
    }
}
