using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SocomTrainingPlatform.Models.ExcerciseModels
{
    public class SupportDocModels
    {
        public SupportDocModels(SupportDocument supDocs)
        {
            this.FileName = supDocs.FileName;
            this.Id = supDocs.Id;
            this.UploadDate = supDocs.DateStamp;

            using (var ms = new MemoryStream(supDocs.FileData))
            {
                this.file = new FormFile(ms, 0, ms.Length, supDocs.FileName, supDocs.FileType);
            }

        }

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

        public BreifDocModels(ExcerciseBrief brief)
        {
            this.FileName = brief.FileTitle;
            this.Id = brief.Id;
            this.UploadDate = brief.DateStamp;

            using (var ms = new MemoryStream(brief.FileData))
            {
                this.file = new FormFile(ms, 0, ms.Length, brief.FileTitle, brief.FileType);
            }
        }

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
