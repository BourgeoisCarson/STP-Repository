using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SocomTrainingPlatform.Models;
using SocomTrainingPlatform.Models.MouModels;

namespace SocomTrainingPlatform.Controllers
{
    public class MouController : Controller
    {
        private readonly SocomTrainingPlatformContext _context;

        public MouController(SocomTrainingPlatformContext context)
        {
            _context = context;
        }

        // GET: Mous
        public async Task<IActionResult> Index()
        {
            var mous = await _context.Mous.ToListAsync();

            foreach (var item in mous)
            {
                using (var ms = new MemoryStream(item.MouFile))
                {
                    item.File = new FormFile(ms, 0, ms.Length, item.Title, item.FileType);
                }
            }


            return View(mous);
        }

        public FileContentResult ShowFile(int id)
        {
            var mou = _context.Mous.FirstOrDefault(m => m.Id == id);

            string contentType = "application/pdf";

            return new FileContentResult(mou.MouFile, contentType);

        }

        // GET: Mous/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mou = await _context.Mous
                .FirstOrDefaultAsync(m => m.Id == id);

                using (var ms = new MemoryStream(mou.MouFile))
                {
                    mou.File = new FormFile(ms, 0, ms.Length, mou.Title, mou.FileType);
                }

            if (mou == null)
            {
                return NotFound();
            }

            var locations = new List<Location>();
            var excercises = new List<Excercise>();

            if(await _context.Locations.FirstOrDefaultAsync(l => l.MouId == mou.Id) != null)
            {
                locations = await _context.Locations.Where(l => l.MouId == mou.Id).ToListAsync();
            }
            if (await _context.MouExcercises.FirstOrDefaultAsync(l => l.MouId == mou.Id) != null)
            {
                var mouExcercise = await _context.MouExcercises.Where(l => l.MouId == mou.Id).ToListAsync();

                foreach (var item in mouExcercise)
                {
                    excercises.Add(await _context.Excercises.FirstOrDefaultAsync(e => e.Id == item.ExcerciseId));
                }
            }

            var mouDetails = new MouDetailsVm()
            {
                Locations = locations,
                Exccercises = excercises,
                File = mou.File,
                Id = mou.Id,
                Title = mou.Title,
                StartDate = mou.StartDate,
                EndDate = mou.EndDate,
                PhoneNumber = mou.PhoneNumber,
                FirstName = mou.FirstName,
                lastName = mou.lastName,
                Email = mou.Email,
            };

            return View(mouDetails);
        }

        // GET: Mous/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Mous/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MouCreate mou)
        {
            Mou newMou = new();
            if (ModelState.IsValid)
            {
                if(mou.MouFile != null)
                {
                    using (var target = new MemoryStream())
                    {
                        mou.MouFile.CopyTo(target);
                        newMou.MouFile = target.ToArray();
                    }
                }

                newMou.Id = mou.Id;
                newMou.Title = mou.Title;
                newMou.StartDate = mou.StartDate;
                newMou.EndDate = mou.EndDate;
                newMou.PhoneNumber = mou.PhoneNumber;
                newMou.FirstName = mou.FirstName;
                newMou.lastName = mou.lastName;
                newMou.Email = mou.Email;

                _context.Add(newMou);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(mou);
        }

        // GET: Mous/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mou = await _context.Mous.FindAsync(id);
            if (mou == null)
            {
                return NotFound();
            }
            return View(mou);
        }

        // POST: Mous/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MouFile,StartDate,EndDate,Title,FirstName,lastName,Email,PhoneNumber")] Mou mou)
        {
            if (id != mou.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mou);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MouExists(mou.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(mou);
        }

        // GET: Mous/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mou = await _context.Mous
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mou == null)
            {
                return NotFound();
            }

            return View(mou);
        }

        // POST: Mous/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mou = await _context.Mous.FindAsync(id);
            _context.Mous.Remove(mou);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MouExists(int id)
        {
            return _context.Mous.Any(e => e.Id == id);
        }
    }
}
