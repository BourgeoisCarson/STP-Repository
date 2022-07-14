using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SocomTrainingPlatform.Models;
using SocomTrainingPlatform.Models.ExcerciseModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SocomTrainingPlatform.Controllers
{
    public class ExcerciseController : Controller
    {
        private readonly SocomTrainingPlatformContext _context;

        public ExcerciseController(SocomTrainingPlatformContext context)
        {
            _context = context;
        }

        // GET: ExcerciseController
        public async Task<ActionResult> Index()
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
                SearchModel = excerciseSearch.OrderByDescending(e => e.StartDate).ToList()
            };

            ViewData["ExcerciseTypes"] = excerciseDropdown;


            return View(exIndex);
        }

        [HttpPost]
        public async Task<ActionResult> Index(ExcerciseSearchModel excerciseSearchModel, int page)
        {
            var excercise = await _context.Excercises.ToListAsync();
            var excerciseTypes = await _context.ExcerciseTypes.ToListAsync();
            var tempExcerciseType = new ExcerciseType();
            var exTypeChoice = excerciseSearchModel.ExcerciseChoice;
            var PageResults = 10f;
            var pageCount = Math.Ceiling(_context.Excercises.Count() / PageResults);
            var excerciseDropdown = new List<SelectListItem>();
            List<ExcerciseSearchModel> excerciseSearch = new List<ExcerciseSearchModel>();
            ExcerciseIndex exIndex = new ExcerciseIndex();

            foreach (var item in excerciseTypes)
            {
                excerciseDropdown.Add(new SelectListItem { Text = item.ExcerciseName, Value = item.ExcerciseName });
            }

            if (exTypeChoice == null || exTypeChoice == "All Locations")
            {
                excercise = excercise.Skip((page - 1) * (int)PageResults)
                .Take((int)PageResults)
                .OrderBy(e => e.StartDate)
                .ToList();

                var excerciseResults= from l in excerciseTypes
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
                    SearchModel = excerciseResults.OrderByDescending(e => e.StartDate).ToList(),
                    Pages = (int)pageCount,
                    CurrentPage = page
                };
            }
            else if(exTypeChoice != null && exTypeChoice != "All Locations")
            {
                tempExcerciseType = await _context.ExcerciseTypes.FirstOrDefaultAsync(e => e.ExcerciseName == excerciseSearchModel.ExcerciseChoice);

                excercise = excercise.Where(c => c.ExcerciseTypeId == tempExcerciseType.Id).ToList();

                excercise = excercise.Skip((page - 1) * (int)PageResults)
                .OrderBy(e => e.StartDate)
                .Take((int)PageResults)
                .ToList();

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

                /*foreach (var item in excercise)
                {
                    var tempSearchModel = new ExcerciseSearchModel();

                    tempSearchModel.ExcerciseType = tempExcerciseType.ExcerciseName;
                    tempSearchModel.ExcerciseName = item.TypeName;
                    tempSearchModel.StartDate = item.StartDate;
                    tempSearchModel.EndDate = item.EndDate;

                    excerciseSearch.Add(tempSearchModel);
                }*/

                exIndex = new ExcerciseIndex()
                {
                    SearchModel = excerciseResults.OrderByDescending(e => e.StartDate).ToList(),
                    Pages = (int)pageCount,
                    CurrentPage = page
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
        public async Task<ActionResult> Details(int? id)
        {
            var excercise = await _context.Excercises.FirstOrDefaultAsync(i => i.Id == id);
            var excerciseType = await _context.ExcerciseTypes.FirstOrDefaultAsync(i => i.Id == excercise.ExcerciseTypeId);
            var excerciseNotes = new List<ExcerciseNote>();
            var excerciseLocations = new List<ExcerciseLocation>();
            var supportDocs = new List<SupportDocument>();
            var excerciseBriefs = new List<ExcerciseBrief>();
            List<Location> locList = new();
            List<SelectListItem> selectLocList = new List<SelectListItem>();

            var AllLocations = await _context.Locations.ToListAsync();

            if (await _context.ExcerciseBriefs.Where(b => b.ExcerciseId == id).ToListAsync() != null)
            {
                excerciseBriefs = await _context.ExcerciseBriefs.Where(b => b.ExcerciseId == id).ToListAsync();
            }

            if (await _context.SupportDocuments.Where(b => b.ExcerciseId == id).ToListAsync() != null)
            {
                supportDocs = await _context.SupportDocuments.Where(b => b.ExcerciseId == id).ToListAsync();
            }

            if (await _context.ExcerciseLocations.Where(b => b.ExcerciseId == id).ToListAsync() != null)
            {
                excerciseLocations = await _context.ExcerciseLocations.Where(b => b.ExcerciseId == id).ToListAsync();

                List<int> arr = new();

                foreach(var item in excerciseLocations)
                {
                    arr.Add(item.LocationId);
                }

                foreach(var i in arr)
                {
                    locList.Add(await _context.Locations.FirstOrDefaultAsync(l => l.Id == i));
                }

                List<Location> allLocations = await _context.Locations.ToListAsync();

                foreach (var item in allLocations)
                {
                    selectLocList.Add(new SelectListItem { Text = item.Name, Value = item.Name });
                }

            }

            if (await _context.ExcerciseNotes.Where(b => b.ExcerciseId == id).ToListAsync() != null)
            {
                excerciseNotes = await _context.ExcerciseNotes.Where(b => b.ExcerciseId == id).ToListAsync();
            }

            List<SupportDocModels> newSupDocs = new();
            List<BreifDocModels> newBreifDocs = new();

            foreach(var item in supportDocs)
            {
                SupportDocModels tempSup = new();

                tempSup.FileName = item.FileName;
                tempSup.Id = item.Id;
                tempSup.UploadDate = item.DateStamp;
               

                using (var ms = new MemoryStream(item.FileData))
                {
                    tempSup.file = new FormFile(ms, 0, ms.Length, item.FileName, item.FileType);
                }
                newSupDocs.Add(tempSup);
            }
            foreach(var item in excerciseBriefs)
            {
                BreifDocModels tempBreif = new();

                tempBreif.FileName = item.FileTitle;
                tempBreif.Id = item.Id;
                tempBreif.UploadDate = item.DateStamp;

                using (var ms = new MemoryStream(item.FileData))
                {
                    tempBreif.file = new FormFile(ms, 0, ms.Length, item.FileTitle, "pdf");
                }
                newBreifDocs.Add(tempBreif);
            }


            var detailsVm = new ExcerciseDetailsVm
            {
                Excercise = excercise,
                Notes = excerciseNotes,
                Briefs = newBreifDocs,
                Locations = locList,
                Docs = newSupDocs,
                ExcerciseType = excerciseType.ExcerciseName,
                AllLocations = AllLocations,
            };

            ViewData["SelectLocations"] = selectLocList;

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

            if(ModelState.IsValid)
            {
                supDoc.FileName = detailsVm.FileName;
                supDoc.DateStamp = DateTime.Now;
                supDoc.ExcerciseId = id;
                supDoc.FileType = ".pdf";

                if(detailsVm.file != null)
                {

                    using (var target = new MemoryStream())
                    {
                        detailsVm.file.CopyTo(target);
                        supDoc.FileData = target.ToArray();
                    }
                }

                _context.SupportDocuments.Add(supDoc);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Details), new { id = id });
        }

        [HttpPost]
        public async Task<ActionResult> UploadBrief(ExcerciseDetailsVm detailsVm, int id)
        {
            ExcerciseBrief supDoc = new ExcerciseBrief();

            if (ModelState.IsValid)
            {
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
            }

            return RedirectToAction(nameof(Details), new { id = id });
        }


        public async Task<IActionResult> DeleteSupDoc()
        {
            return RedirectToAction("Details");
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
            if(addLoc.LocationChoice != null)
            {
                var Location = await _context.Locations.FirstOrDefaultAsync(l => l.Name == addLoc.LocationChoice);

                var ExcerciseLocation = await _context.ExcerciseLocations.Where(e => e.ExcerciseId == id).ToListAsync();

                if(ExcerciseLocation.Find(e => e.LocationId == Location.Id) != null)
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
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> UpdateLocation(int id)
        {
            var exLocation = await _context.ExcerciseLocations.FindAsync(id);
            _context.ExcerciseLocations.Remove(exLocation);
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", new { id = id });
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
