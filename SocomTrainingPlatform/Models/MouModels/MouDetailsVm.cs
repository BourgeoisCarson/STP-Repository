using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SocomTrainingPlatform.Models.MouModels
{
    public class MouDetailsVm
    {
        public List<Location> Locations { get; set; }
        public List<Excercise> Exccercises { get; set; }
        public int Id { get; set; }
        public byte[] MouFile { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string lastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string FileType { get; set; }
        [NotMapped]
        public IFormFile File { get; set; }
    }
}
