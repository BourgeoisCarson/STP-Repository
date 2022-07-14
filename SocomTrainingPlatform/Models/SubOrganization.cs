using System;
using System.Collections.Generic;

#nullable disable

namespace SocomTrainingPlatform.Models
{
    public partial class SubOrganization
    {
        public SubOrganization()
        {
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int OrgId { get; set; }

        public virtual Organization Org { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
