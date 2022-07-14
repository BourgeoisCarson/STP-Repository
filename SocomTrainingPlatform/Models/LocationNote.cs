using System;
using System.Collections.Generic;

#nullable disable

namespace SocomTrainingPlatform.Models
{
    public partial class LocationNote
    {
        public int Id { get; set; }
        public int LocationId { get; set; }
        public string UserId { get; set; }
        public int? CustomUserId { get; set; }
        public DateTime Date { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

        public virtual User CustomUser { get; set; }
        public virtual Location Location { get; set; }
        public virtual AspNetUser User { get; set; }
    }
}
