using System;
using System.Collections.Generic;

#nullable disable

namespace SocomTrainingPlatform.Models
{
    public partial class InsertImage
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        public int InsertPointId { get; set; }

        public virtual InsertPoint InsertPoint { get; set; }
    }
}
