using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace SocomTrainingPlatform.Models
{
    public partial class PocLocation
    {
        [Key]
        [Column(Order = 1)]
        public int LocationId { get; set; }
        [Key]
        [Column(Order = 2)]
        public int PocId { get; set; }

        public virtual Location Location { get; set; }
        public virtual PointOfContact Poc { get; set; }
    }
}
