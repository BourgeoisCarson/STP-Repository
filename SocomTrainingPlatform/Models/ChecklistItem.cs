using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocomTrainingPlatform.Models
{
    public class ChecklistItem
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public bool Completed { get; set; }
        public int ChecklistId { get; set; }

        public virtual EventChecklist EventChecklist { get; set; }
    }
}
