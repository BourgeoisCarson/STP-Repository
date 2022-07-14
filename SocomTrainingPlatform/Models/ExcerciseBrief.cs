using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace SocomTrainingPlatform.Models
{
    public partial class ExcerciseBrief
    {
        public int Id { get; set; }
        public string FileTitle { get; set; }
        public byte[] FileData { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "End Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Column(TypeName = "date")]
        public DateTime DateStamp { get; set; }
        public int ExcerciseId { get; set; }
        public string FileType { get; set; }

        public virtual Excercise Excercise { get; set; }
    }
}
