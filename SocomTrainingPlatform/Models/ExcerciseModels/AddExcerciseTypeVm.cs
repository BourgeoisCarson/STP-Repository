using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocomTrainingPlatform.Models.ExcerciseModels
{
    public class AddExcerciseTypeVm
    {
        public List<SelectListItem> Organizations { get; set; }
        public string OrgChoice { get; set; }
        public string ExcerciseName { get; set; }
        public string ExcerciseDescription { get; set; }
    }
}
