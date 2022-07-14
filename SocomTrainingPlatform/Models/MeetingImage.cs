using System;
using System.Collections.Generic;

#nullable disable

namespace SocomTrainingPlatform.Models
{
    public partial class MeetingImage
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public byte[] ImageFile { get; set; }
        public int MeetingId { get; set; }

        public virtual Meeting Meeting { get; set; }
    }
}
