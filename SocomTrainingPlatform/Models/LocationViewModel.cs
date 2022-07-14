using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Microsoft.EntityFrameworkCore;


namespace RavenSiteSurvey.Models.VIewModels

{
    public class LocationViewModel
    {

        
            [Key]
            public int LocationId { get; set; }
            [StringLength(50)]
            public string LocationName { get; set; }
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
            public string Zip { get; set; }
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




            public bool DaRaid { get; set; }
            [Column("R&S")]
            public bool RS { get; set; }
            public bool VehicleIntrediction { get; set; }
            public bool Ambush { get; set; }
            public bool Raa { get; set; }
            public bool VirtualSynthetic { get; set; }
        

     
            public bool AirfieldRunway { get; set; }
            [Column("DZ")]
            public bool Dz { get; set; }
            [Column("HLZ")]
            
            public bool Hlz { get; set; }
            [Column("BLS")]
            public bool Bls { get; set; }
            public bool SplashPoint { get; set; }
            public bool VdoLagger { get; set; }


            public bool Private { get; set; }
            public bool MilFed { get; set; }
            [Column("LEA")]
            public bool Lea { get; set; }
            public bool Commercial { get; set; }
            public bool FireMedical { get; set; }

       
            public bool FuelFarm { get; set; }
            public bool MotorPool { get; set; }
            public bool Contractor { get; set; }
            public bool MedicalFacility { get; set; }

       
            [Column("ECG")]
            public bool Ecg { get; set; }
            [Column("SotfHHQ")]
            public bool SotfHhq { get; set; }
            public bool Company { get; set; }
            public bool TeamSite { get; set; }

        
            [Column("SA")]
            public bool Sa { get; set; }
            [Column("KLE")]
            public bool Kle { get; set; }

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


        public string fieldChoice { get; set; }
        public string tarChoice { get; set; }
        public string supChoice { get; set; }
        public string insChoice { get; set; }
        public string berChoice { get; set; }
        public string metChoice { get; set; }



        /* public IQueryable<Location> Location { get; set; }
         public IQueryable<PointOfContact> PocLocation { get; set; }
         public IQueryable<Target> Target { get; set; }
         public IQueryable<InsertPoint> InsertPoint { get; set; }
         public IQueryable<TrainingAreaType> TrainingAreaType { get; set; }
         public IQueryable <Support> Support { get; set; }
         public IQueryable <BerthingWork> BerthingWorks { get; set; }
         public IQueryable<Meeting> Meeting { get; set; }
         public IQueryable<LocationNote> LocationNote { get; set; }
        */
    }
}
