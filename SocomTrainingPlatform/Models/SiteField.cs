using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocomTrainingPlatform.Models
{
    public partial class SiteField
    {
        public SiteField()
        {
            FieldImages = new HashSet<FieldImage>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Field { get; set; }
        public string Description { get; set; }
        public string Grid { get; set; }
        public int LocationId { get; set; }
        public virtual Location Location { get; set; }
        public virtual ICollection<FieldImage> FieldImages { get; set; }
    }
}
