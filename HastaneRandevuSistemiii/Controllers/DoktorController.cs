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
						View(await _context.Doktors.Include(p => p.Poliklinik.hastane).ToListAsync()) :
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
				.Include(p => p.Poliklinik.hastane)
				.FirstOrDefaultAsync(m => m.DoktorId == id);
			if (doktor == null)
			{
				return NotFound();
			}

			return View(doktor);
		}

		// GET: Doktor/Create
		[Authorize(Roles = "Admin")]
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
		[Authorize(Roles = "Admin")]

		public async Task<IActionResult> Create(Doktor doktor)
		{


			var hastane = await _context.Hastanes.FindAsync(doktor.Poliklinik.HastaneId);
			if (hastane == null)
			{
				ModelState.AddModelError("HastaneId", "Geçersiz HastaneId");
				return View(doktor);
			}

			var poliklinik = await _context.Polikliniks.FindAsync(doktor.PoliklinikId);
			if (poliklinik == null || poliklinik.HastaneId != doktor.Poliklinik.HastaneId)
			{
				ModelState.AddModelError("PoliklinikId", "Geçersiz PoliklinikId");
				return View(doktor);
			}

			doktor.Poliklinik.HastaneId = hastane.HastaneId;
			var dokt = new Doktor()
			{
				DoktorAdi = doktor.DoktorAdi,
				DoktorSoyadi = doktor.DoktorSoyadi,
				PoliklinikId = poliklinik.PoliklinikId,

			};
			_context.Add(dokt);
			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));

		}

		// GET: Doktor/GetPoliklinikler
		public async Task<IActionResult> GetPoliklinikler(int hastaneId)
		{
			var poliklinikler = await _context.Polikliniks.Where(p => p.HastaneId == hastaneId).ToListAsync();
			return Json(poliklinikler);
		}


		// GET: Doktor/Edit/5
		[Authorize(Roles = "Admin")]

		public async Task<IActionResult> Edit(int? id)
		{
			var hastaneler = _context.Hastanes.ToList();
			ViewBag.Hastanes = new SelectList(hastaneler, "HastaneId", "HastaneAdi");

			var poliklinikler = new List<Poliklinik>();
			ViewBag.Poliklinikler = new SelectList(poliklinikler, "PoliklinikId", "PoliklinikAdi");
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
		[Authorize(Roles = "Admin")]

		public async Task<IActionResult> Edit(int id, [Bind("DoktorId,DoktorAdi,DoktorSoyadi,PoliklinikId")] Doktor doktor)
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
		[Authorize(Roles = "Admin")]

		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null || _context.Doktors == null)
			{
				return NotFound();
			}

			var doktor = await _context.Doktors
				.Include(p => p.Poliklinik)
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
		[Authorize(Roles = "Admin")]

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