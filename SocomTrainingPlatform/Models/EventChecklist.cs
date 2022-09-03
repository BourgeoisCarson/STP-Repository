using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocomTrainingPlatform.Models
{
    public class EventChecklist
    {
        public EventChecklist()
        {
            ChecklistItems = new HashSet<ChecklistItem>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int EventId { get; set; }

        public virtual ExerciseEvent ExcerciseEvent { get; set; }
        public virtual ICollection<ChecklistItem> ChecklistItems { get; set; }
    }
}
