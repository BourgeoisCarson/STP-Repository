using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocomTrainingPlatform.Models.SiteModels
{
    public class StateSelectView
    {
        public string Id { get; set; }
        public string State { get; set; }
        public ICollection<CitySelectView> Citys { get; set; }
    }

    public class CitySelectView
    {
        public string Id { get; set; }
        public string City { get; set; }
        public string StateId { get; set; }
        public StateSelectView State { get; set; }
    }
        

}
