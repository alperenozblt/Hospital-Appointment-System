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
    public class AnaBilimDaliController : Controller
    {
        private readonly HastaneContext _context;

        public AnaBilimDaliController(HastaneContext context)
        {
            _context = context;
        }

        // GET: AnaBilimDali
        public async Task<IActionResult> Index()
        {
              return _context.AnaBilimDalis != null ? 
                          View(await _context.AnaBilimDalis.ToListAsync()) :
                          Problem("Entity set 'HastaneContext.AnaBilimDalis'  is null.");
        }

        // GET: AnaBilimDali/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AnaBilimDalis == null)
            {
                return NotFound();
            }

            var anaBilimDali = await _context.AnaBilimDalis
                .FirstOrDefaultAsync(m => m.Id == id);
            if (anaBilimDali == null)
            {
                return NotFound();
            }

            return View(anaBilimDali);
        }

        // GET: AnaBilimDali/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AnaBilimDali/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Adi,HastaneId")] AnaBilimDali anaBilimDali)
        {
            if (ModelState.IsValid)
            {
                _context.Add(anaBilimDali);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(anaBilimDali);
        }

        // GET: AnaBilimDali/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AnaBilimDalis == null)
            {
                return NotFound();
            }

            var anaBilimDali = await _context.AnaBilimDalis.FindAsync(id);
            if (anaBilimDali == null)
            {
                return NotFound();
            }
            return View(anaBilimDali);
        }

        // POST: AnaBilimDali/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Adi,HastaneId")] AnaBilimDali anaBilimDali)
        {
            if (id != anaBilimDali.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(anaBilimDali);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnaBilimDaliExists(anaBilimDali.Id))
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
            return View(anaBilimDali);
        }

        // GET: AnaBilimDali/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AnaBilimDalis == null)
            {
                return NotFound();
            }

            var anaBilimDali = await _context.AnaBilimDalis
                .FirstOrDefaultAsync(m => m.Id == id);
            if (anaBilimDali == null)
            {
                return NotFound();
            }

            return View(anaBilimDali);
        }

        // POST: AnaBilimDali/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AnaBilimDalis == null)
            {
                return Problem("Entity set 'HastaneContext.AnaBilimDalis'  is null.");
            }
            var anaBilimDali = await _context.AnaBilimDalis.FindAsync(id);
            if (anaBilimDali != null)
            {
                _context.AnaBilimDalis.Remove(anaBilimDali);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnaBilimDaliExists(int id)
        {
          return (_context.AnaBilimDalis?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
