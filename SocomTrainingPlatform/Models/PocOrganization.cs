using System;
using System.Collections.Generic;

#nullable disable

namespace SocomTrainingPlatform.Models
{
    public partial class PocOrganization
    {
        public PocOrganization()
        {
            PointOfContacts = new HashSet<PointOfContact>();
        }

        public int Id { get; set; }
        public string OrgName { get; set; }
        public bool MilFed { get; set; }
        public bool Private { get; set; }
        public bool Lea { get; set; }
        public bool Commercial { get; set; }
        public bool FireMedical { get; set; }

        public virtual ICollection<PointOfContact> PointOfContacts { get; set; }
    }
}
