using System;
using System.Collections.Generic;

#nullable disable

namespace SocomTrainingPlatform.Models
{
    public partial class Support
    {
        public Support()
        {
            SupportImages = new HashSet<SupportImage>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Grid { get; set; }
        public string Type { get; set; }
        public bool FuelFarm { get; set; }
        public bool MotorPool { get; set; }
        public bool Contractor { get; set; }
        public bool MedicalFacility { get; set; }
        public int LocationId { get; set; }

        public virtual Location Location { get; set; }
        public virtual ICollection<SupportImage> SupportImages { get; set; }
    }
}
