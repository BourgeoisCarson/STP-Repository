using SocomTrainingPlatform.Models.SiteModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocomTrainingPlatform.Models.ExcerciseModels
{
    public class EventStep1
    {
        public int ExcerciseId { get; set; }
        public string[] SelectedNames { get; set; }
        public List<SearchModel> SearchModel { get; set; }
        public int itemPerPage { get; set; }
        public int CurrentPage { get; set; }
        public int Page { get; set; }
        public string searchText { get; set; }
        public List<Location> AllLocations { get; set; }
        public int PageCount()
        {
            return Convert.ToInt32(Math.Ceiling(SearchModel.Count() / (double)itemPerPage));
        }
        public List<SearchModel> PaginatedModel()
        {
            int start = (CurrentPage - 1) * itemPerPage;
            return SearchModel.OrderBy(b => b.Location.Id).Skip(start).Take(itemPerPage).ToList();
        }
        public string stateSearch { get; set; }
        public string citySearch { get; set; }
        public string FieldChoice { get; set; }
        public string TypeChoice { get; set; }
    }
}
