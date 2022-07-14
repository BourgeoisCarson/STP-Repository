using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SocomTrainingPlatform.Models.ExcerciseModels
{
    public class SupportDocModels
    {
        [Required]
        public string FileName { get; set; }

        [Required]
        [BindProperty]
        public IFormFile file { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "End Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Column(TypeName = "date")]
        public DateTime UploadDate { get; set; }

        public int Id { get; set; }

    }

    public class BreifDocModels
    {
        [Required]
        public string FileName { get; set; }

        [Required]
        [BindProperty]
        public IFormFile file { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "End Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Column(TypeName = "date")]
        public DateTime UploadDate { get; set; }

        public int Id { get; set; }
    }
}
