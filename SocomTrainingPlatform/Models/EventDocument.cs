using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SocomTrainingPlatform.Models
{
    public class EventDocument
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] Data { get; set; }
        public string FileType { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "End Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Column(TypeName = "date")]
        public DateTime UploadDate { get; set; }
        public int EventId { get; set; }

        public virtual ExerciseEvent ExerciseEvent { get; set; }
    }
}
