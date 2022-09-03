using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SocomTrainingPlatform.Models
{
    [Keyless]
    public partial class MouExcercise
    {
        [Key]
        [Column(Order = 1)]
        public int MouId { get; set; }
        [Key]
        [Column(Order = 2)]
        public int ExcerciseId { get; set; }

        public virtual Excercise Mou { get; set; }
        public virtual Location Excercise { get; set; }
    }
}
