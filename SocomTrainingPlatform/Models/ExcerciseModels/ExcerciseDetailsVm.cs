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

        public List<BreifDocModels> Briefs { get; set; }

        public List<SupportDocModels> Docs { get; set; }

        public List<Location> Locations { get; set; }

        public List<ExcerciseNote> Notes { get; set; }

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

        public int NewLocationId { get; set; }

        public string LocationChoice { get; set; }
        public string NoteBody { get; set; }
        public string NoteSubject { get; set; }
    }
}
