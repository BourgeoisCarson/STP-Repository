using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SocomTrainingPlatform.Models.SiteModels
{
    public class AddSiteVm
    {

        [Key]
        public int LocationId { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        public string StreetAddress { get; set; }
        [Required]
        [StringLength(50)]
        public string City { get; set; }
        [Required]
        [StringLength(50)]
        public string State { get; set; }
        [Required]
        [StringLength(50)]
        public string ZipCode { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        [StringLength(50)]
        public string Grid { get; set; }
        [MaxLength(1)]
        public byte[] Mou { get; set; }
        [Column(TypeName = "date")]
        public DateTime? MouStartDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime? MouEndDate { get; set; }
    }
}
