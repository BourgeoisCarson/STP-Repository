using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GeoJSON.Net.Geometry;
using SocomTrainingPlatform.Models;

namespace SocomTrainingPlatform.Models
{
    public class LocationVM
    {
        public Location location { get; set; }
        public PointOfContact poc { get; set; }
        public List<LocationNote> note { get; set; }

        public List<Excercise> Excercises { get; set; }
        //public UsageDate indexDates { get; set; }
        //public List<UsageDate> dates { get; set; }
        public LocationTypes locTypes { get; set; }
        public string citySearch { get; set; }
        public string stateSearch { get; set; }
        public string targetSearch { get; set; }
        public string TrainingArea { get; set; }
        public string fullAddress { get; set; }
        public string InsertPoint { get; set; }
        public string BerthingWork { get; set; }
        public string Meeting { get; set; }
        public string Support { get; set; }
        [StringLength(250)]
        public string locNote { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Start Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime startDate { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "End Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime endDate { get; set; }
        public string fieldName { get; set; }
        public string fieldGrid { get; set; }
        public string fieldChoice { get; set; }
        public string tarChoice { get; set; }
        public string supChoice { get; set; }
        public string insChoice { get; set; }
        public string berChoice { get; set; }
        public string metChoice { get; set; }

        public int PocId { get; set; }
        public string EmailAddress { get; set; }
        [StringLength(25)]
        public string? FirstName { get; set; }
        [StringLength(25)]
        public string? LastName { get; set; }
        //[StringLength(20)]
        public string PhoneNumber { get; set; }
        [StringLength(25)]
        public string OrganizationName { get; set; }

        public bool Private { get; set; }
        public bool MilFed { get; set; }
        [Column("LEA")]
        public bool Lea { get; set; }
        public bool Commercial { get; set; }
        public bool FireMedical { get; set; }

        public int pocChoice { get; set; }

    }

}
