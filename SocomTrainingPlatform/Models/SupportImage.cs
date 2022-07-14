using System;
using System.Collections.Generic;

#nullable disable

namespace SocomTrainingPlatform.Models
{
    public partial class SupportImage
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        public int SupportId { get; set; }

        public virtual Support Support { get; set; }
    }
}
