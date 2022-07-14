using System;
using System.Collections.Generic;

#nullable disable

namespace SocomTrainingPlatform.Models
{
    public partial class Meeting
    {
        public Meeting()
        {
            MeetingImages = new HashSet<MeetingImage>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string Grid { get; set; }
        public bool Sa { get; set; }
        public bool Kle { get; set; }
        public int LocationId { get; set; }

        public virtual Location Location { get; set; }
        public virtual ICollection<MeetingImage> MeetingImages { get; set; }
    }
}
