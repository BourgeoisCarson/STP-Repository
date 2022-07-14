using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GeoJSON.Net.Geometry;
using SocomTrainingPlatform.Models.SiteModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace SocomTrainingPlatform.Models.DashboardModels.DashboardViewModels
{
    public class DetailsVm
    {

        public Location location { get; set; }
        public PointOfContact poc { get; set; }
        public List<PointOfContact> PocList { get; set; }
        public Mou mou { get; set; }
        public List<Mou> MouList { get; set; }
        public List<TargetModel> target { get; set; }
        public List<InsertModel> insertPoint { get; set; }
        //public TrainingAreaType trainingType { get; set; }
        public List<SupportModel> support { get; set; }
        public List<BerthingModel> berthingWork { get; set; }
        public List<MeetingModel> meeting { get; set; }
        public List<LocationNote> note { get; set; }
        public List<SupportImage> sImages { get; set; }
        public List<TargetImage> tImages { get; set; }
        public List<BerthingImage> bImages { get; set; }
        public List<InsertImage> iImages { get; set; }
        public List<MeetingImage> mImages { get; set; }

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
        public string NoteSubject { get; set; }
        [StringLength(250)]
        public string locNote { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Start Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime startDate { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "End Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime endDate { get; set; }
        public string FieldName { get; set; }
        public string FieldDescription { get; set; }
        public string FieldGrid { get; set; }
        public string FieldChoice { get; set; }
        public string TarChoice { get; set; }
        public string SupChoice { get; set; }
        public string InsChoice { get; set; }
        public string BerChoice { get; set; }
        public string MetChoice { get; set; }
        public string GafChoice { get; set; }
        public string HafChoice { get; set; }
        public string BafChoice { get; set; }
        public int ContactChoice { get; set; }
        public int MouChoice { get; set; }

        public string ImageField { get; set; }
        public int FieldId { get; set; }

        public int MouId { get; set; }
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

        [Required]
        public string ImageName { get; set; }

        [Required]
        [BindProperty]
        public IFormFile ImageData { get; set; }

        public string ImageDescription { get; set; }

        public string ImageSelection { get; set; }

    }

}
