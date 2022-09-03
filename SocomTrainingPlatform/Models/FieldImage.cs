using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocomTrainingPlatform.Models
{
    public partial class FieldImage
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        public int FieldId { get; set; }
        public virtual SiteField SiteField { get; set; }
    }
}
