using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocomTrainingPlatform.Models.SiteModels
{
    public class SearchModel
    {
        public Location Location { get; set; }
        public List<SiteField> SiteFields { get; set; }
    }
}
