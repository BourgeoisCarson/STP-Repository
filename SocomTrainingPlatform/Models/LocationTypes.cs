using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SocomTrainingPlatform.Models
{
    [Table("LocationTypes")]
    public partial class LocationTypes
    {
        [Key]
        public int TypesId { get; set; }
        public int LocationId { get; set; }
        public bool Target { get; set; }
        public bool Support { get; set; }
        public bool InsertPoint { get; set; }
        public bool Meeting { get; set; }
        public bool Berthing { get; set; }

        [ForeignKey(nameof(LocationId))]
        [InverseProperty("LocationTypess")]
        public virtual Location Location { get; set; }
    }
}
