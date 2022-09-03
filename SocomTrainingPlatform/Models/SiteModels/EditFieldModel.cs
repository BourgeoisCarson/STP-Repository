using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocomTrainingPlatform.Models.SiteModels
{
    public class EditFieldModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Field { get; set; }
        public string Description { get; set; }
        public string Grid { get; set; }
        public int LocationId { get; set; }
        public string FieldChoice { get; set; }
        public string TypeChoice { get; set; }
    }
}
