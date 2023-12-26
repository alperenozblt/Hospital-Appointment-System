using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HastaneRandevuSistemiii.Data;
using HastaneRandevuSistemiii.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace HastaneRandevuSistemiii.Controllers
{
    public class PoliklinikController : Controller
    {
        private readonly HastaneRandevuuContext _context;

        public PoliklinikController(HastaneRandevuuContext context)
        {
            _context = context;
        }

        // GET: Poliklinik
        public async Task<IActionResult> Index()
        {
              return _context.Polikliniks != null ? 
                          View(await _context.Polikliniks.Include(h=>h.hastane).ToListAsync()) :
                          Problem("Entity set 'HastaneRandevuuContext.Polikliniks'  is null.");
        }

        // GET: Poliklinik/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Polikliniks == null)
            {
                return NotFound();
            }

            var poliklinik = await _context.Polikliniks
                .Include(h=>h.hastane)
                .FirstOrDefaultAsync(m => m.PoliklinikId == id);
            if (poliklinik == null)
            {
                return NotFound();
            }

            return View(poliklinik);
        }

        // GET: Poliklinik/Create
        [Authorize(Roles = "Admin")]

        public IActionResult Create()
        {
            var hastaneler = _context.Hastanes.ToList();
            ViewBag.Hastanes = new SelectList(hastaneler, "HastaneId", "HastaneAdi");
            return View();
        }

        // POST: Poliklinik/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Create([Bind("PoliklinikId,PoliklinikAdi,HastaneId")] Poliklinik poliklinik)
        {
            if (ModelState.IsValid)
            {
                var hastane = await _context.Hastanes.FindAsync(poliklinik.HastaneId);
                if (hastane == null)
                {
                    ModelState.AddModelError("HastaneId", "Geçersiz HastaneId");
                    return View(poliklinik);
                }
                poliklinik.HastaneId = hastane.HastaneId;

                _context.Add(poliklinik);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(poliklinik);
        }

        // GET: Poliklinik/Edit/5
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Edit(int id)
        {
            var poliklinik = await _context.Polikliniks.FindAsync(id);
            if (poliklinik == null)
            {
                return NotFound();
            }

            var hastaneler = _context.Hastanes.ToList();
            ViewBag.Hastanes = new SelectList(hastaneler, "HastaneId", "HastaneAdi", poliklinik.HastaneId);
            return View(poliklinik);
        }

        // POST: Poliklinik/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Edit(int id, [Bind("PoliklinikId,PoliklinikAdi,HastaneId")] Poliklinik poliklinik)
        {
            if (id != poliklinik.PoliklinikId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var hastane = await _context.Hastanes.FindAsync(poliklinik.HastaneId);
                if (hastane == null)
                {
                    ModelState.AddModelError("HastaneId", "Geçersiz HastaneId");
                    return View(poliklinik);
                }

                poliklinik.HastaneId = hastane.HastaneId;

                _context.Update(poliklinik);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(poliklinik);
        }


        // GET: Poliklinik/Delete/5
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Polikliniks == null)
            {
                return NotFound();
            }

            var poliklinik = await _context.Polikliniks
                .Include(h => h.hastane)
                .FirstOrDefaultAsync(m => m.PoliklinikId == id);
            if (poliklinik == null)
            {
                return NotFound();
            }

            return View(poliklinik);
        }

        // POST: Poliklinik/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Polikliniks == null)
            {
                return Problem("Entity set 'HastaneRandevuuContext.Polikliniks'  is null.");
            }
            var poliklinik = await _context.Polikliniks.FindAsync(id);
            if (poliklinik != null)
            {
                _context.Polikliniks.Remove(poliklinik);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PoliklinikExists(int id)
        {
          return (_context.Polikliniks?.Any(e => e.PoliklinikId == id)).GetValueOrDefault();
        }
    }
}
