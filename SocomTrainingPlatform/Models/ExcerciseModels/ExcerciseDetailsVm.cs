using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SocomTrainingPlatform.Models.ExcerciseModels
{
    public class ExcerciseDetailsVm
    {
        public Excercise Excercise { get; set; }
        public string ExStartDate { get; set; }
        public string ExEndDate { get; set; }

        //********Location Events************
        public List<SiteEventModel> EventModel { get; set; }
        public List<LocationEvent> LocationEvents { get; set; }
        public JsonResult validRange { get; set; }
        public string LocationEventName { get; set; }
        public string locationName { get; set; }
        public int FieldResult { get; set; }
        public string FieldDescription { get; set; }

        //***********************************

        //***********ExerciseEvent***********
        [Required]
        [StringLength(50)]
        public string EventName { get; set; }
        public string EventDescription { get; set; }
        [Required]
        public DateTime EventStartDate { get; set; }
        [Required]
        public DateTime EventEndDate { get; set; }
        [Required]
        public bool ShowOnCalendar { get; set; }
        [Required]
        public bool ShowOnTimeline { get; set; }
        //***********************************

        //********* Calendar Events**********
        public List<ExerciseEvent> EventList { get; set; }
        public int ExerciseEventId { get; set; }

        public DateTime EventStartTime { get; set; }
        public DateTime EventEndTime { get; set; }
        public bool ShowEvent { get; set; }

        //***********************************

        public List<BreifDocModels> Briefs { get; set; }

        public List<SupportDocModels> Docs { get; set; }

        //public List<Location> Locations { get; set; }

        public List<ExcerciseNote> Notes { get; set; }
        public List<Mou> Mous { get; set; }

        public string AlertMessage { get; set; }

        public string ExcerciseType { get; set; }

        [Required]
        public string FileName { get; set; }

        [Required]
        [BindProperty]
        public IFormFile file { get; set; }

        public int Id { get; set; }
        public DateTime DateStamp { get; set; }

        public List<Location> AllLocations { get; set; }
        public List<Mou> AllMous { get; set; }
        public int NewLocationId { get; set; }

        public string LocationChoice { get; set; }
        public string NoteBody { get; set; }
        public string NoteSubject { get; set; }

        public int MouChoice { get; set; }
        public int MouId { get; set; }

        //Create MOU Fields
        [Required]
        public IFormFile MouFile { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string lastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string FileType { get; set; }
    }
}
