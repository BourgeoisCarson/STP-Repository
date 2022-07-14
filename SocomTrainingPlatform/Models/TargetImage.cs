using System;
using System.Collections.Generic;

#nullable disable

namespace SocomTrainingPlatform.Models
{
    public partial class TargetImage
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public byte[] ImageFile { get; set; }
        public int TargetId { get; set; }

        public virtual Target Target { get; set; }
    }
}
