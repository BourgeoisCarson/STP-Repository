using System;
using System.Collections.Generic;

#nullable disable

namespace SocomTrainingPlatform.Models
{
    public partial class BerthingImage
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public byte[] ImageFile { get; set; }
        public int BerthingWorkId { get; set; }

        public virtual BerthingWork BerthingWork { get; set; }
    }
}
