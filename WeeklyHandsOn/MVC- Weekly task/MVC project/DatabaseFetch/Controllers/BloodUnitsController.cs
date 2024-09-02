using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Data.Models;

namespace Data.Controllers
{
    public class BloodUnitsController : Controller
    {
        private readonly DbprojectTapanContext _context;

        public BloodUnitsController(DbprojectTapanContext context)
        {
            _context = context;
        }

        // GET: BloodUnits
        public async Task<IActionResult> Index()
        {
            var dbprojectTapanContext = _context.BloodUnits.Include(b => b.Donor);
            return View(await dbprojectTapanContext.ToListAsync());
        }

        // GET: BloodUnits/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bloodUnit = await _context.BloodUnits
                .Include(b => b.Donor)
                .FirstOrDefaultAsync(m => m.UnitId == id);
            if (bloodUnit == null)
            {
                return NotFound();
            }

            return View(bloodUnit);
        }

        // GET: BloodUnits/Create
        public IActionResult Create()
        {
            ViewData["DonorId"] = new SelectList(_context.Donors, "DonorId", "DonorId");
            return View();
        }

        // POST: BloodUnits/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UnitId,BloodType,CollectionDate,ExpiryDate,DonorId,Status")] BloodUnit bloodUnit)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bloodUnit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DonorId"] = new SelectList(_context.Donors, "DonorId", "DonorId", bloodUnit.DonorId);
            return View(bloodUnit);
        }

        // GET: BloodUnits/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bloodUnit = await _context.BloodUnits.FindAsync(id);
            if (bloodUnit == null)
            {
                return NotFound();
            }
            ViewData["DonorId"] = new SelectList(_context.Donors, "DonorId", "DonorId", bloodUnit.DonorId);
            return View(bloodUnit);
        }

        // POST: BloodUnits/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UnitId,BloodType,CollectionDate,ExpiryDate,DonorId,Status")] BloodUnit bloodUnit)
        {
            if (id != bloodUnit.UnitId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bloodUnit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BloodUnitExists(bloodUnit.UnitId))
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
            ViewData["DonorId"] = new SelectList(_context.Donors, "DonorId", "DonorId", bloodUnit.DonorId);
            return View(bloodUnit);
        }

        // GET: BloodUnits/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bloodUnit = await _context.BloodUnits
                .Include(b => b.Donor)
                .FirstOrDefaultAsync(m => m.UnitId == id);
            if (bloodUnit == null)
            {
                return NotFound();
            }

            return View(bloodUnit);
        }

        // POST: BloodUnits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bloodUnit = await _context.BloodUnits.FindAsync(id);
            if (bloodUnit != null)
            {
                _context.BloodUnits.Remove(bloodUnit);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BloodUnitExists(int id)
        {
            return _context.BloodUnits.Any(e => e.UnitId == id);
        }
    }
}
