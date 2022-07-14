using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocomTrainingPlatform.Models.ExcerciseModels
{
    public class AddExcerciseVm
    {
        public List<SelectListItem> TypeList { get; set; }
        public string TypeChoice { get; set; }
        public string ExcerciseName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
