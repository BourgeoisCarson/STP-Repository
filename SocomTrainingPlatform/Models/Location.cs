using System;
using System.Collections.Generic;

#nullable disable

namespace SocomTrainingPlatform.Models
{
    public partial class Location
    {
        public Location()
        {
            BerthingWorks = new HashSet<BerthingWork>();
            InsertPoints = new HashSet<InsertPoint>();
            LocationFiles = new HashSet<LocationFile>();
            LocationNotes = new HashSet<LocationNote>();
            LocationUsageDates = new HashSet<LocationUsageDate>();
            Meetings = new HashSet<Meeting>();
            Supports = new HashSet<Support>();
            Targets = new HashSet<Target>();
            LocationTypess = new HashSet<LocationTypes>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public int? MouId { get; set; }
        public int? OrgId { get; set; }
        public int? TrainingAreaId { get; set; }

        public virtual Mou Mou { get; set; }
        public virtual Organization Org { get; set; }
        public virtual TrainingArea TrainingArea { get; set; }
        public virtual ICollection<BerthingWork> BerthingWorks { get; set; }
        public virtual ICollection<InsertPoint> InsertPoints { get; set; }
        public virtual ICollection<LocationFile> LocationFiles { get; set; }
        public virtual ICollection<LocationNote> LocationNotes { get; set; }
        public virtual ICollection<LocationUsageDate> LocationUsageDates { get; set; }
        public virtual ICollection<Meeting> Meetings { get; set; }
        public virtual ICollection<Support> Supports { get; set; }
        public virtual ICollection<Target> Targets { get; set; }
        public virtual ICollection<LocationTypes> LocationTypess { get; set; }

    }
}
