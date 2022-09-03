using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocomTrainingPlatform.Models
{
    public partial class LocationEvent
    {

        public int Id { get; set; }
        public int ExerciseId { get; set; }
        public int LocationId { get; set; }
        public string EventName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string LocationName { get; set; }
        public string FieldName { get; set; }
        public string FieldType { get; set; }
        public bool ShowOnCalendar { get; set; }
        public bool ShowOnTimeline { get; set; }
        public string Description { get; set; }

        public virtual Excercise Excercise { get; set; }
        public virtual Location Location { get; set; }


    }
}
