using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocomTrainingPlatform.Models.ExcerciseModels
{
    public class ExcerciseSearchModel
    {
        //This is the model used to populate all excercises
        public int ExcerciseId { get; set; }
        public string ExcerciseName { get; set; }
        public string ExcerciseType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string ExcerciseChoice { get; set; }
    }

    public class ExcerciseIndex
    {
        public List<ExcerciseSearchModel> SearchModel { get; set; }
        public int Pages { get; set; }
        public int CurrentPage { get; set; }
        public string ExcerciseChoice { get; set; }
    }
}
