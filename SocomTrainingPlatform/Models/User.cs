using System;
using System.Collections.Generic;

#nullable disable

namespace SocomTrainingPlatform.Models
{
    public partial class User
    {
        public User()
        {
            ExcerciseNotes = new HashSet<ExcerciseNote>();
            LocationNotes = new HashSet<LocationNote>();
        }

        public int Id { get; set; }
        public string EmailAddress { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Rank { get; set; }
        public string Unit { get; set; }
        public decimal? PhoneNumber { get; set; }
        public int? OrgId { get; set; }
        public int? SubOrgId { get; set; }

        public virtual Organization Org { get; set; }
        public virtual SubOrganization SubOrg { get; set; }
        public virtual ICollection<ExcerciseNote> ExcerciseNotes { get; set; }
        public virtual ICollection<LocationNote> LocationNotes { get; set; }
    }
}
