using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Round1.Models;

namespace Round1.Controllers
{
    public class DoktorController : Controller
    {
      
        private HastaneContext _context = new HastaneContext();
        // GET: Doktor
        public async Task<IActionResult> Index()
        {
              return _context.Doktors != null ? 
                          View(await _context.Doktors.ToListAsync()) :
                          Problem("Entity set 'HastaneContext.Doktors'  is null.");
        }

        // GET: Doktor/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Doktors == null)
            {
                return NotFound();
            }

            var doktor = await _context.Doktors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (doktor == null)
            {
                return NotFound();
            }

            return View(doktor);
        }

        // GET: Doktor/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Doktor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Adi,Soyadi,PoliklinikId")] Doktor doktor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(doktor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(doktor);
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,Adi,Soyadi,PoliklinikId")] Doktor doktor)
        {
            if (id != doktor.Id)
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
                    if (!DoktorExists(doktor.Id))
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
                .FirstOrDefaultAsync(m => m.Id == id);
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
                return Problem("Entity set 'HastaneContext.Doktors'  is null.");
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
          return (_context.Doktors?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
