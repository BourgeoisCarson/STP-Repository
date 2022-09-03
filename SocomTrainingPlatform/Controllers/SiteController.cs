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
using Microsoft.AspNetCore.Http;
using SocomTrainingPlatform.Models.DashboardModels.DashboardViewModels;
using SocomTrainingPlatform.Models.SiteModels;
using System.IO;
using SocomTrainingPlatform.Services;
using SocomTrainingPlatform.BuisnessLogic;
using Azure.Search.Documents;
using Azure.Search.Documents.Indexes;
using Microsoft.Extensions.Configuration;
using Azure;
using Microsoft.AspNetCore.Html;
using System.Text;

namespace SocomTrainingPlatform.Controllers
{
    public class SiteController : Controller
    {
        private readonly SocomTrainingPlatformContext _context;
        private readonly SiteSearchLogic searchLogic;

        //private readonly AddFieldsRepo addFields;


        public SiteController(SocomTrainingPlatformContext context)
        {
            _context = context;
            searchLogic = new SiteSearchLogic(context);
        }


        public async Task<IActionResult> Details(int id)
        {

            Location location = await _context.Locations.FirstOrDefaultAsync(m => m.Id == id);
            List<SiteField> siteFields = await _context.SiteFields.Where(f => f.LocationId == id).ToListAsync();
            List<ExcerciseLocation> exLoc = await _context.ExcerciseLocations.Where(e => e.LocationId == id).ToListAsync();
            PocLocation pocLoc = new PocLocation();
            PointOfContact newPoc = new PointOfContact();
            List<LocationNote> noteList = new List<LocationNote>();
            List<Excercise> exList = new List<Excercise>();
            Mou mou = new Mou();
            List<SelectListItem> targetChoices = new();
            List<PointOfContact> pocList = await _context.PointOfContacts.ToListAsync();
            List<Mou> mouList = await _context.Mous.ToListAsync();


            List<FieldImageModel> fieldsImages = new();

            foreach (var item in siteFields)
            {
                List<FieldImage> image = new();
                if (await _context.FieldImages.FirstOrDefaultAsync(i => i.FieldId == item.Id) != null)
                {
                    image = await _context.FieldImages.Where(i => i.FieldId == item.Id).ToListAsync();
                }

                FieldImageModel newModel = new() { Field = item, Images = image };
                fieldsImages.Add(newModel);
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

            foreach (var item in pocList)
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
                SiteFields = fieldsImages,
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

                var pocLo = new PocLocation()
                {
                    PocId = contact.Id,
                    LocationId = id,
                };
                _context.Add(pocLo);

            }
            else if (detailsVm.pocChoice == 2)
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

        public async Task<ActionResult> RemovePoc(int id)
        {
            var location = await _context.Locations.FirstOrDefaultAsync(l => l.Id == id);
            var pocLocation = await _context.PocLocations.FirstOrDefaultAsync(f => f.LocationId == location.Id);

            _context.Remove(pocLocation);
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
            FieldImage fieldImage = new();

            using (var ms = new MemoryStream())
            {
                detailsVm.ImageData.CopyTo(ms);
                if (detailsVm.ImageField != null)
                {
                    fieldImage.Image = ms.ToArray();
                    fieldImage.Description = detailsVm.ImageDescription;
                    fieldImage.FieldId = detailsVm.FieldId;

                    _context.Add(fieldImage);
                }
            }
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", new { id = id });
        }

        [HttpPost]
        public async Task<IActionResult> AddMou(DetailsVm detailsVm, int id)
        {
            Location location = _context.Locations.FirstOrDefault(l => l.Id == id);

            if (detailsVm.MouId > 0)
            {
                location.MouId = detailsVm.MouId;
                _context.Update(location);
                await _context.SaveChangesAsync();
            };

            return RedirectToAction("Details", new { id = id });
        }

        public async Task<IActionResult> RemoveMou(int id)
        {
            var location = await _context.Locations.FirstOrDefaultAsync(l => l.Id == id);

            location.MouId = null;

            _context.Locations.Update(location);
            await _context.SaveChangesAsync();

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

            return RedirectToAction("Search");
        }

        [HttpPost]
        public async Task<ActionResult> Search(SiteSearchVm dashVm)
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
                itemPerPage = 10,
                SearchModel = searchModel,
                CurrentPage = 1
            };

            ViewData["City"] = searchLogic.GetStateCity().Select(s => new SelectListItem { Value = s.Id, Text = s.State }).ToList();

            return View(dashVM);
        }

        public async Task<ActionResult> Search( 
                                                string stateSearch,
                                                string citySearch,
                                                string FieldChoice,
                                                string TypeChoice,
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
                searchModel.Add(new SearchModel { Location = item,
                    SiteFields = locFields.Where(f => f.LocationId == item.Id).ToList() });
            }

            var dashVm = new SiteSearchVm()
            {
                citySearch = citySearch,
                stateSearch = stateSearch,
                FieldChoice = FieldChoice,
                TypeChoice = TypeChoice,
                itemPerPage = 10,
                SearchModel = searchModel,
                CurrentPage = page
            };

            dashVm.SearchModel = searchModel;
            ViewData["City"] = searchLogic.GetStateCity().Select(s => new SelectListItem { Value = s.Id, Text = s.State }).ToList();

            return View(dashVm);
        }

        public IActionResult GetCitys(string cid)
        {
            if (cid == null)
            {
                string message = "asdf";
                return Json(message);
            }

            var citys = searchLogic.GetStateCity()
                                    .Where(c => c.Id == cid)
                                    .FirstOrDefault().Citys
                                    .OrderBy(c => c.Id)
                                    .Select(c => new { Id = c.Id, Name = c.City }).ToList();

            return Json(citys);
        }

        public async Task<ActionResult> AddSiteField(DetailsVm detailsVm, int id)
        {
            string field = detailsVm.FieldChoice;
            string type = detailsVm.TypeChoice;


            if (field != null && field != "Choose..." && type != null && type != "Choose...")
            {
                SiteField siteField = new SiteField
                {
                    LocationId = id,
                    Field = field,
                    Type = type,
                    Description = detailsVm.FieldDescription,
                    Name = detailsVm.FieldName,
                    Grid = detailsVm.FieldGrid
                };

                _context.Add(siteField);
                _context.SaveChanges();

                ViewBag.Alert = AlertService.ShowAlert(Enums.Alerts.Success, "Field Successfully Added!");
            }
            else
            {
                ViewBag.Alert = AlertService.ShowAlert(Enums.Alerts.Warning, "Field Was Not Added");
            }

            return RedirectToAction("Details", new { id = id });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateNewMou(DetailsVm detailsVm, int id)
        {
            var location = await _context.Locations.FirstOrDefaultAsync(l => l.Id == id);

            Mou newMou = new();
            if (detailsVm.mou != null)
            {
                if (detailsVm.mou.MouFile != null)
                {
                    using (var target = new MemoryStream())
                    {
                        detailsVm.mou.File.CopyTo(target);
                        newMou.MouFile = target.ToArray();
                    }
                }

                newMou.Id = detailsVm.mou.Id;
                newMou.Title = detailsVm.mou.Title;
                newMou.StartDate = detailsVm.mou.StartDate;
                newMou.EndDate = detailsVm.mou.EndDate;
                newMou.PhoneNumber = detailsVm.mou.PhoneNumber;
                newMou.FirstName = detailsVm.mou.FirstName;
                newMou.lastName = detailsVm.mou.lastName;
                newMou.Email = detailsVm.mou.Email;

                _context.Add(newMou);
                await _context.SaveChangesAsync();
            }

            var Mou = await _context.Mous.FirstOrDefaultAsync(m => m.Title == detailsVm.mou.Title);

            if (Mou != null && location != null)
            {
                location.MouId = Mou.Id;
                _context.Update(location);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Details", new { id = id });

        }

        public async Task<ActionResult> EditSite(int id)
        {
            var location = await _context.Locations.FirstOrDefaultAsync(l => l.Id == id);

            AddSiteVm addSite = new()
            {
                City = location.City,
                State = location.State,
                Latitude = location.Latitude,
                Longitude = location.Longitude,
                Name = location.Name,
                LocationId = location.Id,
                ZipCode = location.ZipCode,
                StreetAddress = location.StreetAddress
            };

            return View(addSite);
        }

        [HttpPost]
        public async Task<ActionResult> EditSite(AddSiteVm siteVm)
        {
            var location = await _context.Locations.FirstOrDefaultAsync(l => l.Id == siteVm.LocationId);

            location.Name = siteVm.Name;
            location.StreetAddress = siteVm.StreetAddress;
            location.City = siteVm.City;
            location.State = siteVm.State;
            location.ZipCode = siteVm.ZipCode;
            location.Latitude = siteVm.Latitude;
            location.Longitude = siteVm.Longitude;

            _context.Locations.Update(location);
            await _context.SaveChangesAsync();

            return RedirectToAction("Details", new { id = siteVm.LocationId });

        }
        public async Task<ActionResult> DeleteSite(int id)
        {
            var location = await _context.Locations.FirstOrDefaultAsync(l => l.Id == id);

            return View(location);
        }

        [HttpPost, ActionName("DeleteSite")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var loc = await _context.Locations.FindAsync(id);
            var siteFields = await _context.SiteFields.Where(s => s.LocationId == loc.Id).ToListAsync();
            var siteNotes = await _context.LocationNotes.Where(n => n.LocationId == id).ToListAsync();
            var exLocation = await _context.ExcerciseLocations.Where(l => l.LocationId == id).ToListAsync();
            var pocLocation = await _context.PocLocations.Where(p => p.LocationId == id).ToListAsync();
            var siteImages = new List<FieldImage>();

            foreach(var item in siteFields)
            {
                var images = await _context.FieldImages.Where(s => s.FieldId == item.Id).ToListAsync();

                foreach(var image in images)
                {
                    _context.FieldImages.Remove(image);
                }
                _context.SiteFields.Remove(item);
            }
            foreach(var note in siteNotes)
            {
                _context.Remove(note);
            }
            foreach(var exloc in exLocation)
            {
                _context.Remove(exloc);
            }
            foreach(var pocloc in pocLocation)
            {
                _context.Remove(pocloc);
            }

            _context.Locations.Remove(loc);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Search));
        }

        public async Task<ActionResult> EditSiteField(int? id)
        {
            var field = await _context.SiteFields.FirstOrDefaultAsync(s => s.Id == id);

            return View(field);
        }

        [HttpPost]
        public async Task<ActionResult> EditSiteField(SiteField siteField)
        {
            var field = await _context.SiteFields.FirstOrDefaultAsync(s => s.Id == siteField.Id);

            if(ModelState.IsValid)
            {
                field.Name = siteField.Name;
                field.Grid = siteField.Grid;
                field.Description = siteField.Description;
                field.Field = siteField.Field;
                field.Type = siteField.Type;

                _context.Update(field);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Details", new { id = siteField.LocationId });
        }
        
        public async Task<ActionResult> DeleteSiteField(int? id)
        {
         
            var siteField = await _context.SiteFields.FirstOrDefaultAsync(s => s.Id == id);
            var images = await _context.FieldImages.Where(f => f.FieldId == siteField.Id).ToListAsync();
            foreach(var image in images)
            {
                _context.FieldImages.Remove(image);
            }
            _context.SiteFields.Remove(siteField);
            await _context.SaveChangesAsync();

            return RedirectToAction("Details", new { id = siteField.LocationId});
        }

        public async Task<ActionResult> Suggest()
        {
            string term = HttpContext.Request.Query["term"].ToString();
            var names = await _context.Locations.Where(l => l.Name.Contains(term)).Select(l => l.Name).ToListAsync();
            return Ok(names);
        }

        public async Task<ActionResult> searchRedirect(string name)
        {
            var locId = await _context.Locations.FirstOrDefaultAsync(l => l.Name == name);

            return RedirectToAction("Details", new { id = locId.Id });
        }
    }

}
