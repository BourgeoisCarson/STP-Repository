using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GeoJSON.Net.Geometry;
using SocomTrainingPlatform.Models.SiteModels;
using X.PagedList;

namespace SocomTrainingPlatform.Models.DashboardModels.DashboardViewModels
{
    public class DashboardVm
    {
        public List<SearchModel> SearchModel { get; set; }
        public Location Location { get; set; }
        public LocationNote note { get; set; }
        //public UsageDate indexDates { get; set; }
        //public List<UsageDate> dates { get; set; }
        //public LocationTypes locTypes { get; set; }
        public string citySearch { get; set; }
        public string stateSearch { get; set; }
        public string targetSearch { get; set; }
        public string TrainingArea { get; set; }
        public string fullAddress { get; set; }
        public string insertPoint { get; set; }
        public string berthingWork { get; set; }
        public string meeting { get; set; }
        public string support { get; set; }

        public string AddLocationChoice { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public string FieldName { get; set; }
        public string FieldDescription { get; set; }
        public string FieldGrid { get; set; }
        public string FieldChoice { get; set; }
        public string TypeChoice { get; set; }
        public string TarChoice { get; set; }
        public string SupChoice { get; set; }
        public string InsChoice { get; set; }
        public string BerChoice { get; set; }
        public string MetChoice { get; set; }
        public string GafChoice { get; set; }
        public string HafChoice { get; set; }
        public string BafChoice { get; set; }


    }

}
