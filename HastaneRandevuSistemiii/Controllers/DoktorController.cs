using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HastaneRandevuSistemiii.Data;
using HastaneRandevuSistemiii.Models;

namespace HastaneRandevuSistemiii.Controllers
{
    public class DoktorController : Controller
    {
        private readonly HastaneRandevuuContext _context;

        public DoktorController(HastaneRandevuuContext context)
        {
            _context = context;
        }

        // GET: Doktor
        public async Task<IActionResult> Index()
        {
              return _context.Doktors != null ? 
                          View(await _context.Doktors.ToListAsync()) :
                          Problem("Entity set 'HastaneRandevuuContext.Doktors'  is null.");
        }

        // GET: Doktor/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Doktors == null)
            {
                return NotFound();
            }

            var doktor = await _context.Doktors
                .FirstOrDefaultAsync(m => m.DoktorId == id);
            if (doktor == null)
            {
                return NotFound();
            }

            return View(doktor);
        }

        // GET: Doktor/Create
        // GET: Doktor/Create
        public IActionResult Create()
        {
            var hastaneler = _context.Hastanes.ToList();
            ViewBag.Hastanes = new SelectList(hastaneler, "HastaneId", "HastaneAdi");

            var poliklinikler = new List<Poliklinik>();
            ViewBag.Poliklinikler = new SelectList(poliklinikler, "PoliklinikId", "PoliklinikAdi");

            return View();
        }


        // POST: Doktor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DoktorId,DoktorAdi,DoktorSoyadi,HastaneId,PoliklinikId,IsActive")] Doktor doktor)
        {
            if (ModelState.IsValid)
            {

                var hastane = await _context.Hastanes.FindAsync(doktor.poliklinik.HastaneId);
                if (hastane == null)
                {
                    ModelState.AddModelError("HastaneId", "Geçersiz HastaneId");
                    return View(doktor);
                }

                var poliklinik = await _context.Polikliniks.FindAsync(doktor.PoliklinikId);
                if (poliklinik == null || poliklinik.HastaneId != doktor.poliklinik.HastaneId)
                {
                    ModelState.AddModelError("PoliklinikId", "Geçersiz PoliklinikId");
                    return View(doktor);
                }

                doktor.poliklinik.HastaneId = hastane.HastaneId;
                _context.Add(doktor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(doktor);
        }

        // GET: Doktor/GetPoliklinikler
        public async Task<IActionResult> GetPoliklinikler(int hastaneId)
        {
            var poliklinikler = await _context.Polikliniks.Where(p => p.HastaneId == hastaneId).ToListAsync();
            return Json(poliklinikler);
        }


        // GET: Doktor/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Doktors == null)
            {
                return NotFound();
            }

            var doktor = await _context.Doktors.FindAsync(id);
            if (doktor == null)
            {
                return NotFound();
            }
            return View(doktor);
        }

        // POST: Doktor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DoktorId,DoktorAdi,DoktorSoyadi,PoliklinikId,IsActive")] Doktor doktor)
        {
            if (id != doktor.DoktorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(doktor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DoktorExists(doktor.DoktorId))
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
            return View(doktor);
        }

        // GET: Doktor/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Doktors == null)
            {
                return NotFound();
            }

            var doktor = await _context.Doktors
                .FirstOrDefaultAsync(m => m.DoktorId == id);
            if (doktor == null)
            {
                return NotFound();
            }

            return View(doktor);
        }

        // POST: Doktor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Doktors == null)
            {
                return Problem("Entity set 'HastaneRandevuuContext.Doktors'  is null.");
            }
            var doktor = await _context.Doktors.FindAsync(id);
            if (doktor != null)
            {
                _context.Doktors.Remove(doktor);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DoktorExists(int id)
        {
          return (_context.Doktors?.Any(e => e.DoktorId == id)).GetValueOrDefault();
        }
    }
}
