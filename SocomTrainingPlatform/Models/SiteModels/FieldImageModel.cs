using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocomTrainingPlatform.Models.SiteModels
{
    public class FieldImageModel
    {
        public SiteField Field { get; set; }
        public List<FieldImage> Images { get; set; }
    }
}
