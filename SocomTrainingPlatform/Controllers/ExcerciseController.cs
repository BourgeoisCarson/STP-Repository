using SocomTrainingPlatform.BuisnessLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SocomTrainingPlatform.Models;
using SocomTrainingPlatform.Models.DashboardModels.DashboardViewModels;
using SocomTrainingPlatform.Models.ExcerciseModels;
using SocomTrainingPlatform.Models.SiteModels;
using SocomTrainingPlatform.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace SocomTrainingPlatform.Controllers
{
    public class ExcerciseController : Controller
    {
        private readonly SocomTrainingPlatformContext _context;
        private readonly SiteSearchLogic searchLogic;

        public ExcerciseController(SocomTrainingPlatformContext context)
        {
            _context = context;
            searchLogic = new SiteSearchLogic(context);
        }

        // GET: ExcerciseController
        public async Task<ActionResult> Index(int page = 1)
        {
            var excercise = await _context.Excercises.ToListAsync();
            var excerciseTypes = await _context.ExcerciseTypes.ToListAsync();

            var excerciseDropdown = new List<SelectListItem>();

            foreach (var item in excerciseTypes)
            {
                excerciseDropdown.Add(new SelectListItem { Text = item.ExcerciseName, Value = item.ExcerciseName });
            }

            var excerciseSearch = from l in excerciseTypes
                                  join t in excercise on l.Id equals t.ExcerciseTypeId into table1
                                  from t in table1
                                  select new ExcerciseSearchModel
                                  {
                                      ExcerciseId = t.Id,
                                      ExcerciseType = l.ExcerciseName,
                                      ExcerciseName = t.TypeName,
                                      StartDate = t.StartDate,
                                      EndDate = t.EndDate,
                                  };


            ExcerciseIndex exIndex = new ExcerciseIndex()
            {
                SearchModel = excerciseSearch.OrderBy(e => e.StartDate).ToList(),
                CurrentPage = page,
                itemPerPage = 3,

            };

            ViewData["ExcerciseTypes"] = excerciseDropdown;


            return View(exIndex);
        }

        [HttpPost]
        public async Task<ActionResult> Index(ExcerciseSearchModel excerciseSearchModel, int page = 1)
        {
            var excercise = await _context.Excercises.ToListAsync();
            var excerciseTypes = await _context.ExcerciseTypes.ToListAsync();
            var tempExcerciseType = new ExcerciseType();
            var exTypeChoice = excerciseSearchModel.ExcerciseChoice;
            var excerciseDropdown = new List<SelectListItem>();
            List<ExcerciseSearchModel> excerciseSearch = new List<ExcerciseSearchModel>();
            ExcerciseIndex exIndex = new ExcerciseIndex();

            foreach (var item in excerciseTypes)
            {
                excerciseDropdown.Add(new SelectListItem { Text = item.ExcerciseName, Value = item.ExcerciseName });
            }

            if (exTypeChoice == null || exTypeChoice == "All Locations")
            {

                var excerciseResults = from l in excerciseTypes
                                       join t in excercise on l.Id equals t.ExcerciseTypeId into table1
                                       from t in table1
                                       select new ExcerciseSearchModel
                                       {
                                           ExcerciseId = t.Id,
                                           ExcerciseType = l.ExcerciseName,
                                           ExcerciseName = t.TypeName,
                                           StartDate = t.StartDate,
                                           EndDate = t.EndDate,
                                       };


                exIndex = new ExcerciseIndex()
                {
                    SearchModel = excerciseResults.OrderBy(e => e.StartDate).ToList(),
                    CurrentPage = page,
                    itemPerPage = 3,
                };
            }
            else if (exTypeChoice != null && exTypeChoice != "All Locations")
            {
                tempExcerciseType = await _context.ExcerciseTypes.FirstOrDefaultAsync(e => e.ExcerciseName == excerciseSearchModel.ExcerciseChoice);

                excercise = excercise.Where(c => c.ExcerciseTypeId == tempExcerciseType.Id).ToList();

                var excerciseResults = from l in excerciseTypes
                                       join t in excercise on l.Id equals t.ExcerciseTypeId into table1
                                       from t in table1
                                       select new ExcerciseSearchModel
                                       {
                                           ExcerciseId = t.Id,
                                           ExcerciseType = l.ExcerciseName,
                                           ExcerciseName = t.TypeName,
                                           StartDate = t.StartDate,
                                           EndDate = t.EndDate,
                                       };


                exIndex = new ExcerciseIndex()
                {
                    SearchModel = excerciseResults.OrderBy(e => e.StartDate).ToList(),
                    CurrentPage = page,
                    itemPerPage = 3,
                };
            }

            ViewData["ExcerciseTypes"] = excerciseDropdown;


            return View(exIndex);


        }

        //Http GET
        public async Task<ActionResult> CreateExcercise()
        {
            var exTypeList = await _context.ExcerciseTypes.ToListAsync();

            var excerciseDropdown = new List<SelectListItem>();

            foreach (var item in exTypeList)
            {
                excerciseDropdown.Add(new SelectListItem { Text = item.ExcerciseName, Value = item.ExcerciseName });
            }

            AddExcerciseVm addEx = new AddExcerciseVm { TypeList = excerciseDropdown };

            addEx.StartDate = DateTime.Today;
            addEx.EndDate = DateTime.Today;

            return View(addEx);
        }

        [HttpPost]
        public async Task<ActionResult> CreateExcercise(AddExcerciseVm addVm)
        {
            string id = User.Identity.Name;

            if (ModelState.IsValid)
            {
                ExcerciseType typeChoice = await _context.ExcerciseTypes.FirstOrDefaultAsync(i => i.ExcerciseName == addVm.TypeChoice);

                Excercise excercise = new Excercise()
                {
                    TypeName = addVm.ExcerciseName,
                    StartDate = addVm.StartDate,
                    EndDate = addVm.EndDate,
                    ExcerciseTypeId = typeChoice.Id,

                };

                _context.Add(excercise);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: ExcerciseController/Details/5
        public async Task<ActionResult> Details(int id, string ViewBagMessage)
        {
            var excercise = await _context.Excercises.FirstOrDefaultAsync(i => i.Id == id);
            var excerciseType = await _context.ExcerciseTypes.FirstOrDefaultAsync(i => i.Id == excercise.ExcerciseTypeId);
            var excerciseNotes = new List<ExcerciseNote>();
            var excerciseLocations = new List<ExcerciseLocation>();
            var mous = new List<Mou>();
            List<Location> locList = new();
            List<SelectListItem> selectLocList = new List<SelectListItem>();
            List<SelectListItem> selectMouList = new List<SelectListItem>();

            //Getting all Exercise Support Documents from DB and transferring them to the document
            //DTO object for view
            List<SupportDocModels> newSupDocs = new();
            var supportDocs = await _context.SupportDocuments.Where(e => e.ExcerciseId == id).ToListAsync();
            if(supportDocs != null && supportDocs.Count > 0)
            {
                foreach (var item in supportDocs)
                {
                    newSupDocs.Add(new SupportDocModels(item));
                }

            }

            //Getting all Exercise Support Documents from DB and transferring them to the document
            //DTO object for view
            List<BreifDocModels> newBreifDocs = new();
            var excerciseBriefs = await _context.ExcerciseBriefs.Where(e => e.ExcerciseId == id).ToListAsync();
            if(excerciseBriefs != null && excerciseBriefs.Count > 0)
            {
                foreach (var item in excerciseBriefs)
                {
                    newBreifDocs.Add(new BreifDocModels(item));
                }
            }

            //Get calendar events & Location events from DB and transfer them to DTO event objects
            var calendarEvents = new List<SiteEventModel>();
            var siteEvents = await _context.LocationEvents.Where(b => b.ExerciseId == id).OrderBy(b => b.StartDate).ToListAsync();
            var exerciseEvents = await _context.ExerciseEvents.Where(e => e.ExerciseId == id).ToListAsync();
            if (siteEvents != null && siteEvents.Count > 0)
            {
                foreach (var item in siteEvents)
                {
                    if(item.ShowOnCalendar == true)
                    {
                        calendarEvents.Add(new SiteEventModel(item));
                    }
                }
            }
            if (exerciseEvents != null && exerciseEvents.Count > 0)
            {
                foreach(var item in exerciseEvents)
                {
                    if(item.ShowOnTimeline == true)
                    {
                        calendarEvents.Add(new SiteEventModel(item));
                    }
                }
            }

            //Getting All Exercise Notes from Database

            if (await _context.MouExcercises.FirstOrDefaultAsync(m => m.ExcerciseId == id) != null)
            {
                var mouExcercise = await _context.MouExcercises.Where(m => m.ExcerciseId == id).ToListAsync();

                foreach (var item in mouExcercise)
                {
                    mous.Add(await _context.Mous.FirstOrDefaultAsync(m => m.Id == item.MouId));
                }

                foreach (var item in mous)
                {
                    selectMouList.Add(new SelectListItem { Text = item.Title, Value = item.Id.ToString() });
                }
            }

            if (await _context.ExcerciseNotes.Where(b => b.ExcerciseId == id).ToListAsync() != null)
            {
                excerciseNotes = await _context.ExcerciseNotes.Where(b => b.ExcerciseId == id).ToListAsync();
            }

            validRange dates = new validRange()
            {
                end = excercise.StartDate.ToString(string.Format("yyyy-MM-dd")),
                start = excercise.EndDate.ToString(string.Format("yyyy-MM-dd")),

            };
            
            var exEvents = new List<ExerciseEvent>();
            var eventQuery = await _context.ExerciseEvents.Where(e => e.ExerciseId == id).ToListAsync();
            if(eventQuery != null && eventQuery.Count > 0)
            {

            }

            validRange[] arr = new validRange[] { dates };

            var detailsVm = new ExcerciseDetailsVm
            {
                Excercise = excercise,
                Notes = excerciseNotes,
                Briefs = newBreifDocs,
                Docs = newSupDocs,
                ExcerciseType = excerciseType.ExcerciseName,
                Mous = mous,
                ExEndDate = excercise.EndDate.ToString(string.Format("yyyy-MM-dd")),
                ExStartDate = excercise.StartDate.ToString(string.Format("yyyy-MM-dd")),
                validRange = Json(arr),
                EventModel = calendarEvents,
                LocationEvents = siteEvents,
                EventList = exerciseEvents.OrderBy(e => e.StartTime).ToList(),
                ShowOnTimeline = true,
                ShowOnCalendar = false,
                EventStartTime = DateTime.Today,
                EventEndTime = DateTime.Today,
                
            };

            if (ViewBagMessage != null)
            {
                ViewBag.Alert = AlertService.ShowAlert(Enums.Alerts.Info, ViewBagMessage);
                ViewBagMessage = null;
            }
            ViewData["ExStartDate"] = excercise.StartDate.ToString(string.Format("yyyy-MM-dd"));
            ViewData["ExEndDate"] = excercise.StartDate.ToString(string.Format("yyyy-MM-dd"));
            ViewData["ExcerciseId"] = excercise.Id;
            ViewData["SelectLocations"] = selectLocList;
            ViewData["SelectMous"] = new SelectList(_context.Mous, "Id", "Title");

            return View(detailsVm);
        }

        [HttpPost]
        public async Task<ActionResult> DownloadSupportDoc(int id, SupportDocModels supModel)
        {
            var supDocs = await _context.SupportDocuments.FirstOrDefaultAsync(m => m.Id == supModel.Id);

            if (supDocs == null)
            {
                return NotFound();
            }
            else
            {
                byte[] byteArray = supDocs.FileData;
                string mimeType = "application/pdf";
                return new FileContentResult(byteArray, mimeType)
                {
                    FileDownloadName = $"{supModel.FileName}.pdf",

                };

            }

        }

        public FileContentResult ShowSupportFile(int id)
        {
            var supDocs = _context.SupportDocuments.FirstOrDefault(m => m.Id == id);

            string contentType = "application/pdf";

            return new FileContentResult(supDocs.FileData, contentType);

        }

        public FileContentResult ShowBreifFile(int id)
        {
            var breifDocs = _context.ExcerciseBriefs.FirstOrDefault(m => m.Id == id);

            string contentType = "application/pdf";

            return new FileContentResult(breifDocs.FileData, contentType);

        }

        [HttpPost]
        public async Task<ActionResult> UploadSupDoc(ExcerciseDetailsVm detailsVm, int id)
        {
            SupportDocument supDoc = new SupportDocument();

            supDoc.FileName = detailsVm.FileName;
            supDoc.DateStamp = DateTime.Now;
            supDoc.ExcerciseId = id;
            supDoc.FileType = ".pdf";

            if (detailsVm.file != null)
            {

                using (var target = new MemoryStream())
                {
                    detailsVm.file.CopyTo(target);
                    supDoc.FileData = target.ToArray();
                }
            }

            _context.SupportDocuments.Add(supDoc);
            await _context.SaveChangesAsync();

            string message = $"Support Document '{supDoc.FileName}' was Successfully Added";


            return RedirectToAction(nameof(Details), new { id = id, viewbagMessage = message });
        }

        [HttpPost]
        public async Task<ActionResult> UploadBrief(ExcerciseDetailsVm detailsVm, int id)
        {
            ExcerciseBrief supDoc = new ExcerciseBrief();

            supDoc.FileTitle = detailsVm.FileName;
            supDoc.DateStamp = DateTime.Now;
            supDoc.ExcerciseId = id;
            supDoc.FileType = ".pdf";

            if (detailsVm.file != null)
            {

                using (var target = new MemoryStream())
                {
                    detailsVm.file.CopyTo(target);
                    supDoc.FileData = target.ToArray();
                }
            }

            _context.ExcerciseBriefs.Add(supDoc);
            await _context.SaveChangesAsync();

            string message = $"Brief '{supDoc.FileTitle}' was Successfully Added";

            return RedirectToAction(nameof(Details), new { id = id });
        }


        // POST: ExcerciseController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateNote(ExcerciseDetailsVm exDetailsVm, int id)
        {
            ExcerciseNote exNote = new ExcerciseNote();

            if (exDetailsVm.NoteSubject != null && exDetailsVm.NoteBody != null)
            {
                exNote.Subject = exDetailsVm.NoteSubject;
                exNote.Body = exDetailsVm.NoteBody;
                exNote.DateStamp = DateTime.Now;
                exNote.ExcerciseId = id;
            }

            await _context.ExcerciseNotes.AddAsync(exNote);
            await _context.SaveChangesAsync();

            return RedirectToAction("Details", new { id });

        }

        [HttpPost]
        public async Task<ActionResult> AddLocation(ExcerciseDetailsVm addLoc, int id)
        {
            if (addLoc.LocationChoice != null)
            {
                var Location = await _context.Locations.FirstOrDefaultAsync(l => l.Name == addLoc.LocationChoice);

                var ExcerciseLocation = await _context.ExcerciseLocations.Where(e => e.ExcerciseId == id).ToListAsync();

                if (ExcerciseLocation.Find(e => e.LocationId == Location.Id) != null)
                {
                    addLoc.AlertMessage = "This Location is Already Added";
                }
                else
                {
                    ExcerciseLocation exLoc = new ExcerciseLocation()
                    {
                        ExcerciseId = id,
                        LocationId = Location.Id,
                    };
                    _context.Add(exLoc);
                    await _context.SaveChangesAsync();
                }

            }


            return RedirectToAction("Details", new { id = id });
        }

        [HttpPost]
        public async Task<ActionResult> AddMou(ExcerciseDetailsVm addDet, int id)
        {
            string message = null;
            try
            {
                if(await _context.MouExcercises.FirstOrDefaultAsync(e => e.MouId == addDet.MouId) == null && addDet.MouChoice == 2 && addDet.MouId != 0)
                {
                    var newMouExc = new MouExcercise { MouId = addDet.MouId, ExcerciseId = id };

                    await _context.AddAsync(newMouExc);
                    await _context.SaveChangesAsync();
                }
                else if (addDet.MouChoice == 1)
                {
                    var newMou = new Mou
                    {
                        Title = addDet.Title,
                        StartDate = addDet.StartDate,
                        EndDate = addDet.EndDate,
                        FirstName = addDet.FirstName,
                        lastName = addDet.lastName,
                        Email = addDet.Email,
                        PhoneNumber = addDet.PhoneNumber,
                    };

                    using (var target = new MemoryStream())
                    {
                        addDet.MouFile.CopyTo(target);
                        newMou.MouFile = target.ToArray();
                        await _context.AddAsync(newMou);
                        await _context.SaveChangesAsync();
                    }

                    var addedMouExc = await _context.Mous.Where(m => m.Title == addDet.Title).FirstOrDefaultAsync();
                    var newMouExc = new MouExcercise { MouId = addedMouExc.Id, ExcerciseId = id };
                    await _context.AddAsync(newMouExc);
                    await _context.SaveChangesAsync();
                }
            }
            catch
            {
                message = "Error: Unable to add MOU";
            }


            return RedirectToAction("Details", new { id = id, viewbagMessage = message });
        }

        public async Task<ActionResult> RemoveMou(int id)
        {
            var mou = new MouExcercise();
            string message = null;
            try
            {
                mou = await _context.MouExcercises.FirstOrDefaultAsync(m => m.MouId == id);
                if(mou != null)
                {
                    _context.Remove(mou);
                    await _context.SaveChangesAsync();
                }
            }
            catch
            {
                message = "Error: Unable to remove MOU";
            }

            return RedirectToAction("Details", new { id = mou.ExcerciseId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> UpdateLocation(int id)
        {
            var exLocation = await _context.ExcerciseLocations.FindAsync(id);
            _context.ExcerciseLocations.Remove(exLocation);
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", new { id = id });
        }

        public async Task<ActionResult> DeleteBrief(int id)
        {
            string message = null;
            var brief = await _context.ExcerciseBriefs.FirstOrDefaultAsync(b => b.Id == id);
            if (brief != null)
            {
                message = $"Brief '{brief.FileTitle}' was deleted";
            }
            _context.Remove(brief);
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", new { id = brief.ExcerciseId, viewbagMessage = message });
        }

        public async Task<ActionResult> DeleteSupportDoc(int id)
        {
            string message = null;
            var doc = await _context.SupportDocuments.FirstOrDefaultAsync(b => b.Id == id);
            if (doc != null)
            {
                message = $"Support Document '{doc.FileName}' was deleted";
            }
            _context.Remove(doc);
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", new { id = doc.ExcerciseId, viewbagMessage = message });
        }

        //public async Task<ActionResult<IEnumerable<SiteEventModel>>> GetCalendarEvents(int id)
        //{
        //    var eventModel = new SiteEventModel();
        //    var EventList = new List<SiteEventModel>();
        //    var sdate = DateTime.Today;
        //    var edate = DateTime.Today.AddDays(7);

        //    for (int i = 0; i < 3; i++)
        //    {
        //        EventList.Add(new SiteEventModel()
        //        {
        //            Id = i,
        //            Start = sdate,
        //            End = edate,
        //            Text = "Location Name",
        //           Color = "red"
        //       });
        //        sdate = sdate.AddDays(7);
        //        edate = edate.AddDays(7);
        //    }

        //    var calendarEvents = new List<SiteEventModel>();
        //    var siteEvents = new List<LocationEvent>();

        //    if (await _context.LocationEvents.Where(b => b.ExerciseId == id).ToListAsync() != null)
        //    {
        //        siteEvents = await _context.LocationEvents.Where(b => b.ExerciseId == id).ToListAsync();

        //        foreach (var item in siteEvents)
        //        {
        //            calendarEvents.Add(new SiteEventModel() { Id = item.Id, Text = $"{item.FieldName} - {item.FieldType}", Start = item.StartDate, End = item.EndDate, Color = "blue" });
        //        };
        //    }

        //    //return EventList;
        //    return calendarEvents;
        //}

        [HttpPost]
        public async Task<ActionResult> EventStep1(SiteSearchVm dashVm)
        {

            var location = await _context.Locations.ToListAsync();
            var locFields = await _context.SiteFields.ToListAsync();
            var searchModel = new List<SearchModel>();

            if (dashVm.stateSearch != null && dashVm.stateSearch != "Select State")
            {
                location = location.Where(l => l.State == dashVm.stateSearch).ToList();

                if (dashVm.citySearch != null && dashVm.citySearch != "Select City")
                {
                    location = location.Where(l => l.City == dashVm.citySearch).ToList();
                }
            }

            if (dashVm.FieldChoice != null && dashVm.FieldChoice != "Choose...")
            {
                locFields = locFields.Where(l => l.Field == dashVm.FieldChoice).ToList();

                if (dashVm.TypeChoice != null && dashVm.TypeChoice != "Choose...")
                {
                    locFields = locFields.Where(l => l.Type == dashVm.TypeChoice).ToList();
                }

                foreach (var item in locFields)
                {
                    if (location.Where(l => l.Id == item.LocationId) != null)
                    {
                        location = location.Where(l => l.Id == item.LocationId).ToList();
                    }
                }

                if (location == null)
                {
                    ViewBag.Alert = AlertService.ShowAlert(Enums.Alerts.Info, "No Results Found");
                }
            }

            foreach (var item in location)
            {
                searchModel.Add(new SearchModel
                {
                    Location = item,
                    SiteFields = locFields.Where(f => f.LocationId == item.Id).ToList()
                });
            }

            SiteSearchVm dashVM = new SiteSearchVm()
            {
                citySearch = dashVm.citySearch,
                stateSearch = dashVm.stateSearch,
                FieldChoice = dashVm.FieldChoice,
                TypeChoice = dashVm.TypeChoice,
                itemPerPage = 5,
                SearchModel = searchModel,
                CurrentPage = 1
            };

            ViewData["City"] = searchLogic.GetStateCity().Select(s => new SelectListItem { Value = s.Id, Text = s.State }).ToList();

            return View(dashVM);
        }

        public async Task<ActionResult> EventStep1(
                                                string stateSearch,
                                                string citySearch,
                                                string FieldChoice,
                                                string TypeChoice,
                                                int excerciseId,
                                                string[] selectedNames,
                                                int page = 1)
        {

            var location = await _context.Locations.ToListAsync();
            var locFields = await _context.SiteFields.ToListAsync();
            var searchModel = new List<SearchModel>();

            if (stateSearch != null && stateSearch != "Select State")
            {
                location = location.Where(l => l.State == stateSearch).ToList();

                if (citySearch != null && citySearch != "Select City")
                {
                    location = location.Where(l => l.City == citySearch).ToList();
                }
            }

            if (FieldChoice != null && FieldChoice != "Choose...")
            {
                locFields = locFields.Where(l => l.Field == FieldChoice).ToList();

                if (TypeChoice != null && TypeChoice != "Choose...")
                {
                    locFields = locFields.Where(l => l.Type == TypeChoice).ToList();
                }

                foreach (var item in locFields)
                {
                    location = location.Where(l => l.Id == item.LocationId).ToList();
                }

                if (locFields == null)
                {
                    ViewBag.Alert = AlertService.ShowAlert(Enums.Alerts.Info, "No Results Found");
                }
            }

            foreach (var item in location)
            {
                searchModel.Add(new SearchModel
                {
                    Location = item,
                    SiteFields = locFields.Where(f => f.LocationId == item.Id).ToList()
                });
            }

            EventStep1 dashVm = new EventStep1()
            {
                citySearch = citySearch,
                stateSearch = stateSearch,
                FieldChoice = FieldChoice,
                TypeChoice = TypeChoice,
                itemPerPage = 10,
                SearchModel = searchModel,
                CurrentPage = page,
                ExcerciseId = excerciseId,
                SelectedNames = selectedNames
                
            };

            dashVm.SearchModel = searchModel;
            ViewData["City"] = searchLogic.GetStateCity().Select(s => new SelectListItem { Value = s.Id, Text = s.State }).ToList();

            return View(dashVm);
        }

        public IActionResult GetSiteFields(string cid)
        {
            if (cid == null)
            {
                string message = "asdf";
                return Json(message);
            }
            var loc = _context.Locations.FirstOrDefault(l => l.Name == cid);
            var fields = _context.SiteFields.Where(f => f.LocationId == loc.Id)
                                            .Select(f => new { Id = f.Id, Name = f.Name })
                                            .ToList();

            return Json(fields);
        }
        public async Task<ActionResult> Suggest()
        {
            string term = HttpContext.Request.Query["term"].ToString();
            var names = await _context.Locations.Where(l => l.Name.Contains(term)).Select(l => l.Name).ToListAsync();
            return Ok(names);
        }

        public async Task<ActionResult> AddLocationEvent(ExcerciseDetailsVm exVm, int id)
        {
            var field = await _context.SiteFields.FirstOrDefaultAsync(l => l.Id == exVm.FieldResult);

            var events = new LocationEvent()
            {
                LocationId = field.LocationId,
                ExerciseId = id,
                EventName = exVm.LocationEventName,
                LocationName = exVm.locationName,
                FieldName = field.Name,
                FieldType = field.Type,
                Description = exVm.FieldDescription,
                StartDate = exVm.EventStartDate,
                EndDate = exVm.EventEndDate
            };

            _context.Add(events);
            await _context.SaveChangesAsync();

            return RedirectToAction("Details", new { id = id });
        }

        public async Task<ActionResult> AddExerciseEvent(ExcerciseDetailsVm exVm, int id)
        {
            var ex = await _context.Excercises.FirstOrDefaultAsync(e => e.Id == id);
            var exEvents = await _context.ExerciseEvents.Where(e => e.ExerciseId == id).ToListAsync();
            string errorMessage = null;
            if(exVm.EventStartDate > ex.StartDate && exVm.EventStartDate < ex.EndDate && exVm.EventEndDate > exVm.EventStartDate && exVm.EventEndDate < ex.EndDate)
            {

                    var events = new ExerciseEvent()
                    {
                        EventName = exVm.EventName,
                        EventDescription = exVm.EventDescription,
                        StartTime = exVm.EventStartDate,
                        EndTime = exVm.EventEndDate,
                        ShowOnCalendar = exVm.ShowEvent,
                        ShowOnTimeline = exVm.ShowOnTimeline,
                        ExerciseId = id
                    };

                    _context.Add(events);
                    await _context.SaveChangesAsync();
                    errorMessage = "Event successfully Added";

            }
            else
            {
                errorMessage = "Error: Event dates were not within exercise time frame";
            }
            

            return RedirectToAction(nameof(Details), new { id = id, viewbagMessage = errorMessage });

        }

        public async Task<ActionResult> DeleteExerciseEvent(int id)
        {
            var exEvent = new ExerciseEvent();
            string message = null;
              try
              {
                    exEvent = await _context.ExerciseEvents.FirstOrDefaultAsync(e => e.Id == id);
                    if(exEvent != null)
                    {
                        _context.Remove(exEvent);
                        await _context.SaveChangesAsync();
                        message = "Event successfully deleted";
                    }
              }
              catch
              {
                    message = "Error deleteing this event";
              }
            
            return RedirectToAction("Details", new { id = exEvent.ExerciseId, viewbagMessage = message });

        }

        public async Task<ActionResult> UpdateExerciseEvent(ExcerciseDetailsVm exVm, int id)
        {
            string message = null;
            var exEvent = await _context.ExerciseEvents.FirstOrDefaultAsync(e => e.Id == exVm.ExerciseEventId);
            if(exEvent != null)
            {
                try
                {
                    exEvent.EventName = exVm.EventName;
                    exEvent.EventDescription = exVm.EventDescription;
                    exEvent.StartTime = exVm.EventStartTime;
                    exEvent.EndTime = exVm.EventEndTime;
                    exEvent.ShowOnCalendar = exVm.ShowEvent;

                    _context.Update(exEvent);
                    await _context.SaveChangesAsync();
                    message = $"Event {exVm.EventName} Updated";
                }
                catch
                {
                    message = $"Failed Updating Event {exVm.EventName}";
                }
            }

            return RedirectToAction("Details", new { id = exEvent.ExerciseId, viewbagMessage = message });

        }
        // GET: ExcerciseController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ExcerciseController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ExcerciseController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ExcerciseController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
