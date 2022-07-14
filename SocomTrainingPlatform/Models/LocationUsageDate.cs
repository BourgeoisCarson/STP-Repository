using System;
using System.Collections.Generic;

#nullable disable

namespace SocomTrainingPlatform.Models
{
    public partial class LocationUsageDate
    {
        public int Id { get; set; }
        public int LocationId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public virtual Location Location { get; set; }
    }
}
