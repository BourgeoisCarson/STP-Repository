using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace SocomTrainingPlatform.Models
{
    public partial class ExcerciseNote
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "End Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Column(TypeName = "date")]
        public DateTime DateStamp { get; set; }
        public string UserId { get; set; }
        public int? CustomUserId { get; set; }
        public int ExcerciseId { get; set; }

        public virtual User CustomUser { get; set; }
        public virtual Excercise Excercise { get; set; }
        public virtual AspNetUser User { get; set; }
    }
}
