using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace SocomTrainingPlatform.Models
{
    public partial class Excercise
    {
        public Excercise()
        {
            ExcerciseBriefs = new HashSet<ExcerciseBrief>();
            ExcerciseNotes = new HashSet<ExcerciseNote>();
            SupportDocuments = new HashSet<SupportDocument>();
            LocationEvents = new HashSet<LocationEvent>();
            ExerciseEvents = new HashSet<ExerciseEvent>();
        }

        public int Id { get; set; }
        public string TypeName { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "End Date")]
        //[DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        [Column(TypeName = "date")]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "End Date")]
        //[DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        [Column(TypeName = "date")]
        public DateTime EndDate { get; set; }
        public int ExcerciseTypeId { get; set; }

        public virtual ExcerciseType ExcerciseType { get; set; }
        public virtual ICollection<ExcerciseBrief> ExcerciseBriefs { get; set; }
        public virtual ICollection<ExcerciseNote> ExcerciseNotes { get; set; }
        public virtual ICollection<SupportDocument> SupportDocuments { get; set; }
        public virtual ICollection<LocationEvent> LocationEvents { get; set; }
        public virtual ICollection<ExerciseEvent> ExerciseEvents { get; set; }
    }
}
