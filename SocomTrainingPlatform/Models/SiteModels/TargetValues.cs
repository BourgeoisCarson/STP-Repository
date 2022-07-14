using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocomTrainingPlatform.Models.SiteModels
{
    public class TargetValues
    {
        public int LocationId { get; set; }
        public bool TargetBool { get; set; }
        public bool DaRaid { get; set; }
        public bool Rs { get; set; }
        public bool VehicleIntrediction { get; set; }
        public bool Ambush { get; set; }
        public bool Raa { get; set; }
        public bool VirtualSynthetic { get; set; }
        public bool Gaf { get; set; }
        public bool Haf { get; set; }
        public bool Baf { get; set; }
    }

    public class InsertValues
    {
        public int LocationId { get; set; }
        public bool InsertBool { get; set; }
        public bool AirfieldRunway { get; set; }
        public bool Dz { get; set; }
        public bool Hlz { get; set; }
        public bool Bls { get; set; }
        public bool SplashPoint { get; set; }
        public bool VdoLagger { get; set; }
    }

    public class SupportValues
    {
        public int LocationId { get; set; }
        public bool SupportBool { get; set; }
        public bool FuelFarm { get; set; }
        public bool MotorPool { get; set; }
        public bool Contractor { get; set; }
        public bool MedicalFacility { get; set; }

    }

    public class MeetingValues
    {
        public int LocationId { get; set; }
        public bool MeetingBool { get; set; }
        public bool Sa { get; set; }
        public bool Kle { get; set; }
    }

    public class BerthingValues
    {
        public int LocationId { get; set; }
        public bool BerthingBool { get; set; }
        public bool Ecg { get; set; }
        public bool SotfHq { get; set; }
        public bool Company { get; set; }
        public bool TeamSite { get; set; }
    }

    public class FinalFilterModel
    {
        public Location Location { get; set; }
        public TargetValues Target { get; set; }
        public InsertValues InsertPoint { get; set; }
        //public TrainingAreaTypetrainingType { get; set; }
        public SupportValues Support { get; set; }
        public BerthingValues BerthingWork { get; set; }
        public MeetingValues Meeting { get; set; }
    }
}
