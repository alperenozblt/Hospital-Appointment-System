using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HastaneRandevuSistemiii.Data;
using HastaneRandevuSistemiii.Models;
using Microsoft.AspNetCore.Identity;

namespace HastaneRandevuSistemiii.Controllers
{
    public class RandevuController : Controller
    {
        private readonly HastaneRandevuuContext _context;
        private readonly SignInManager<Kullanici> _signInManager;


        public RandevuController(HastaneRandevuuContext context, SignInManager<Kullanici> signInManager)
        {
            _signInManager = signInManager;
            _context = context;
        }

        // GET: Randevu
        public async Task<IActionResult> Index()
        {
              return _context.Randevus != null ? 
                          View(await _context.Randevus.Include(p=>p.Doktor).ToListAsync()) :
                          Problem("Entity set 'HastaneRandevuuContext.Randevus'  is null.");
        }

        // GET: Randevu/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Randevus == null)
            {
                return NotFound();
            }

            var randevu = await _context.Randevus
                .FirstOrDefaultAsync(m => m.RandevuID == id);
            if (randevu == null)
            {
                return NotFound();
            }

            return View(randevu);
        }







    //    var randevuVar = _context.Randevus.FirstOrDefault(x => x.RandevuTarih == randevu.RandevuTarih && x.RandevuSaat == randevu.RandevuSaat);
    //            if (randevuVar != null)
    //            {
    //               // ModelState.AddModelError("Randevu zaten alınmış.");
    //                return View(randevu);
    //}



    // GET: Randevu/Create
    public IActionResult Create()
        {


            var hastaneler =_context.Hastanes.ToList();
            ViewBag.Hastanes = new SelectList(hastaneler, "HastaneId", "HastaneAdi");




            return View();
        }

        // POST: Randevu/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( Randevu randevu)
        {

            Kullanici kullanici = await _signInManager.UserManager.GetUserAsync(User);


            if (ModelState.IsValid)
            {
                _context.Add(randevu); 
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(randevu);
        }

        // GET: Randevu/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Randevus == null)
            {
                return NotFound();
            }

            var randevu = await _context.Randevus.FindAsync(id);
            if (randevu == null)
            {
                return NotFound();
            }
            return View(randevu);
        }

        // POST: Randevu/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RandevuID,DoktorId,KullaniciId,HastaneId,RandevuTarih")] Randevu randevu)
        {
            if (id != randevu.RandevuID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(randevu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RandevuExists(randevu.RandevuID))
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
            return View(randevu);
        }

        // GET: Randevu/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Randevus == null)
            {
                return NotFound();
            }

            var randevu = await _context.Randevus
                .FirstOrDefaultAsync(m => m.RandevuID == id);
            if (randevu == null)
            {
                return NotFound();
            }

            return View(randevu);
        }

        // POST: Randevu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Randevus == null)
            {
                return Problem("Entity set 'HastaneRandevuuContext.Randevus'  is null.");
            }
            var randevu = await _context.Randevus.FindAsync(id);
            if (randevu != null)
            {
                _context.Randevus.Remove(randevu);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RandevuExists(int id)
        {
          return (_context.Randevus?.Any(e => e.RandevuID == id)).GetValueOrDefault();
        }

      
       
    }
}
