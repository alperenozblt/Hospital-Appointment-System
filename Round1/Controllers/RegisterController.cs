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
    public class RegisterController : Controller
    {
        private readonly HastaneContext _context;

        public RegisterController(HastaneContext context)
        {
            _context = context;
        }

        // GET: Register
        public async Task<IActionResult> Index()
        {
              return _context.Hastas != null ? 
                          View(await _context.Hastas.ToListAsync()) :
                          Problem("Entity set 'HastaneContext.Hastas'  is null.");
        }

        // GET: Register/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Hastas == null)
            {
                return NotFound();
            }

            var hasta = await _context.Hastas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hasta == null)
            {
                return NotFound();
            }

            return View(hasta);
        }

        // GET: Register/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Register/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Adı,Soyadi,TCKimlikNumarası,TelefonNumarası,HastaPassword,DogumYılı")] Hasta hasta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hasta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hasta);
        }

        // GET: Register/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Hastas == null)
            {
                return NotFound();
            }

            var hasta = await _context.Hastas.FindAsync(id);
            if (hasta == null)
            {
                return NotFound();
            }
            return View(hasta);
        }

        // POST: Register/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Adı,Soyadi,TCKimlikNumarası,TelefonNumarası,HastaPassword,DogumYılı")] Hasta hasta)
        {
            if (id != hasta.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hasta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HastaExists(hasta.Id))
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
            return View(hasta);
        }

        // GET: Register/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Hastas == null)
            {
                return NotFound();
            }

            var hasta = await _context.Hastas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hasta == null)
            {
                return NotFound();
            }

            return View(hasta);
        }

        // POST: Register/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Hastas == null)
            {
                return Problem("Entity set 'HastaneContext.Hastas'  is null.");
            }
            var hasta = await _context.Hastas.FindAsync(id);
            if (hasta != null)
            {
                _context.Hastas.Remove(hasta);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HastaExists(int id)
        {
          return (_context.Hastas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
