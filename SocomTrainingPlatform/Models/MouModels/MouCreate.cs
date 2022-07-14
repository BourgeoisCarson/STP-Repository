using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SocomTrainingPlatform.Models.MouModels
{
    public class MouCreate
    {
        public int Id { get; set; }
        public IFormFile MouFile { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string lastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string FileType { get; set; }
    }
}
