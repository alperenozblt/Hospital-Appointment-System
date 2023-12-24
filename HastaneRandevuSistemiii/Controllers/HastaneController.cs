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
    public class HastaneController : Controller
    {
        private readonly HastaneRandevuuContext _context;

        public HastaneController(HastaneRandevuuContext context)
        {
            _context = context;
        }

        // GET: Hastane
        public async Task<IActionResult> Index()
        {
              return _context.Hastanes != null ? 
                          View(await _context.Hastanes.ToListAsync()) :
                          Problem("Entity set 'HastaneRandevuuContext.Hastanes'  is null.");
        }

        // GET: Hastane/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Hastanes == null)
            {
                return NotFound();
            }

            var hastane = await _context.Hastanes
                .FirstOrDefaultAsync(m => m.HastaneId == id);
            if (hastane == null)
            {
                return NotFound();
            }

            return View(hastane);
        }

        // GET: Hastane/Create
        [Authorize(Roles = "Admin")]

        public IActionResult Create()
        {
            return View();
        }

        // POST: Hastane/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Create([Bind("HastaneId,HastaneAdi")] Hastane hastane)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hastane);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hastane);
        }

        // GET: Hastane/Edit/5
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Hastanes == null)
            {
                return NotFound();
            }

            var hastane = await _context.Hastanes.FindAsync(id);
            if (hastane == null)
            {
                return NotFound();
            }
            return View(hastane);
        }

        // POST: Hastane/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Edit(int id, [Bind("HastaneId,HastaneAdi")] Hastane hastane)
        {
            if (id != hastane.HastaneId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hastane);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HastaneExists(hastane.HastaneId))
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
            return View(hastane);
        }

        // GET: Hastane/Delete/5
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Hastanes == null)
            {
                return NotFound();
            }

            var hastane = await _context.Hastanes
                .FirstOrDefaultAsync(m => m.HastaneId == id);
            if (hastane == null)
            {
                return NotFound();
            }

            return View(hastane);
        }

        // POST: Hastane/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Hastanes == null)
            {
                return Problem("Entity set 'HastaneRandevuuContext.Hastanes'  is null.");
            }
            var hastane = await _context.Hastanes.FindAsync(id);
            if (hastane != null)
            {
                _context.Hastanes.Remove(hastane);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HastaneExists(int id)
        {
          return (_context.Hastanes?.Any(e => e.HastaneId == id)).GetValueOrDefault();
        }
    }
}
