using System;
using System.Collections.Generic;

#nullable disable

namespace SocomTrainingPlatform.Models
{
    public partial class TrainingArea
    {
        public TrainingArea()
        {
            Locations = new HashSet<Location>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Location> Locations { get; set; }
    }
}
