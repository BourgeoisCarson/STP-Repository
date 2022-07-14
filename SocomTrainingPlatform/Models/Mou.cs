using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace SocomTrainingPlatform.Models
{
    public partial class Mou
    {
        public Mou()
        {
            Locations = new HashSet<Location>();
            PointOfContacts = new HashSet<PointOfContact>();
        }

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
        public virtual ICollection<Location> Locations { get; set; }
        public virtual ICollection<PointOfContact> PointOfContacts { get; set; }
    }
}
