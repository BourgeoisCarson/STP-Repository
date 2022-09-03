using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocomTrainingPlatform.Models
{
    public class EventLocation
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public int LocationId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string LocationName { get; set; }
        public string FieldName { get; set; }
        public string FieldType { get; set; }
        public string Description { get; set; }

        public virtual ExerciseEvent ExerciseEvent { get; set; }
        public virtual Location Location { get; set; }

    }
}
