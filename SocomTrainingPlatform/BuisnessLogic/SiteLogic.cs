using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SocomTrainingPlatform.Data;
using RavenSiteSurvey.Models;
using SocomTrainingPlatform.Models;
using SocomTrainingPlatform.Models.DashboardModels.DashboardViewModels;
using SocomTrainingPlatform.Models.SiteModels;
using Microsoft.EntityFrameworkCore;

namespace RavenSiteSurvey.BuisnessLogic
{


    public class SiteLogic
    {
        public readonly SocomTrainingPlatformContext _context;

        public SiteLogic(SocomTrainingPlatformContext Context)
        {
            _context = Context;
        }

        public IEnumerable<Target> GetTargetResults(string target)
        {
            List<Location> locList = new();
            List<Target> newList = new();
            List<Target> targetList = _context.Targets.ToList();

            string A = "Da/Raid";
            string B = "Vehicle Intrediction";
            string c = "R&S";
            string D = "RAA";
            string E = "Ambush";
            string F = "Virtual/Synthetic";

            if (target == A)
            {
                targetList = targetList.Where(t => t.DaRaid == true).ToList();
                //newList.Add(targetList.FirstOrDefault(T => T.DaRaid == true));
            }
            if (target == B)
            {
                targetList = targetList.Where(T => T.VehicleIntrediction == true).ToList();
                //newList.Add(targetList.FirstOrDefault(T => T.VehicleIntrediction == true));
            }
            if (target == c)
            {
                targetList = targetList.Where(T => T.Rs == true).ToList();
                //newList.Add(targetList.FirstOrDefault(T => T.Rs == true));
            }
            if (target == D)
            {
                targetList = targetList.Where(T => T.Raa == true).ToList();
               // newList.Add(targetList.FirstOrDefault(T => T.Raa == true));
            }
            if (target == E)
            {
                targetList = targetList.Where(T => T.Ambush == true).ToList();
                //newList.Add(targetList.FirstOrDefault(T => T.Ambush == true));
            }
            if (target == F)
            {
                targetList = targetList.Where(T => T.VirtualSynthetic == true).ToList();
                //newList.Add(targetList.FirstOrDefault(T => T.VirtualSynthetic == true));
            }

            //foreach (var item in targetList)
            //{
            //    locList.Add(_context.Locations.First(t => t.Id == item.LocationId));
            //}

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
            if (meetingFields == B)
            {
                MeetingList = MeetingList.Where(T => T.Sa == true).ToList();
            }

            return MeetingList;
        }

        public IEnumerable<DashboardVm> PopulateVM()
        {

            List<Location> Location = _context.Locations.ToList();
            List<PointOfContact> Poc = _context.PointOfContacts.ToList();
            List<Target> Target = _context.Targets.ToList();
            //List<TrainingAreaType> trainingAreaTypes = _context.TrainingAreaTypes.ToList();
            List<InsertPoint> insertPoints = _context.InsertPoints.ToList();
            List<Support> support = _context.Supports.ToList();
            List<BerthingWork> berthingWorks = _context.BerthingWorks.ToList();
            List<Meeting> Meeting = _context.Meetings.ToList();
            List<Location> CitySearch = _context.Locations.ToList();
            //List<UsageDate> usageDates = _context.UsageDates.ToList();

            LocationVM newVm = new LocationVM();

            List<TargetValues> tValues = SetTargetValues(Target);
            List<InsertValues> iValues = SetInsertValues(insertPoints);
            List<SupportValues> sValues = SetSupportValues(support);
            List<BerthingValues> bValues = SetBerthingValues(berthingWorks);
            List<MeetingValues> mValues = SetMeetingValues(Meeting);


            var viewLocations = from l in Location.Distinct()
                                    //where Target != null                              
                                join t in tValues on l.Id equals t.LocationId into table1
                                from t in table1.DefaultIfEmpty()
                                //where insertPoints != null
                                join i in iValues on l.Id equals i.LocationId into table2
                                from i in table2.DefaultIfEmpty()
                                join s in sValues on l.Id equals s.LocationId into table4
                                from s in table4.DefaultIfEmpty()
                                join b in bValues on l.Id equals b.LocationId into table5
                                from b in table5.DefaultIfEmpty()
                                join m in mValues on l.Id equals m.LocationId into table6
                                from m in table6.DefaultIfEmpty()
                                select new DashboardVm
                                {
                                    Location = l,
                                    Target = t,
                                    InsertPoint = i,
                                    Support = s,
                                    BerthingWork = b,
                                    Meeting = m,
                                    //indexDates = usageDates.FirstOrDefault(u => u.LocationId == l.LocationId),
                                };

            

            

            return viewLocations.Distinct();


        }

        public IEnumerable<DashboardVm> PopulateVM(DashboardVm locationVm)
        {
            List<Location> Location = _context.Locations.ToList();

            //setting the string values selected in the filter boxes
            var cityopt = locationVm.citySearch;
            var stateopt = locationVm.stateSearch;

            //setting location values to the selected filter boxes
            if (stateopt != null)
            {
                Location = Location.Where(l => l.State == stateopt).ToList();
            }
            if (cityopt != null)
            {
               Location = Location.Where(l => l.City == cityopt).ToList();
            }

            var targetOpt = locationVm.targetSearch;
            var berthingWorkOpt = locationVm.berthingWork;
            var supportOpt = locationVm.support;
            var insertOpt = locationVm.insertPoint;
            var meetingOpt = locationVm.meeting;

            List<Target> Target = GetTargetResults(targetOpt).ToList();
            List<InsertPoint> insertPoints = GetInsertPoints(insertOpt).ToList();
            List<Support> support = GetSUpportFields(supportOpt).ToList();
            List<BerthingWork> berthingWorks = GetBerthingWork(berthingWorkOpt).ToList();
            List<Meeting> Meeting = GetMeetingFields(meetingOpt).ToList();

            List<TargetValues> tValues = SetTargetValues(Target);
            List<InsertValues> iValues = SetInsertValues(insertPoints);
            List<SupportValues> sValues = SetSupportValues(support);
            List<BerthingValues> bValues = SetBerthingValues(berthingWorks);
            List<MeetingValues> mValues = SetMeetingValues(Meeting);

            List<DashboardVm> Dash = new();
            DashboardVm tempModel = new();
            List<int> LocationIds = new();

            foreach(var t in tValues)
            {
                    LocationIds.Add(t.LocationId);
            }
            foreach(var i in iValues)
            {
                    LocationIds.Add(i.LocationId);           
            }
            foreach(var s in sValues)
            {
                    LocationIds.Add(s.LocationId);
            }
            foreach(var b in bValues)
            {
                    LocationIds.Add(b.LocationId);
            }
            foreach(var m in mValues)
            {
                    LocationIds.Add(m.LocationId);
            }

            LocationIds.Distinct();
            List<Location> newLocList = new();

            foreach(var i in LocationIds)
            {
                foreach(var loc in Location)
                {
                    if(loc.Id == i)
                    {
                        newLocList.Add(loc);
                    }
                }
            }

            foreach(var loc in newLocList)
            {
                tempModel.Location = loc;
                tempModel.Target = tValues.FirstOrDefault(t => t.LocationId == loc.Id);
                tempModel.Support = sValues.FirstOrDefault(t => t.LocationId == loc.Id);
                tempModel.Meeting = mValues.FirstOrDefault(t => t.LocationId == loc.Id);
                tempModel.BerthingWork = bValues.FirstOrDefault(t => t.LocationId == loc.Id);
                tempModel.InsertPoint = iValues.FirstOrDefault(t => t.LocationId == loc.Id);

                Dash.Add(tempModel);
            }
           

            var viewLocations = from l in Location
                                join t in tValues on l.Id equals t.LocationId into table1
                                from t in table1.DefaultIfEmpty()
                                join i in iValues on l.Id equals i.LocationId into table2
                                from i in table2.DefaultIfEmpty()
                                join s in sValues on l.Id equals s.LocationId into table4
                                from s in table4.DefaultIfEmpty()
                                join b in bValues on l.Id equals b.LocationId into table5
                                from b in table5.DefaultIfEmpty()
                                join m in mValues on l.Id equals m.LocationId into table6
                                from m in table6.DefaultIfEmpty()
                                    //where l.UsageDates != null
                                    //join u in usageDates on l.LocationId equals u.LocationId into table7
                                    //from u1 in table7.DefaultIfEmpty()
                                select new DashboardVm
                                {
                                    Location = l,
                                    Target = t,
                                    InsertPoint = i,
                                    Support = s,
                                    BerthingWork = b,
                                    Meeting = m,

                                };
            



            return Dash.AsEnumerable();


        }

        public List<TargetModel> GetTarget(int id)
        {
            List<Target> Target = _context.Targets.Where(T => T.LocationId == id).ToList();
            List<TargetImage> tImage = new();

            List<TargetModel> TModel = new();
           
            foreach (var item in Target)
            {
                if(_context.TargetImages.FirstOrDefault(t => t.TargetId == item.Id) != null)
                {
                    tImage = (_context.TargetImages.Where(t => t.TargetId == item.Id).ToList());
                }
                else
                {
                    tImage = null;
                }
                
                TargetModel newModel = new() { Target = item, Images = tImage };

                TModel.Add(newModel);
            };

            return TModel;
        }

        public List<InsertModel> GetInsertPoint(int id)
        {
            List<InsertPoint> insertPoints = _context.InsertPoints.Where(I => I.LocationId == id).ToList();
            List<InsertImage> iImage = new();
            List<InsertModel> IModel = new();

            foreach (var item in insertPoints)
            {
                if (_context.InsertImages.FirstOrDefault(t => t.InsertPointId == item.Id) != null)
                {
                    iImage = (_context.InsertImages.Where(t => t.InsertPointId == item.Id).ToList());
                }
                else
                {
                    iImage = null;
                }

                InsertModel newModel = new() { InsertPoint = item, Images = iImage };

                IModel.Add(newModel);
            };

            return IModel;

        }

        public List<SupportModel> GetSupport(int id)
        {
            List<Support> support = _context.Supports.Where(S => S.LocationId == id).ToList();
            List<SupportImage> sImage = new();
            List<SupportModel> SModel = new();

            foreach (var item in support)
            {
                if (_context.SupportImages.FirstOrDefault(s => s.SupportId == item.Id) != null)
                {
                    sImage = (_context.SupportImages.Where(s => s.SupportId == item.Id).ToList());
                }
                else
                {
                    sImage = null;
                }

                SupportModel newModel = new() { Support = item, Image = sImage };

                SModel.Add(newModel);
            }

            return SModel;
        }

        public List<MeetingModel> GetMeeting(int id)
        {
            List<Meeting> Meeting = _context.Meetings.Where(M => M.LocationId == id).ToList();
            List<MeetingImage> mImage = new();
            List<MeetingModel> MModel = new();

            foreach (var item in Meeting)
            {
                if (_context.MeetingImages.FirstOrDefault(s => s.MeetingId == item.Id) != null)
                {
                    mImage = (_context.MeetingImages.Where(s => s.MeetingId == item.Id).ToList());
                }
                else
                {
                    mImage = null;
                }

                MeetingModel newModel = new() { Meeting = item, Images = mImage };

                MModel.Add(newModel);
            }

            return MModel;
        }

        public List<BerthingModel> GetBerthing(int id)
        {
            List<BerthingWork> berthingWorks =  _context.BerthingWorks.Where(B => B.LocationId == id).ToList();
            List<BerthingImage> bImage = new();
            List<BerthingModel> BModel = new();

            foreach (var item in berthingWorks)
            {
                if (_context.BerthingImages.FirstOrDefault(s => s.BerthingWorkId == item.Id) != null)
                {
                    bImage = (_context.BerthingImages.Where(s => s.BerthingWorkId == item.Id).ToList());
                }
                else
                {
                    bImage = null;
                }

                BerthingModel newModel = new() { Berthing = item, Images = bImage };

                BModel.Add(newModel);
            }

            return BModel;

        }

        public List<FinalFilterModel> GetAllSites()
        {
            List<FinalFilterModel> filterModel = new();

            List<Location> Locations = _context.Locations.ToList();
            List<Target> Target = _context.Targets.ToList();
            //List<TrainingAreaType> trainingAreaTypes = _context.TrainingAreaTypes.ToList();
            List<InsertPoint> insertPoints = _context.InsertPoints.ToList();
            List<Support> support = _context.Supports.ToList();
            List<BerthingWork> berthingWorks = _context.BerthingWorks.ToList();
            List<Meeting> Meeting = _context.Meetings.ToList();
            List<Location> CitySearch = _context.Locations.ToList();

            List<TargetValues> tValues = SetTargetValues(Target);
            List<InsertValues> iValues = SetInsertValues(insertPoints);
            List<SupportValues> sValues = SetSupportValues(support);
            List<BerthingValues> bValues = SetBerthingValues(berthingWorks);
            List<MeetingValues> mValues = SetMeetingValues(Meeting);

            //Setting location values to the selected filter boxes

            List<FinalFilterModel> Dash = new();


            foreach (var loc in Locations)
            {
                FinalFilterModel tempModel = new();

                tempModel.Location = loc;
                tempModel.Target = tValues.FirstOrDefault(t => t.LocationId == loc.Id);
                tempModel.Support = sValues.FirstOrDefault(t => t.LocationId == loc.Id);
                tempModel.Meeting = mValues.FirstOrDefault(t => t.LocationId == loc.Id);
                tempModel.BerthingWork = bValues.FirstOrDefault(t => t.LocationId == loc.Id);
                tempModel.InsertPoint = iValues.FirstOrDefault(t => t.LocationId == loc.Id);

                Dash.Add(tempModel);
            }



            return Dash;
        }

        public List<FinalFilterModel> GetAllSites(DashboardVm locationVm)
        {
            List<FilterModels> filterModel = new();
            List<FilterModels> newFilterModel = new();
            List<Location> newLocation = new();

            var cityOpt = locationVm.citySearch;
            var stateOpt = locationVm.stateSearch;

            List<Location> Locations = _context.Locations.ToList();
            List<PointOfContact> Poc = _context.PointOfContacts.ToList();
            List<Target> Target = _context.Targets.ToList();
            //List<TrainingAreaType> trainingAreaTypes = _context.TrainingAreaTypes.ToList();
            List<InsertPoint> insertPoints = _context.InsertPoints.ToList();
            List<Support> support = _context.Supports.ToList();
            List<BerthingWork> berthingWorks = _context.BerthingWorks.ToList();
            List<Meeting> Meeting = _context.Meetings.ToList();
            List<Location> CitySearch = _context.Locations.ToList();

            List<TargetValues> tValues = SetTargetValues(Target);
            List<InsertValues> iValues = SetInsertValues(insertPoints);
            List<SupportValues> sValues = SetSupportValues(support);
            List<BerthingValues> bValues = SetBerthingValues(berthingWorks);
            List<MeetingValues> mValues = SetMeetingValues(Meeting);

            List<Location> firstFilterLocations = new();

            //Setting location values to the selected filter boxes
            if (stateOpt != null)
            {
                firstFilterLocations = Locations.Where(L => L.State == stateOpt).ToList();
            }
            else if (cityOpt != null)
            {
                firstFilterLocations = Locations.Where(L => L.City == cityOpt).ToList();
            }
            else
            {
                firstFilterLocations = _context.Locations.ToList();
            }

            List<FinalFilterModel> Dash = new();


            foreach (var loc in firstFilterLocations)
            {
                FinalFilterModel tempModel = new();

                tempModel.Location = loc;
                tempModel.Target = tValues.FirstOrDefault(t => t.LocationId == loc.Id);
                tempModel.Support = sValues.FirstOrDefault(t => t.LocationId == loc.Id);
                tempModel.Meeting = mValues.FirstOrDefault(t => t.LocationId == loc.Id);
                tempModel.BerthingWork = bValues.FirstOrDefault(t => t.LocationId == loc.Id);
                tempModel.InsertPoint = iValues.FirstOrDefault(t => t.LocationId == loc.Id);

                Dash.Add(tempModel);
            }

            if(locationVm.FieldChoice != "Choose...")
            {
                List<FinalFilterModel> FinalDashList = new();

                foreach (var item in Dash)
                {
                    if (locationVm.FieldChoice == "A" && item.Target != null && item.Target.TargetBool == true && locationVm.TarChoice == null)
                    {
                        FinalDashList.Add(item);
                    }
                    else if(locationVm.FieldChoice == "A" && item.Target != null && locationVm.TarChoice != null)
                    {
                        if (locationVm.TarChoice == "DA/Raid" && item.Target.DaRaid == true)
                        {
                            FinalDashList.Add(item);
                        }
                        if (locationVm.TarChoice == "R&S" && item.Target.Rs == true)
                        {
                            FinalDashList.Add(item);
                        }
                        if (locationVm.TarChoice == "VehicleIntrediction" && item.Target.VehicleIntrediction == true)
                        {
                            FinalDashList.Add(item);
                        }
                        if (locationVm.TarChoice == "Ambush" && item.Target.Ambush == true)
                        {
                            FinalDashList.Add(item);
                        }
                        if (locationVm.TarChoice == "RAA" && item.Target.Raa == true)
                        {
                            FinalDashList.Add(item);
                        }
                        if (locationVm.TarChoice == "VirtualSynthetic" && item.Target.VirtualSynthetic == true)
                        {
                            FinalDashList.Add(item);
                        }
                        if (locationVm.TarChoice == "Haf" && item.Target.Haf == true)
                        {
                            FinalDashList.Add(item);
                        }
                        if (locationVm.TarChoice == "Gaf" && item.Target.Gaf == true)
                        {
                            FinalDashList.Add(item);
                        }
                        if (locationVm.TarChoice == "Baf" && item.Target.Baf == true)
                        {
                            FinalDashList.Add(item);
                        }
                    }


                    if (locationVm.FieldChoice == "B" && item.Support != null && item.Support.SupportBool == true && locationVm.SupChoice == null)
                    {
                        FinalDashList.Add(item);
                    }
                    else if(locationVm.FieldChoice == "B" && item.Support != null && locationVm.SupChoice != null)
                    {
                        if (locationVm.SupChoice == "MotorPool" && item.Support.MotorPool == true)
                        {
                            FinalDashList.Add(item);
                        }
                        if (locationVm.SupChoice == "FuelFarm" && item.Support.FuelFarm == true)
                        {
                            FinalDashList.Add(item);
                        }
                        if (locationVm.SupChoice == "Contractor" && item.Support.Contractor == true)
                        {
                            FinalDashList.Add(item);
                        }
                        if (locationVm.SupChoice == "MedicalFacility" && item.Support.MedicalFacility == true)
                        {
                            FinalDashList.Add(item);
                        }
                    }



                    if (locationVm.FieldChoice == "C" && item.InsertPoint != null && item.InsertPoint.InsertBool == true && locationVm.InsChoice == null)
                    {
                        FinalDashList.Add(item);
                    }
                    else if(locationVm.FieldChoice == "C" && item.InsertPoint != null && locationVm.InsChoice != null)
                    {
                        if (locationVm.InsChoice == "Airfield/Runway" && item.InsertPoint.AirfieldRunway == true)
                        {
                            FinalDashList.Add(item);
                        }
                        if (locationVm.InsChoice == "DZ" && item.InsertPoint.Dz == true)
                        {
                            FinalDashList.Add(item);
                        }
                        if (locationVm.InsChoice == "HLZ" && item.InsertPoint.Hlz == true)
                        {
                            FinalDashList.Add(item);
                        }
                        if (locationVm.InsChoice == "SplashPoint" && item.InsertPoint.SplashPoint == true)
                        {
                            FinalDashList.Add(item);
                        }
                        if (locationVm.InsChoice == "VDO/Lagger" && item.InsertPoint.VdoLagger == true)
                        {
                            FinalDashList.Add(item);
                        }
                    }

                    if (locationVm.FieldChoice == "D" && item.BerthingWork != null && item.BerthingWork.BerthingBool == true && locationVm.BerChoice == null)
                    {
                        FinalDashList.Add(item);
                    }
                    else if(locationVm.FieldChoice == "D" && item.BerthingWork != null && locationVm.BerChoice != null)
                    {
                        if (locationVm.BerChoice == "ECG" && item.BerthingWork.Ecg == true)
                        {
                            FinalDashList.Add(item);
                        }
                        if (locationVm.BerChoice == "SOTF/HHQ" && item.BerthingWork.SotfHq == true)
                        {
                            FinalDashList.Add(item);
                        }
                        if (locationVm.BerChoice == "Company" && item.BerthingWork.Company == true)
                        {
                            FinalDashList.Add(item);
                        }
                        if (locationVm.BerChoice == "TeamSite" && item.BerthingWork.TeamSite == true)
                        {
                            FinalDashList.Add(item);
                        }
                    }


                    if (locationVm.FieldChoice == "E" && item.Meeting != null && item.Meeting.MeetingBool == true && locationVm.MetChoice == null)
                    {
                        FinalDashList.Add(item);
                    }
                    else if(locationVm.FieldChoice == "E" && item.Meeting != null && locationVm.MetChoice != null)
                    {
                        if (locationVm.MetChoice == "KLE" && item.Meeting.Kle == true)
                        {
                            FinalDashList.Add(item);
                        }
                        if (locationVm.MetChoice == "SA" && item.Meeting.Sa == true)
                        {
                            FinalDashList.Add(item);
                        }
                    }

                }

                Dash = FinalDashList;
            }

            return Dash;
        }

        public List<TargetValues> SetTargetValues(List<Target> Target)
        {
            var tValues = new List<TargetValues>();

            foreach (var item in Target)
            {
                TargetValues tempValues = new();

                if (tValues.Count() != 0)
                {
                    foreach (var t in tValues.ToList())
                    {
                        if (t.LocationId != item.LocationId)
                        {
                            tempValues.LocationId = item.LocationId;
                            tempValues.TargetBool = true;

                            if (item.Ambush == true){ tempValues.Ambush = true; }
                            else { tempValues.Ambush = false; }
                            if (item.Baf == true)
                            {
                                tempValues.Baf = true;
                            }
                            if (item.Haf == true)
                            {
                                tempValues.Haf = true;
                            }
                            if (item.Rs == true)
                            {
                                tempValues.Rs = true;
                            }
                            if (item.DaRaid == true)
                            {
                                tempValues.DaRaid = true;
                            }
                            if (item.Raa == true)
                            {
                                tempValues.Rs = true;
                            }
                            if (item.Gaf == true)
                            {
                                tempValues.Gaf = true;
                            }
                            if(item.VirtualSynthetic == true)
                            {
                                tempValues.VirtualSynthetic = true;
                            }
                            if(item.VehicleIntrediction == true)
                            {
                                tempValues.VehicleIntrediction = true;
                            }

                            tValues.Add(tempValues);

                        }
                        else if (t.LocationId == item.LocationId)
                        {
                            if (item.Ambush == true)
                            {
                                t.Ambush = true;
                            }
                            if (item.Baf == true)
                            {
                                t.Baf = true;
                            }
                            if (item.Haf == true)
                            {
                                t.Haf = true;
                            }
                            if (item.Rs == true)
                            {
                                t.Rs = true;
                            }
                            if (item.DaRaid == true)
                            {
                                t.DaRaid = true;
                            }
                            if (item.Raa == true)
                            {
                                t.Rs = true;
                            }
                            if (item.Gaf == true)
                            {
                                t.Gaf = true;
                            }
                        }
                    }
                }
                else if (tValues.Count() == 0)
                {
                    tempValues.LocationId = item.LocationId;
                    tempValues.TargetBool = true;

                    if (item.Ambush == true)
                    {
                        tempValues.Ambush = true;
                    }
                    if (item.Baf == true)
                    {
                        tempValues.Baf = true;
                    }
                    if (item.Haf == true)
                    {
                        tempValues.Haf = true;
                    }
                    if (item.Rs == true)
                    {
                        tempValues.Rs = true;
                    }
                    if (item.DaRaid == true)
                    {
                        tempValues.DaRaid = true;
                    }
                    if (item.Raa == true)
                    {
                        tempValues.Rs = true;
                    }
                    if (item.Gaf == true)
                    {
                        tempValues.Gaf = true;
                    }

                    tValues.Add(tempValues);
                }

            }

            return tValues;
        }

        public List<InsertValues> SetInsertValues (List<InsertPoint> Insert)
        {
            List<InsertValues> iValues = new();

            foreach (var item in Insert.ToList())
            {
                InsertValues tempValues = new();

                if (iValues.Count() != 0)
                {
                    foreach (var t in iValues.ToList())
                    {
                        if (t.LocationId != item.LocationId)
                        {
                            tempValues.LocationId = item.LocationId;
                            tempValues.InsertBool = true;

                            if (item.SplashPoint == true)
                            {
                                tempValues.SplashPoint = true;
                            }
                            if (item.Dz == true)
                            {
                                tempValues.Dz = true;
                            }
                            if (item.AirfieldRunway == true)
                            {
                                tempValues.AirfieldRunway = true;
                            }
                            if (item.Hlz == true)
                            {
                                tempValues.Hlz = true;
                            }
                            if (item.Bls == true)
                            {
                                tempValues.Bls = true;
                            }
                            if (item.VdoLagger == true)
                            {
                                tempValues.VdoLagger = true;
                            }

                            iValues.Add(tempValues);

                        }
                        else if (t.LocationId == item.LocationId)
                        {
                            if (item.SplashPoint == true)
                            {
                                t.SplashPoint = true;
                            }
                            if (item.Dz == true)
                            {
                                t.Dz = true;
                            }
                            if (item.AirfieldRunway == true)
                            {
                                t.AirfieldRunway = true;
                            }
                            if (item.Hlz == true)
                            {
                                t.Hlz = true;
                            }
                            if (item.Bls == true)
                            {
                                t.Bls = true;
                            }
                            if (item.VdoLagger == true)
                            {
                                t.VdoLagger = true;
                            }
                        }
                    }
                }
                else if (iValues.Count() == 0)
                {
                    tempValues.LocationId = item.LocationId;
                    tempValues.InsertBool = true;

                    if (item.SplashPoint == true)
                    {
                        tempValues.SplashPoint = true;
                    }
                    if (item.Dz == true)
                    {
                        tempValues.Dz = true;
                    }
                    if (item.AirfieldRunway == true)
                    {
                        tempValues.AirfieldRunway = true;
                    }
                    if (item.Hlz == true)
                    {
                        tempValues.Hlz = true;
                    }
                    if (item.Bls == true)
                    {
                        tempValues.Bls = true;
                    }
                    if (item.VdoLagger == true)
                    {
                        tempValues.VdoLagger = true;
                    }

                    iValues.Add(tempValues);
                }

            }

            return iValues;
        }

        public List<SupportValues> SetSupportValues(List<Support> Support)
        {
            List<SupportValues> sValues = new();

            foreach (var item in Support)
            {
                SupportValues tempValues = new();

                if (sValues.Count() != 0)
                {
                    foreach (var t in sValues.ToList())
                    {
                        if (t.LocationId != item.LocationId)
                        {
                            tempValues.LocationId = item.LocationId;
                            tempValues.SupportBool = true;

                            if (item.Contractor == true)
                            {
                                tempValues.Contractor = true;
                            }
                            if (item.FuelFarm == true)
                            {
                                tempValues.FuelFarm = true;
                            }
                            if (item.MotorPool == true)
                            {
                                tempValues.MotorPool = true;
                            }
                            if (item.MedicalFacility == true)
                            {
                                tempValues.MedicalFacility = true;
                            }

                            sValues.Add(tempValues);

                        }
                        else if (t.LocationId == item.LocationId)
                        {
                            if (item.Contractor == true)
                            {
                               t.Contractor = true;
                            }
                            if (item.FuelFarm == true)
                            {
                                t.FuelFarm = true;
                            }
                            if (item.MotorPool == true)
                            {
                                t.MotorPool = true;
                            }
                            if (item.MedicalFacility == true)
                            {
                                t.MedicalFacility = true;
                            }
                        }
                    }
                }
                else if (sValues.Count() == 0)
                {
                    tempValues.LocationId = item.LocationId;
                    tempValues.SupportBool = true;

                    if (item.Contractor == true)
                    {
                        tempValues.Contractor = true;
                    }
                    if (item.FuelFarm == true)
                    {
                        tempValues.FuelFarm = true;
                    }
                    if (item.MotorPool == true)
                    {
                        tempValues.MotorPool = true;
                    }
                    if (item.MedicalFacility == true)
                    {
                        tempValues.MedicalFacility = true;
                    }

                    sValues.Add(tempValues);
                }

            }

            return sValues;
        }

        public List<MeetingValues> SetMeetingValues(List<Meeting> Meeting)
        {
            List<MeetingValues> mValues = new();

            foreach (var item in Meeting)
            {
                MeetingValues tempValues = new();

                if (mValues.Count() != 0)
                {
                    foreach (var t in mValues.ToList())
                    {
                        if (t.LocationId != item.LocationId)
                        {
                            tempValues.LocationId = item.LocationId;
                            tempValues.MeetingBool = true;

                            if (item.Kle == true)
                            {
                                tempValues.Kle = true;
                            }
                            if (item.Sa == true)
                            {
                                tempValues.Sa = true;
                            }

                            mValues.Add(tempValues);
                        }
                        else if (t.LocationId == item.LocationId)
                        {
                            if (item.Kle == true)
                            {
                                t.Kle = true;
                            }
                            if (item.Sa == true)
                            {
                                t.Sa = true;
                            }
                        }
                    }
                }
                else if(mValues.Count() == 0)
                {
                    tempValues.LocationId = item.LocationId;
                    tempValues.MeetingBool = true;

                    if (item.Kle == true)
                    {
                        tempValues.Kle = true;
                    }
                    if (item.Sa == true)
                    {
                        tempValues.Sa = true;
                    }

                    mValues.Add(tempValues);
                }
            }
            return mValues;
        }

        public List<BerthingValues> SetBerthingValues(List<BerthingWork> Meeting)
        {
            List<BerthingValues> bValues = new();

            foreach (var item in Meeting)
            {
                BerthingValues tempValues = new();

                if (bValues.Count() != 0)
                {
                    foreach (var t in bValues.ToList())
                    {
                        if (t.LocationId != item.LocationId)
                        {
                            tempValues.LocationId = item.LocationId;
                            tempValues.BerthingBool = true;

                            if (item.Company == true)
                            {
                                tempValues.Company = true;
                            }
                            if (item.SotfHq == true)
                            {
                                tempValues.SotfHq = true;
                            }
                            if (item.TeamSite == true)
                            {
                                tempValues.TeamSite = true;
                            }
                            if (item.Ecg == true)
                            {
                                tempValues.Ecg = true;
                            }

                            bValues.Add(tempValues);
                        }
                        else if (t.LocationId == item.LocationId)
                        {
                            if (item.Company == true)
                            {
                                t.Company = true;
                            }
                            if (item.SotfHq == true)
                            {
                                t.SotfHq = true;
                            }
                            if (item.TeamSite == true)
                            {
                                t.TeamSite = true;
                            }
                            if (item.Ecg == true)
                            {
                                t.Ecg = true;
                            }
                        }
                    }
                }
                else if (bValues.Count() == 0)
                {
                    tempValues.LocationId = item.LocationId;
                    tempValues.BerthingBool = true;

                    if (item.Company == true)
                    {
                        tempValues.Company = true;
                    }
                    if (item.SotfHq == true)
                    {
                        tempValues.SotfHq = true;
                    }
                    if (item.TeamSite == true)
                    {
                        tempValues.TeamSite = true;
                    }
                    if (item.Ecg == true)
                    {
                        tempValues.Ecg = true;
                    }

                    bValues.Add(tempValues);
                }
            }
            return bValues;
        }

        public FilterModels SetFilters(List<Target> targets, List<InsertPoint> insertPoints, List<BerthingWork> berthings, List<Meeting> meeting, List<Support> supports)
        {
            FilterModels filterModels = new();

            if(targets != null)
            {
                filterModels.Target = true;
            }

            foreach(var item in targets)
            {
                if(item.Ambush == true)
                {
                    filterModels.Ambush = true;
                }
                if(item.Baf == true)
                {
                    filterModels.Baf = true;
                }
                if(item.Haf == true)
                {
                    filterModels.Haf = true;
                }
                if(item.Rs == true)
                {
                    filterModels.Rs = true;
                }
                if(item.DaRaid == true)
                {
                    filterModels.DaRaid = true;
                }
                if(item.Raa == true)
                {
                    filterModels.Rs = true;
                }
                if(item.Gaf == true)
                {
                    filterModels.Gaf = true;
                }
            }

            if(insertPoints != null)
            {
                filterModels.InsertPoint = true;
            }

            foreach(var item in insertPoints)
            {
                if(item.SplashPoint == true)
                {
                    filterModels.SplashPoint = true;
                }
                if(item.Dz == true)
                {
                    filterModels.Dz = true;
                }
                if(item.AirfieldRunway == true)
                {
                    filterModels.AirfieldRunway = true;
                }
                if(item.Hlz == true)
                {
                    filterModels.Hlz = true;
                }
                if(item.Bls == true)
                {
                    filterModels.Bls = true;
                }
                if(item.VdoLagger == true)
                {
                    filterModels.VdoLagger = true;
                }
            }

            if(berthings != null)
            {
                filterModels.Berthing = true;
            }

            foreach(var item in berthings)
            {
                if(item.Company == true)
                {
                    filterModels.Company = true;
                }
                if(item.SotfHq == true)
                {
                    filterModels.SotfHq = true;
                }
                if(item.TeamSite == true)
                {
                    filterModels.TeamSite = true;
                }
                if(item.Ecg == true)
                {
                    filterModels.Ecg = true;
                }
            }

            if(meeting != null)
            {
                filterModels.Meeting = true;
            }

            foreach(var item in meeting)
            {
                if(item.Kle == true)
                {
                    filterModels.Kle = true;
                }
                if(item.Sa == true)
                {
                    filterModels.Sa = true;
                }
            }

            if (supports != null)
            {
                filterModels.Support = true;
            }

            foreach (var item in supports)
            {
                if(item.Contractor == true)
                {
                    filterModels.Contractor = true;
                }
                if(item.FuelFarm == true)
                {
                    filterModels.FuelFarm = true;
                }
                if(item.MotorPool == true)
                {
                    filterModels.MotorPool = true;
                }
                if(item.MedicalFacility == true)
                {
                    filterModels.MedicalFacility = true;
                }
            }

            return filterModels;
        }

        public void AddFields(DetailsVm locVm, int id)
        {
            Target newTar = new Target();
            Support newSup = new Support();
            InsertPoint newIns = new InsertPoint();
            BerthingWork newBer = new BerthingWork();
            Meeting newMet = new Meeting();
            LocationTypes locTypes = new LocationTypes();
            var fieldChoice = locVm.FieldChoice;
            var tarChoice = locVm.TarChoice;
            var insChoice = locVm.InsChoice;
            var supChoice = locVm.SupChoice;
            var berChoice = locVm.BerChoice;
            var metChoice = locVm.MetChoice;
            string validateFeild = "New Site Feild Added";

            switch (fieldChoice)
            {
                case "A":
                    //locTypes.LocationId = id;
                    //locTypes.Target = true;
                    
                    //_context.Add(locTypes);
                    //_context.SaveChanges();

                    if (tarChoice == "DA/Raid")
                    {
                        newTar.LocationId = id;
                        newTar.DaRaid = true;
                        newTar.Name = locVm.FieldName;
                        newTar.Description = locVm.FieldDescription;
                        newTar.Grid = locVm.FieldGrid;
                        _context.Add(newTar);
                        _context.SaveChanges();
                    }
                    if (tarChoice == "R&S")
                    {
                        newTar.LocationId = id;
                        newTar.Rs = true;
                        newTar.Name = locVm.FieldName;
                        newTar.Description = locVm.FieldDescription;
                        newTar.Grid = locVm.FieldGrid;
                        _context.Add(newTar);
                        _context.SaveChanges();
                    }
                    if (tarChoice == "VehicleIntrediction")
                    {
                        newTar.LocationId = id;
                        newTar.VehicleIntrediction = true;
                        newTar.Name = locVm.FieldName;
                        newTar.Description = locVm.FieldDescription;
                        newTar.Grid = locVm.FieldGrid;
                        _context.Add(newTar);
                        _context.SaveChanges();
                    }
                    if (tarChoice == "Ambush")
                    {
                        newTar.LocationId = id;
                        newTar.Ambush = true;
                        newTar.Name = locVm.FieldName;
                        newTar.Description = locVm.FieldDescription;
                        newTar.Grid = locVm.FieldGrid;
                        _context.Add(newTar);
                        _context.SaveChanges();
                    }
                    if (tarChoice == "RAA")
                    {
                        newTar.LocationId = id;
                        newTar.Raa = true;
                        newTar.Name = locVm.FieldName;
                        newTar.Description = locVm.FieldDescription;
                        newTar.Grid = locVm.FieldGrid;
                        _context.Add(newTar);
                        _context.SaveChanges();
                    }
                    if (tarChoice == "Virtual/Synthetic")
                    {
                        newTar.LocationId = id;
                        newTar.VirtualSynthetic = true;
                        newTar.Name = locVm.FieldName;
                        newTar.Description = locVm.FieldDescription;
                        newTar.Grid = locVm.FieldGrid;
                        _context.Add(newTar);
                        _context.SaveChanges();
                    }
                    if (tarChoice == "Baf")
                    {
                        newTar.LocationId = id;
                        newTar.Baf = true;
                        newTar.Name = locVm.FieldName;
                        newTar.Description = locVm.FieldDescription;
                        newTar.Grid = locVm.FieldGrid;
                        _context.Add(newTar);
                        _context.SaveChanges();
                    }
                    if (tarChoice == "Haf")
                    {
                        newTar.LocationId = id;
                        newTar.Haf = true;
                        newTar.Name = locVm.FieldName;
                        newTar.Description = locVm.FieldDescription;
                        newTar.Grid = locVm.FieldGrid;
                        _context.Add(newTar);
                        _context.SaveChanges();
                    }
                    if (tarChoice == "Gaf")
                    {
                        newTar.LocationId = id;
                        newTar.Gaf = true;
                        newTar.Name = locVm.FieldName;
                        newTar.Description = locVm.FieldDescription;
                        newTar.Grid = locVm.FieldGrid;
                        _context.Add(newTar);
                        _context.SaveChanges();
                    }
                    break;
                case "B":

                    //locTypes.LocationId = id;
                    //locTypes.Support = true;
                    //_context.Add(locTypes);
                    //_context.SaveChanges();

                    if (supChoice == "MotorPool")
                    {
                        newSup.LocationId = id;
                        newSup.MotorPool = true;
                        newSup.Name = locVm.FieldName;
                        newSup.Description = locVm.FieldDescription;
                        newSup.Grid = locVm.FieldGrid;
                        _context.Add(newSup);
                        _context.SaveChanges();
                    }
                    if (supChoice == "FuelFarm")
                    {
                        newSup.LocationId = id;
                        newSup.FuelFarm = true;
                        newSup.Name = locVm.FieldName;
                        newSup.Description = locVm.FieldDescription;
                        newSup.Grid = locVm.FieldGrid;
                        _context.Add(newSup);
                        _context.SaveChanges();
                    }
                    if (supChoice == "Contractor")
                    {
                        newSup.LocationId = id;
                        newSup.Contractor = true;
                        newSup.Name = locVm.FieldName;
                        newSup.Description = locVm.FieldDescription;
                        newSup.Grid = locVm.FieldGrid;
                        _context.Add(newSup);
                        _context.SaveChanges();

                    }
                    if (supChoice == "MedicalFacility")
                    {
                        newSup.LocationId = id;
                        newSup.MedicalFacility = true;
                        newSup.Name = locVm.FieldName;
                        newSup.Description = locVm.FieldDescription;
                        newSup.Grid = locVm.FieldGrid;
                        _context.Add(newSup);
                        _context.SaveChanges();

                    }
                    break;
                case "C":

                    //locTypes.LocationId = id;
                    //locTypes.InsertPoint = true;
                    //_context.Add(locTypes);
                    //_context.SaveChanges();

                    if (insChoice == "DZ")
                    {
                        newIns.LocationId = id;
                        newIns.Dz = true;
                        newIns.Name = locVm.FieldName;
                        newIns.Description = locVm.FieldDescription;
                        newIns.Grid = locVm.FieldGrid;
                        _context.Add(newIns);
                        _context.SaveChanges();
                    }
                    if (insChoice == "HLZ")
                    {
                        newIns.LocationId = id;
                        newIns.Dz = true;
                        newIns.Name = locVm.FieldName;
                        newIns.Description = locVm.FieldDescription;
                        newIns.Grid = locVm.FieldGrid;
                        _context.Add(newIns);
                        _context.SaveChanges();
                    }
                    if (insChoice == "Airfield/Runway")
                    {
                        newIns.LocationId = id;
                        newIns.AirfieldRunway = true;
                        newIns.Name = locVm.FieldName;
                        newIns.Description = locVm.FieldDescription;
                        newIns.Grid = locVm.FieldGrid;
                        _context.Add(newIns);
                        _context.SaveChanges();
                    }
                    if (insChoice == "SplashPoint")
                    {
                        newIns.LocationId = id;
                        newIns.SplashPoint = true;
                        newIns.Name = locVm.FieldName;
                        newIns.Description = locVm.FieldDescription;
                        newIns.Grid = locVm.FieldGrid;
                        _context.Add(newIns);
                        _context.SaveChanges();
                    }
                    if (insChoice == "VDO/Lagger")
                    {
                        newIns.LocationId = id;
                        newIns.VdoLagger = true;
                        newIns.Name = locVm.FieldName;
                        newIns.Description = locVm.FieldDescription;
                        newIns.Grid = locVm.FieldGrid;
                        _context.Add(newIns);
                        _context.SaveChanges();
                    }
                    break;
                case "D":

                    //locTypes.LocationId = id;
                    //locTypes.Berthing = true;
                    //_context.Add(locTypes);
                    //_context.SaveChanges();

                    if (berChoice == "ECG")
                    {
                        newBer.Ecg = true;
                        newBer.LocationId = id;
                        newBer.Name = locVm.FieldName;
                        newBer.Description = locVm.FieldDescription;
                        newBer.Grid = locVm.FieldGrid;
                        _context.Add(newBer);
                        _context.SaveChanges();
                    }
                    if (berChoice == "SOTF/HHQ")
                    {
                        newBer.SotfHq = true;
                        newBer.LocationId = id;
                        newBer.Name = locVm.FieldName;
                        newBer.Description = locVm.FieldDescription;
                        newBer.Grid = locVm.FieldGrid;
                        _context.Add(newBer);
                        _context.SaveChanges();
                    }
                    if (berChoice == "Company")
                    {
                        newBer.Company = true;
                        newBer.LocationId = id;
                        newBer.Name = locVm.FieldName;
                        newBer.Description = locVm.FieldDescription;
                        newBer.Grid = locVm.FieldGrid;
                        _context.Add(newBer);
                        _context.SaveChanges();
                    }
                    if (berChoice == "TeamSite")
                    {
                        newBer.TeamSite = true;
                        newBer.LocationId = id;
                        newBer.Name = locVm.FieldName;
                        newBer.Description = locVm.FieldDescription;
                        newBer.Grid = locVm.FieldGrid;
                        _context.Add(newBer);
                        _context.SaveChanges();
                    }
                    break;
                case "E":

                    //locTypes.LocationId = id;
                    //locTypes.Meeting = true;
                    //_context.Add(locTypes);
                    //_context.SaveChanges();

                    if (metChoice == "SA")
                    {
                        newMet.Sa = true;
                        newMet.LocationId = id;
                        newMet.Name = locVm.FieldName;
                        newMet.Description = locVm.FieldDescription;
                        newMet.Grid = locVm.FieldGrid;
                        _context.Add(newMet);
                        _context.SaveChanges();
                    }
                    if (metChoice == "KLE")
                    {
                        newMet.Kle = true;
                        newMet.LocationId = id;
                        newMet.Name = locVm.FieldName;
                        newMet.Description = locVm.FieldDescription;
                        newMet.Grid = locVm.FieldGrid;
                        _context.Add(newMet);
                        _context.SaveChanges();
                    }
                    break;



            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
