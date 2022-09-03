using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocomTrainingPlatform.Models.ExcerciseModels
{
    public class SiteEventModel
    {
        public SiteEventModel(LocationEvent locEvent)
        {
            this.id = locEvent.Id;
            this.start = locEvent.StartDate;
            this.end = locEvent.EndDate;
            this.title = $"{locEvent.FieldName} - {locEvent.FieldType}";
        }

        public SiteEventModel(ExerciseEvent exEvent)
        {
            this.id = exEvent.Id;
            this.start = exEvent.StartTime;
            this.end = exEvent.EndTime;
            this.title = exEvent.EventName;
        }

        public int id { get; set; }
        public DateTime start { get; set; }
        public DateTime end { get; set; }
        public string title { get; set; }

 
    }
}
