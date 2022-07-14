using System;
using System.Collections.Generic;

#nullable disable

namespace SocomTrainingPlatform.Models
{
    public partial class PointOfContact
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public int? PocOrgId { get; set; }
        public int? MouId { get; set; }

        public virtual Mou Mou { get; set; }
        public virtual PocOrganization PocOrg { get; set; }
    }
}
