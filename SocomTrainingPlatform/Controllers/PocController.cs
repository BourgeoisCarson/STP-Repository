using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SocomTrainingPlatform.Models;

namespace SocomTrainingPlatform.Controllers
{
    public class PocController : Controller
    {
        private readonly SocomTrainingPlatformContext _context;

        public PocController(SocomTrainingPlatformContext context)
        {
            _context = context;
        }

        // GET: Poc
        public async Task<IActionResult> Index()
        {
            var socomTrainingPlatformContext = _context.PointOfContacts.Include(p => p.Mou).Include(p => p.PocOrg);
            return View(await socomTrainingPlatformContext.ToListAsync());
        }

        // GET: Poc/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pointOfContact = await _context.PointOfContacts
                .Include(p => p.Mou)
                .Include(p => p.PocOrg)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pointOfContact == null)
            {
                return NotFound();
            }

            return View(pointOfContact);
        }

        // GET: Poc/Create
        public IActionResult Create()
        {
            ViewData["MouId"] = new SelectList(_context.Mous, "Id", "Title");
            ViewData["PocOrgId"] = new SelectList(_context.PocOrganizations, "Id", "OrgName");
            return View();
        }

        // POST: Poc/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,PhoneNumber,EmailAddress,PocOrgId,MouId")] PointOfContact pointOfContact)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pointOfContact);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MouId"] = new SelectList(_context.Mous, "Id", "Title", pointOfContact.MouId);
            ViewData["PocOrgId"] = new SelectList(_context.PocOrganizations, "Id", "OrgName", pointOfContact.PocOrgId);
            return View(pointOfContact);
        }

        // GET: Poc/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pointOfContact = await _context.PointOfContacts.FindAsync(id);
            if (pointOfContact == null)
            {
                return NotFound();
            }
            ViewData["MouId"] = new SelectList(_context.Mous, "Id", "Title", pointOfContact.MouId);
            ViewData["PocOrgId"] = new SelectList(_context.PocOrganizations, "Id", "OrgName", pointOfContact.PocOrgId);
            return View(pointOfContact);
        }

        // POST: Poc/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,PhoneNumber,EmailAddress,PocOrgId,MouId")] PointOfContact pointOfContact)
        {
            if (id != pointOfContact.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pointOfContact);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PointOfContactExists(pointOfContact.Id))
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
            ViewData["MouId"] = new SelectList(_context.Mous, "Id", "Title", pointOfContact.MouId);
            ViewData["PocOrgId"] = new SelectList(_context.PocOrganizations, "Id", "OrgName", pointOfContact.PocOrgId);
            return View(pointOfContact);
        }

        // GET: Poc/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pointOfContact = await _context.PointOfContacts
                .Include(p => p.Mou)
                .Include(p => p.PocOrg)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pointOfContact == null)
            {
                return NotFound();
            }

            return View(pointOfContact);
        }

        // POST: Poc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pointOfContact = await _context.PointOfContacts.FindAsync(id);
            _context.PointOfContacts.Remove(pointOfContact);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PointOfContactExists(int id)
        {
            return _context.PointOfContacts.Any(e => e.Id == id);
        }
    }
}
