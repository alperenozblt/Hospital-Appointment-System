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
using Microsoft.AspNetCore.Authorization;
using HastaneRandevuSistemiii.Models;
using HastaneRandevuSistemiii.Data;

namespace Hastane_Randevu_Sistemi.Controllers
{
    public class RandevuController : Controller
    {
        private readonly HastaneRandevuuContext _context;
        private readonly UserManager<Kullanici> _userManager;

        public RandevuController(HastaneRandevuuContext context, UserManager<Kullanici> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            ViewData["Doktorlar"] = _context.Doktors.ToList();
            return _context.Randevus != null ?
                        View(await _context.Randevus.ToListAsync()) :
                        Problem("Entity set 'HastaneContext.Randevu'  is null.");
        }

        public async Task<IActionResult> RandevuList()
        {
            var userid = _userManager.GetUserId(User);
            var randevular = _context.Randevus.Where(x => x.KullaniciId == userid);
            return randevular != null ?
                        View(randevular) :
                        Problem("Randevu Bulunamadı");
        }

        // GET: Randevu/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            ViewData["Kullanıcılar"] = _context.Users.ToList();
            var hastaneler = _context.Hastanes.ToList();
            ViewData["Hastaneler"] = hastaneler;

            ViewData["Poliklinikler"] = _context.Polikliniks.ToList();
            ViewData["Doktorlar"] = _context.Doktors.ToList();
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

        // GET: Randevu/Create
        public IActionResult Create()
        {
            ViewData["Kullanıcılar"] = _context.Users.ToList();
            var hastaneler = _context.Hastanes.ToList();
            ViewData["Hastaneler"] = hastaneler;

            ViewData["Poliklinikler"] = _context.Polikliniks.ToList();
            ViewData["Doktorlar"] = _context.Doktors.ToList();


            return View();
        }

        public async Task<IActionResult> GetPoliklinikler(int hastaneId)
        {
            var poliklinikler = await _context.Polikliniks.Where(p => p.HastaneId == hastaneId).ToListAsync();
            return Json(poliklinikler);
        }

        public async Task<IActionResult> GetDoktorlar(int poliklinikId)
        {
            var doktorlar = await _context.Doktors.Where(d => d.PoliklinikId == poliklinikId).ToListAsync();
            return Json(doktorlar);
        }

        // POST: Randevu/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Randevu randevu)
        {
            ViewData["Kullanıcılar"] = _context.Users.ToList();
            var hastaneler = _context.Hastanes.ToList();
            ViewData["Hastaneler"] = hastaneler;

            ViewData["Poliklinikler"] = _context.Polikliniks.ToList();
            ViewData["Doktorlar"] = _context.Doktors.ToList();


            var randevular = _context.Randevus.ToList();
            randevu.KullaniciId = _userManager.GetUserId(User);

            if (!randevular.Any(x => x.RandevuGun == randevu.RandevuGun && x.RandevuSaat == x.RandevuSaat && x.DoktorId == randevu.DoktorId))
            {
                randevu.IsEmpty = false;
                _context.Add(randevu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(randevu);
        }

        // GET: Randevu/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            ViewData["Kullanıcılar"] = _context.Users.ToList();
            var hastaneler = _context.Hastanes.ToList();
            ViewData["Hastaneler"] = hastaneler;

            ViewData["Poliklinikler"] = _context.Polikliniks.ToList();
            ViewData["Doktorlar"] = _context.Doktors.ToList();
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
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, [Bind("RandevuID,DoktorId,KullaniciId,RandevuGun,RandevuSaat,IsEmpty")] Randevu randevu)
        {
            var hastaneler = _context.Hastanes.ToList();
            ViewData["Hastaneler"] = hastaneler;

            ViewData["Poliklinikler"] = _context.Polikliniks.ToList();
            ViewData["Doktorlar"] = _context.Doktors.ToList();
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
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            ViewData["Kullanıcılar"] = _context.Users.ToList();
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
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            ViewData["Kullanıcılar"] = _context.Users.ToList();
            if (_context.Randevus == null)
            {
                return Problem("Entity set 'HastaneContext.Randevu'  is null.");
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