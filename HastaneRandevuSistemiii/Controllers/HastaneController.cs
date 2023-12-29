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
using Newtonsoft.Json;

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
            List<Hastane> hastaneler = _context.Hastanes.ToList();
            HttpClient client = new HttpClient();
            var response = await client.GetAsync("https://localhost:7020/api/SystemApi");
            var jsonResponse = await response.Content.ReadAsStringAsync();
            hastaneler = JsonConvert.DeserializeObject<List<Hastane>>(jsonResponse);


            return View(hastaneler);
        }

        // GET: Hastane/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            Hastane hastane = _context.Hastanes.Where(x => x.HastaneId == id).First();
            HttpClient client = new HttpClient();
            var response = await client.GetAsync("https://localhost:7020/api/SystemApi/id");
            var jsonResponse = await response.Content.ReadAsStringAsync();
            ViewBag.Hastane = jsonResponse;

            //  hastane = JsonConvert.DeserializeObject<Hastane>(jsonResponse);

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

        public async Task<IActionResult> Create([Bind("HastaneId,HastaneAdi,HastaneTel,HastaneAddress")] Hastane hastane)
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
        [HttpPut]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Edit(int id, [Bind("HastaneId,HastaneAdi,HastaneTel,HastaneAddress")] Hastane hastane)
        {

            try
            {
                // API'den hastane bilgilerini al
                var client = new HttpClient();
                var response = await client.GetAsync("https://localhost:7020/api/SystemApi/id={id}");
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var apiHastane = JsonConvert.DeserializeObject<Hastane>(jsonResponse);

                // API'den gelen bilgileri modele aktar
                hastane.HastaneAdi = apiHastane.HastaneAdi;
                hastane.HastaneTel = apiHastane.HastaneTel;
                hastane.HastaneAddress = apiHastane.HastaneAddress;

                // Modeli database'e kaydet
                _context.Update(hastane);
                await _context.SaveChangesAsync();

                // View'a bir mesaj gönder
                ViewData["Mesaj"] = "Hastane bilgileri başarıyla güncellendi.";

                // View'a hastane bilgilerini gönder
                return  View(hastane);
            }
            catch (Exception ex)
            {
                // API çağrısında hata olursa
                return BadRequest(ex.Message);
            }
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
