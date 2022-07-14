using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
//using RavenSiteSurvey.Data;
using RavenSiteSurvey.Models;
using RavenSiteSurvey.Models.VIewModels;
using GeoJSON.Net;
using GeoJSON.Net.Geometry;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FullCalendar;
using FullCalendar.Abstract;
using SocomTrainingPlatform.Models;
using RavenSiteSurvey.Repositories;
using Microsoft.AspNetCore.Http;
using RavenSiteSurvey.BuisnessLogic;
using SocomTrainingPlatform.Models.DashboardModels.DashboardViewModels;
using SocomTrainingPlatform.Models.SiteModels;
using System.IO;
using SocomTrainingPlatform.Services;

namespace SocomTrainingPlatform.Controllers
{
    public class SiteController : Controller
    {
        private readonly SocomTrainingPlatformContext _context;
        private readonly LocRepo locRepo;
        private readonly SiteLogic dashLogic;
        //private readonly AddFieldsRepo addFields;


        public SiteController(SocomTrainingPlatformContext context)
        {
            _context = context;
            locRepo = new LocRepo(context);
            //addFields = new AddFieldsRepo(context);
            dashLogic = new SiteLogic(context);
        }


        // GET: Dashboard
        public ActionResult Index()
        {
            //DashboardVm dashVm = new();
            //dashVm.FilterModel = dashLogic.GetAllSites();

            // Instantiates the static filter values for the search menu
            FilterOption filterOptions = new FilterOption();

            //Instatiate a new View Model from DB W/ JOIN statement linking all FK relationships
            //IEnumerable<DashboardVm> locVm = dashLogic.PopulateVM();
            DashboardVm dash = new();
            dash.FinalFilterModel = dashLogic.GetAllSites();

            //Creating a List of all locations to filter unique city and states
            List<Location> Location = _context.Locations.ToList();
            var myCondition = true;

            //Getting the Unique State & City in a List of Strings
            var distinctCity = new List<string>(Location.Select(l => l.City).Distinct());
            var distinctState = new List<string>(Location.Select(l => l.State).Distinct());

            //Using Unique City & State to create a SelectList for the filter
            var citySearch = new List<SelectListItem>();
            foreach (var item in distinctCity)
            {
                citySearch.Add(new SelectListItem { Text = item, Value = item });
            };

            var stateSearch = new List<SelectListItem>();
            foreach (var item in distinctState)
            {
                stateSearch.Add(new SelectListItem { Text = item, Value = item });
            };

             
            //setting filter drop down fields W/ Filter Option values and Unique City/State
            ViewData["City"] = citySearch;
            ViewData["State"] = stateSearch;
            ViewData["Target"] = filterOptions.targetFields;
            ViewData["InsertPoint"] = filterOptions.insertPointFields;
            ViewData["TrainingArea"] = filterOptions.trainingTypeFields;
            ViewData["Support"] = filterOptions.supportField;
            ViewData["BerthingWork"] = filterOptions.berthingWorkField;
            ViewData["Meeting"] = filterOptions.meeting;
            ViewData["Condition"] = myCondition;

            return View(dash);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(DashboardVm locationVm)
        {
            DashboardVm dashVm = new();
            dashVm.FinalFilterModel = dashLogic.GetAllSites(locationVm);


            //Model for SelectListItem fiedls with {value} and {text} to populate filter boxes
            FilterOption filterOptions = new FilterOption();
            string noResultMessage;

            List<Location> Location = _context.Locations.ToList();
            List<PointOfContact> Poc = _context.PointOfContacts.ToList();

            //Gets the distinct city and states from all DB records for filter box
            var distinctCity = new List<string>(Location.Select(l => l.City).Distinct());
            var distinctState = new List<string>(Location.Select(l => l.State).Distinct());

            //Seperates the distinct cities and states into SelectedListItems for filter options
            var stateSearch = new List<SelectListItem>();
            foreach (var item in distinctState)
            {
                stateSearch.Add(new SelectListItem { Text = item, Value = item });
            };
            var citySearch = new List<SelectListItem>();
            foreach (var item in distinctCity)
            {
                citySearch.Add(new SelectListItem { Text = item, Value = item });
            };

            //If PopulatVM with filter choice has no result, Assign the all records default
            DashboardVm newLocVM = new DashboardVm();
            if (dashVm.FinalFilterModel.FirstOrDefault() == null)
            {
                dashVm.FinalFilterModel = dashLogic.GetAllSites();

                ViewBag.Alert = AlertService.ShowAlert(Enums.Alerts.Info, "No Results Found");

            };
            //POC Info if needded
            //var distinctPocName = new SelectList(Poc.Select(p => p.FirstName).Distinct());
            //var disPoc = new SelectList((from l in Poc group l by new { l.FirstName, l.LastName } into mygroup select mygroup.FirstOrDefault()).Distinct());

            //Adding Filter Fields to the ViewData
            ViewData["City"] = citySearch;
            ViewData["State"] = stateSearch;
            ViewData["Target"] = filterOptions.targetFields;
            ViewData["InsertPoint"] = filterOptions.insertPointFields;
            ViewData["TrainingArea"] = filterOptions.trainingTypeFields;
            ViewData["Support"] = filterOptions.supportField;
            ViewData["BerthingWork"] = filterOptions.berthingWorkField;
            ViewData["Meeting"] = filterOptions.meeting;

            return View(dashVm);

        }

        public async Task<IActionResult> Details(int id)
        {

            Location location = await _context.Locations.FirstOrDefaultAsync(m => m.Id == id);
            List<TargetModel> Target = dashLogic.GetTarget(id);
            List<InsertModel> insertPoints = dashLogic.GetInsertPoint(id);
            List<SupportModel> support = dashLogic.GetSupport(id);
            List<BerthingModel> berthingWorks = dashLogic.GetBerthing(id);
            List<MeetingModel> Meeting = dashLogic.GetMeeting(id);
            List<ExcerciseLocation> exLoc = await _context.ExcerciseLocations.Where(e => e.LocationId == id).ToListAsync();
            PocLocation pocLoc = new PocLocation();
            PointOfContact newPoc = new PointOfContact();
            List<LocationNote> noteList = new List<LocationNote>();
            List<Excercise> exList = new List<Excercise>();
            Mou mou = new Mou();
            List<SelectListItem> targetChoices = new();
            List<PointOfContact> pocList = await _context.PointOfContacts.ToListAsync();
            List<Mou> mouList = await _context.Mous.ToListAsync();


            foreach(var item in Target)
            {
                //SelectListItem target = new { Text = item.Target.Name, Value = item.Target.Id};
            }

            foreach (var item in exLoc)
            {
                exList.Add(await _context.Excercises.FirstOrDefaultAsync(e => e.Id == item.ExcerciseId));
            }

            if (await _context.Mous.FirstOrDefaultAsync(m => m.Id == location.MouId) != null)
            {
                mou = await _context.Mous.FirstOrDefaultAsync(m => m.Id == location.MouId);
            }

            if (await _context.LocationNotes.Where(N => N.LocationId == id).ToListAsync() != null)
            {
                noteList = await _context.LocationNotes.Where(N => N.LocationId == id).ToListAsync();
            }

            if (await _context.PocLocations.FirstOrDefaultAsync(P => P.LocationId == id) != null)
            {
                pocLoc = await _context.PocLocations.FirstOrDefaultAsync(P => P.LocationId == id);
                newPoc = await _context.PointOfContacts.FirstOrDefaultAsync(P => P.Id == pocLoc.PocId);
            }

            if (location == null)
            {
                return NotFound();
            }

            List<SelectListItem> pocSelect = new();

            foreach(var item in pocList)
            {
                pocSelect.Add(new SelectListItem { Text = item.FirstName + " " + item.LastName, Value = item.Id.ToString() });
            }


            string address = location.StreetAddress;
            string city = location.City;
            string state = location.State;
            string zip = location.ZipCode;
            double Lat = location.Latitude.GetValueOrDefault();
            double Lon = location.Longitude.GetValueOrDefault();

            var viewLocations = new DetailsVm
            {
                location = location,
                target = Target,
                insertPoint = insertPoints,
                support = support,
                berthingWork = berthingWorks,
                meeting = Meeting,
                poc = newPoc,
                note = noteList,
                Excercises = exList,
                mou = mou,
                MouList = mouList,
            };


            ViewData["PocId"] = pocSelect;
            ViewData["MouId"] = new SelectList(_context.Mous, "Id", "Title");
            ViewData["Lat"] = Lat;
            ViewData["Long"] = Lon;
            ViewData["FullAddress"] = address + ", " + city + ", " + state + " " + zip;

            return View(viewLocations);
        }

        [HttpPost]
        public async Task<IActionResult> AddField(DetailsVm detailsVm, int id)
        {
            dashLogic.AddFields(detailsVm, id);

            if(dashLogic != null)
            {
                ViewBag.Alert = AlertService.ShowAlert(Enums.Alerts.Success, "Field Successfully Added!");
            }

            return RedirectToAction("Details", new { id = id });
        }

        [HttpPost]
        public async Task<IActionResult> AddContact(DetailsVm detailsVm, int id)
        {

            if (detailsVm.pocChoice == 1)
            {
                var pointOfContact = new PointOfContact()
                {
                    FirstName = detailsVm.FirstName,
                    LastName = detailsVm.LastName,
                    EmailAddress = detailsVm.EmailAddress,
                    PhoneNumber = detailsVm.PhoneNumber,
                };
                _context.Add(pointOfContact);
                await _context.SaveChangesAsync();

                var contact = await _context.PointOfContacts.FirstOrDefaultAsync(p => p.PhoneNumber == detailsVm.PhoneNumber);
                //if(await _context.PocLocations.FirstOrDefaultAsync(p => p.PocId == contact.Id) != null)
                //{

                //}
                var pocLo = new PocLocation()
                {
                    PocId = contact.Id,
                    LocationId = id,
                };
                _context.Add(pocLo);

            }
            else if(detailsVm.pocChoice == 2)
            {
                var pocLo = new PocLocation()
                {
                    PocId = detailsVm.PocId,
                    LocationId = id,
                };
                _context.Add(pocLo);
            }

            await _context.SaveChangesAsync();

            return RedirectToAction("Details", new { id = id });
        }

        [HttpPost]
        public async Task<IActionResult> AddNote(DetailsVm detailsVm, int id)
        {
            LocationNote locNote = new LocationNote();

            if (detailsVm.NoteSubject != null && detailsVm.locNote != null)
            {
                locNote.Subject = detailsVm.NoteSubject;
                locNote.Body = detailsVm.locNote;
                locNote.Date = DateTime.Now;
                locNote.LocationId = id;
            }

            await _context.LocationNotes.AddAsync(locNote);
            await _context.SaveChangesAsync();

            return RedirectToAction("Details", new { id });
        }

        [HttpPost]
        public async Task<IActionResult> AddImage(DetailsVm detailsVm, int id)
        {
            TargetImage tImage = new();
            BerthingImage bImage = new();
            SupportImage sImage = new();
            MeetingImage mImage = new();
            InsertImage iImage = new();

                using (var ms = new MemoryStream())
                {
                    detailsVm.ImageData.CopyTo(ms);

                    if(detailsVm.ImageField == "target")
                    {
                        tImage.Description = detailsVm.ImageDescription;
                        tImage.TargetId = detailsVm.FieldId;
                        tImage.ImageFile = ms.ToArray();

                        _context.Add(tImage);
                    }
                    if (detailsVm.ImageField == "Insert")
                    {
                        iImage.Description = detailsVm.ImageDescription;
                        iImage.InsertPointId = detailsVm.FieldId;
                        iImage.Image = ms.ToArray();

                        _context.Add(iImage);
                    }
                    if (detailsVm.ImageField == "Berthing")
                    {
                        bImage.Description = detailsVm.ImageDescription;
                        bImage.BerthingWorkId = detailsVm.FieldId;
                        bImage.ImageFile = ms.ToArray();

                        _context.Add(bImage);
                    }
                    if (detailsVm.ImageField == "Support")
                    {
                        sImage.Description = detailsVm.ImageDescription;
                        sImage.SupportId = detailsVm.FieldId;
                        sImage.Image = ms.ToArray();

                        _context.Add(sImage);
                    }
                    if(detailsVm.ImageField == "Meeting")
                    {
                         mImage.Description = detailsVm.ImageDescription;
                         mImage.MeetingId = detailsVm.FieldId;
                         mImage.ImageFile = ms.ToArray();

                         _context.Add(mImage);
                    }
                }

            await _context.SaveChangesAsync();

            return RedirectToAction("Details", new { id = id });
        }

        [HttpPost]
        public async Task<IActionResult> AddMou(DetailsVm detailsVm, int id)
        {
            Location location = _context.Locations.FirstOrDefault(l => l.Id == id);

            if(detailsVm.MouId > 0)
            {
                location.MouId = detailsVm.MouId;
                _context.Update(location);
                await _context.SaveChangesAsync();
            };

            return RedirectToAction("Details", new { id = id });
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AddSiteVm locationViewModel)
        {
            Location location = new();

            if (ModelState.IsValid)
            {
                location.Name = locationViewModel.Name;
                location.StreetAddress = locationViewModel.StreetAddress;
                location.City = locationViewModel.City;
                location.State = locationViewModel.State;
                location.ZipCode = locationViewModel.ZipCode;
                location.Latitude = locationViewModel.Latitude;
                location.Longitude = locationViewModel.Longitude;

                _context.Add(location);

            };

           await _context.SaveChangesAsync();

            return Redirect(nameof(Index));
        }


        //// GET: Dashboard/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: Dashboard/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Dashboard/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Dashboard/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: Dashboard/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Dashboard/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: Dashboard/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
