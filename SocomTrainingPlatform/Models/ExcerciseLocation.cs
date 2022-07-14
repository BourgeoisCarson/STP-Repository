using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace SocomTrainingPlatform.Models
{
    [Keyless]
    public partial class ExcerciseLocation
    {
        [Key]
        [Column(Order = 1)]
        public int ExcerciseId { get; set; }
        [Key]
        [Column(Order = 2)]
        public int LocationId { get; set; }

        public virtual Excercise Excercise { get; set; }
        public virtual Location Location { get; set; }
    }
}
