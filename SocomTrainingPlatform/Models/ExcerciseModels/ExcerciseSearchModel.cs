using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

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
        public string ExcerciseChoice { get; set; }
        public int itemPerPage { get; set; }
        public int CurrentPage { get; set; }
        public int Page { get; set; }
        public string searchText { get; set; }
        public List<Location> AllLocations { get; set; }
        public int PageCount()
        {
            return Convert.ToInt32(Math.Ceiling(SearchModel.Count() / (double)itemPerPage));
        }
        public List<ExcerciseSearchModel> PaginatedModel()
        {
            int start = (CurrentPage - 1) * itemPerPage;
            return SearchModel.OrderByDescending(b => b.ExcerciseId).Skip(start).Take(itemPerPage).ToList();
        }
    }
}
