using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SocomTrainingPlatform.Models
{
    public class ExerciseEvent
    {
        public ExerciseEvent()
        {
            EventLocations = new HashSet<EventLocation>();
            EventDocuments = new HashSet<EventDocument>();
            EventChecklists = new HashSet<EventChecklist>();
        }

        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string EventName { get; set; }
        [Required]
        [StringLength(250)]
        public string EventDescription { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int ExerciseId { get; set; }
        public bool ShowOnCalendar { get; set; }
        public bool ShowOnTimeline { get; set; }

        public virtual ICollection<EventChecklist> EventChecklists { get; set; }
        public virtual ICollection<EventDocument> EventDocuments { get; set; }
        public virtual ICollection<EventLocation> EventLocations { get; set; }
        public virtual Excercise Excercise { get; set; }
    }
}
