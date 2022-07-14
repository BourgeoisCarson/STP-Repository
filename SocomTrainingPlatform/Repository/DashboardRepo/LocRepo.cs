using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SocomTrainingPlatform.Data;
using RavenSiteSurvey.Models;
using RavenSiteSurvey.Models.VIewModels;
using RavenSiteSurvey;
using SocomTrainingPlatform.Models;

namespace RavenSiteSurvey.Repositories
{


    public class LocRepo: ILocRepo
    {
        public readonly SocomTrainingPlatformContext _context;

        public LocRepo(SocomTrainingPlatformContext Context)
        {
            _context = Context;
        }

        public IEnumerable<Target> GetTargetResults(string target)
        {

            List<Target> targetList = _context.Targets.ToList();

            string A = "DA/Raid";
            string B = "Vehicle Intrediction";
            string c = "R&S";
            string D = "RAA";
            string E = "Ambush";
            string F = "Virtual/Synthetic";

            if (target == A)
            {
               targetList = targetList.Where(T => T.DaRaid == true).ToList();
            }
            if (target == B)
            {
                targetList = targetList.Where(T => T.VehicleIntrediction == true).ToList();
            }
            if (target == c)
            {
                targetList = targetList.Where(T => T.Rs == true).ToList();
            }
            if (target == D)
            {
                targetList = targetList.Where(T => T.Raa == true).ToList();
            }
            if (target == E)
            {
                targetList = targetList.Where(T => T.Ambush == true).ToList();
            }
            if (target == F)
            {
               targetList = targetList.Where(T => T.VirtualSynthetic == true).ToList();
            }

            return targetList;

        }

        //public IEnumerable<TrainingAreaType> GetTrainingArea(string trainingTypes)
        //{
        //    //List<string> newList = new List<string> { "Private", "MilFed", "Lea", "Commercial", "FireMedical" };
        //    List<TrainingAreaType> TAList = _context.TrainingAreaTypes.ToList();

        //    string A = "Private";
        //    string B = "MilFed";
        //    string c = "Lea";
        //    string D = "Commercial";
        //    string E = "Fire/Medical";

        //    if (trainingTypes == A)
        //    {
        //        TAList = TAList.Where(T => T.Private == true).ToList();
        //    }
        //    if (trainingTypes == B)
        //    {
        //        TAList = TAList.Where(T => T.MilFed == true).ToList();
        //    }
        //    if (trainingTypes == c)
        //    {
        //        TAList = TAList.Where(T => T.Lea == true).ToList();
        //    }
        //    if (trainingTypes == D)
        //    {
        //        TAList = TAList.Where(T => T.Commercial == true).ToList();
        //    }
        //    if (trainingTypes == E)
        //    {
        //        TAList = TAList.Where(T => T.FireMedical == true).ToList();
        //    }


        //    return TAList;

        //}

        public IEnumerable<InsertPoint> GetInsertPoints(string InsertPoints)
        {
            //List<string> newList = new List<string> { "Private", "MilFed", "Lea", "Commercial", "FireMedical" };
            List<InsertPoint> IPList = _context.InsertPoints.ToList();

            string A = "AirfieldRunway";
            string B = "Dz";
            string c = "Hlz";
            string D = "Bls";
            string E = "SplashPoint";
            string F = "VdoLagger";

            if (InsertPoints == A)
            {
                IPList = IPList.Where(T => T.AirfieldRunway == true).ToList();
            }
            if (InsertPoints == B)
            {
                IPList = IPList.Where(T => T.Dz == true).ToList();
            }
            if (InsertPoints == c)
            {
                IPList = IPList.Where(T => T.Hlz == true).ToList();
            }
            if (InsertPoints == D)
            {
                IPList = IPList.Where(T => T.Bls == true).ToList();
            }
            if (InsertPoints == E)
            {
                IPList = IPList.Where(T => T.SplashPoint == true).ToList();
            }
            if (InsertPoints == F)
            {
                IPList = IPList.Where(T => T.VdoLagger == true).ToList();
            }


            return IPList;

        }

        public IEnumerable<BerthingWork> GetBerthingWork(string BerthingWork)
        {
            //List<string> newList = new List<string> { "Private", "MilFed", "Lea", "Commercial", "FireMedical" };
            List<BerthingWork> BWList = _context.BerthingWorks.ToList();

            string A = "ECG";
            string B = "SotfHhq";
            string C = "Company";
            string D = "TeamSite";

            if (BerthingWork == A)
            {
                BWList = BWList.Where(T => T.Ecg == true).ToList();
            }
            if (BerthingWork == B)
            {
                BWList = BWList.Where(T => T.SotfHq == true).ToList();
            }
            if (BerthingWork == C)
            {
                BWList = BWList.Where(T => T.Company == true).ToList();
            }
            if (BerthingWork == D)
            {
                BWList = BWList.Where(T => T.TeamSite == true).ToList();
            }

            return BWList;

        }

        public IEnumerable<Support> GetSUpportFields(string supportFields)
        {
            List<Support> SupportList = _context.Supports.ToList();

            string A = "FuelFarm";
            string B = "MotorPool";
            string C = "Contractor";
            string D = "MedicalFacility";


            if (supportFields == A)
            {
                SupportList = SupportList.Where(T => T.FuelFarm == true).ToList();
            }
            if (supportFields == B)
            {
                SupportList = SupportList.Where(T => T.MotorPool == true).ToList();
            }
            if (supportFields == C)
            {
                SupportList = SupportList.Where(T => T.Contractor == true).ToList();
            }
            if (supportFields == D)
            {
                SupportList = SupportList.Where(T => T.MedicalFacility == true).ToList();
            }

            return SupportList;

        }

        public IEnumerable<Meeting> GetMeetingFields(string meetingFields)
        {
            List<Meeting> MeetingList = _context.Meetings.ToList();

            string A = "Kle";
            string B = "Sa";

            if (meetingFields == A)
            {
                MeetingList = MeetingList.Where(T => T.Kle == true).ToList();
            }
            if(meetingFields == B)
            {
                MeetingList = MeetingList.Where(T => T.Sa == true).ToList();
            }

            return MeetingList;
        }

        public IEnumerable<LocationVM> PopulateVM()
        {

            List<Location> Location = _context.Locations.ToList();
            List<PointOfContact> Poc = _context.PointOfContacts.ToList();
            List<Target> Target = _context.Targets.ToList();
            List<InsertPoint> insertPoints = _context.InsertPoints.ToList();
            List<Support> support = _context.Supports.ToList();
            List<BerthingWork> berthingWorks = _context.BerthingWorks.ToList();
            List<Meeting> Meeting = _context.Meetings.ToList();
            List<Location> CitySearch = _context.Locations.ToList();
            //List<UsageDate> usageDates = _context.UsageDates.ToList();

            LocationVM newVm = new LocationVM();

                var viewLocations = from l in Location
                                    join t in Target on l.Id equals t.LocationId into table1
                                    from t in table1
                                    join i in insertPoints on l.Id equals i.LocationId into table2
                                    from i in table2
                                    //where l.TrainingAreaTypes != null
                                    //join tr in trainingAreaTypes on l.Id equals tr.LocationId into table3
                                    //from tr1 in table3.DefaultIfEmpty()
                                    join s in support on l.Id equals s.LocationId into table4
                                    from s in table4
                                    join b in berthingWorks on l.Id equals b.LocationId into table5
                                    from b in table5
                                    join m in Meeting on l.Id equals m.LocationId into table6
                                    from m in table6
                                    //where l.UsageDates != null
                                    //join u in usageDates on l.LocationId equals u.LocationId into table7
                                    //from u1 in table7.DefaultIfEmpty()
                                    select new LocationVM
                                    {
                                        location = l,
                                        target = t,
                                        insertPoint = i,
                                        //trainingType = tr1,
                                        support = s,
                                        berthingWork = b,
                                        meeting = m,
                                        //indexDates = usageDates.FirstOrDefault(u => u.LocationId == l.Id),
                                    };
            

            

                return viewLocations;


        }

        public IEnumerable<LocationVM> PopulateVM(LocationVM locationVm)
        {
            List<Location> Location = _context.Locations.ToList();

            //Setting the STRING values selected in the filter boxes
            var cityOpt = locationVm.citySearch;
            var stateOpt = locationVm.stateSearch;

            //Setting location values to the selected filter boxes
            if (stateOpt != null)
            {
                Location = Location.Where(L => L.State == stateOpt).ToList();
            }
            if (cityOpt != null)
            {
                Location = Location.Where(L => L.City == cityOpt).ToList();
            }

            var targetOpt = locationVm.targetSearch;
            var trainingAreaOpt = locationVm.TrainingArea;
            var berthingWorkOpt = locationVm.BerthingWork;
            var supportOpt = locationVm.Support;
            var insertOpt = locationVm.InsertPoint;
            var meetingOpt = locationVm.Meeting;

            List<Target> Target = GetTargetResults(targetOpt).ToList();
            //List<TrainingAreaType> trainingAreaTypes = GetTrainingArea(trainingAreaOpt).ToList();
            List<InsertPoint> insertPoints = GetInsertPoints(insertOpt).ToList();
            List<Support> support = GetSUpportFields(supportOpt).ToList();
            List<BerthingWork> berthingWorks = GetBerthingWork(berthingWorkOpt).ToList();
            List<Meeting> Meeting = GetMeetingFields(meetingOpt).ToList();
            //List<UsageDate> usageDates = _context.UsageDates.ToList();


            var viewLocations = from l in Location
                                join t in Target on l.Id equals t.LocationId into table1
                                from t in table1
                                join i in insertPoints on l.Id equals i.LocationId into table2
                                from i in table2
                                //where l.TrainingAreaTypes != null
                                //join tr in trainingAreaTypes on l.LocationId equals tr.LocationId into table3
                                //from tr1 in table3.DefaultIfEmpty()
                                join s in support on l.Id equals s.LocationId into table4
                                from s in table4
                                join b in berthingWorks on l.Id equals b.LocationId into table5
                                from b in table5
                                join m in Meeting on l.Id equals m.LocationId into table6
                                from m in table6
                                    //where l.UsageDates != null
                                    //join u in usageDates on l.LocationId equals u.LocationId into table7
                                    //from u1 in table7.DefaultIfEmpty()
                                select new LocationVM
                                {
                                    location = l,
                                    target = t,
                                    insertPoint = i,
                                   // trainingType = tr1,
                                    support = s,
                                    berthingWork = b,
                                    meeting = m,
                                    //indexDates = usageDates.FirstOrDefault(u => u.LocationId == l.LocationId),
                                };




            return viewLocations;


        }



        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
