using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RavenSiteSurvey.BuisnessLogic;
using RavenSiteSurvey.Repositories;
using SocomTrainingPlatform.Models;
using SocomTrainingPlatform.Models.ExcerciseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace SocomTrainingPlatform.Controllers
{
    public class AdminController : Controller
    {

        private readonly SocomTrainingPlatformContext _context;
        private readonly LocRepo locRepo;
        private readonly SiteLogic dashLogic;
        //private readonly AddFieldsRepo addFields;


        public AdminController(SocomTrainingPlatformContext context)
        {
            _context = context;
            locRepo = new LocRepo(context);
            //addFields = new AddFieldsRepo(context);
            dashLogic = new SiteLogic(context);
        }

        // GET: AdminController
        public ActionResult Index()
        {
            return View();
        }

        // GET: AdminController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AdminController/Create
        public async Task<IActionResult> AddExcercise()
        {
            AddExcerciseVm excerciseVm = new AddExcerciseVm();
            List<ExcerciseType> typeList = await _context.ExcerciseTypes.ToListAsync();

            List<SelectListItem> typeSelect = new List<SelectListItem>();

            foreach (var item in typeList)
            {
                typeSelect.Add(new SelectListItem { Value = item.ExcerciseName, Text = item.ExcerciseName });
            }

            excerciseVm.TypeList = typeSelect;

            return View(excerciseVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddExcercise(AddExcerciseVm excerciseVm)
        {
            string id = User.Identity.Name;

            if (ModelState.IsValid)
            {               
                ExcerciseType typeChoice = await _context.ExcerciseTypes.FirstOrDefaultAsync(i => i.ExcerciseName == excerciseVm.ExcerciseName);

                Excercise excercise = new Excercise()
                {
                    TypeName = excerciseVm.ExcerciseName,
                    StartDate = excerciseVm.StartDate,
                    EndDate = excerciseVm.EndDate,
                    ExcerciseTypeId = typeChoice.Id,

                };

                _context.Add(excercise);
                await _context.SaveChangesAsync();


            }

            return RedirectToAction(nameof(Index));
        }

        // GET: AdminController/Create
        public async Task<IActionResult> AddExcerciseType()
        {
            AddExcerciseTypeVm typeVm = new AddExcerciseTypeVm();
            List<Organization> OrgList = await _context.Organizations.ToListAsync();

            List<SelectListItem> orgSelect = new List<SelectListItem>();

            foreach (var item in OrgList)
            {
               orgSelect.Add(new SelectListItem { Value = item.Name, Text = item.Name });
            }

            typeVm.Organizations = orgSelect;

            return View(typeVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddExcerciseType(AddExcerciseTypeVm typeVm)
        {
            if(ModelState.IsValid)
            {
                Organization orgChoice = await _context.Organizations.FirstOrDefaultAsync(i => i.Name == typeVm.OrgChoice);

                ExcerciseType exType = new ExcerciseType()
                {
                    ExcerciseName = typeVm.ExcerciseName,
                    ExcerciseDescription = typeVm.ExcerciseDescription,
                    OrgId = orgChoice.Id,

                };

                _context.Add(exType);
                await _context.SaveChangesAsync();


            }

            return RedirectToAction(nameof(Index));
        }

        // POST: AdminController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: AdminController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AdminController/Edit/5
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

        // GET: AdminController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AdminController/Delete/5
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
