using System;
using System.Collections.Generic;

#nullable disable

namespace SocomTrainingPlatform.Models
{
    public partial class Organization
    {
        public Organization()
        {
            ExcerciseTypes = new HashSet<ExcerciseType>();
            Locations = new HashSet<Location>();
            SubOrganizations = new HashSet<SubOrganization>();
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ExcerciseType> ExcerciseTypes { get; set; }
        public virtual ICollection<Location> Locations { get; set; }
        public virtual ICollection<SubOrganization> SubOrganizations { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
