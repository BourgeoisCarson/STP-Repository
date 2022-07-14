using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocomTrainingPlatform.Models.ExcerciseModels
{
    public class AddLocationVm
    {
        public List<SelectListItem> Locations { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public string locChoice { get; set; }
        public int LocationId { get; set; }
    }
}
