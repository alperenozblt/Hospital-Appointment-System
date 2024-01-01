using HastaneRandevuSistemiii.Data;
using HastaneRandevuSistemiii.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hastane_Randevu_Sistemi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PoliklinikApiController : ControllerBase
	{
		private readonly HastaneRandevuuContext _context;

		public PoliklinikApiController(HastaneRandevuuContext context)
		{
			_context = context;
		}


		// GET: api/<HastaneApiController>
		[HttpGet]
		public IEnumerable<Poliklinik> Get()
		{
			var poliklinikler = _context.Polikliniks.Include(x=>x.hastane).ToList();
			return poliklinikler;
		}

		// GET api/<HastaneApiController>/5
		[HttpGet("{id}")]
		public IActionResult Get(int id)
		{
			var poliklinik = _context.Polikliniks.Include(x => x.hastane).FirstOrDefault(x => x.PoliklinikId == id);

			return Ok(poliklinik);
		}

		// POST api/<HastaneApiController>
		[HttpPost]
		public IActionResult Post([FromBody] Poliklinik poliklinik)
		{
			_context.Polikliniks.Add(poliklinik);
			_context.SaveChanges();
			return Ok(poliklinik);
		}

		// PUT api/<HastaneApiController>/5
		[HttpPut("{id}")]
		public IActionResult Put(int id, [FromBody] Poliklinik poliklinik)
		{
			var _poliklinik = _context.Polikliniks.FirstOrDefault(x => x.PoliklinikId == id);
			_poliklinik.PoliklinikAdi = poliklinik.PoliklinikAdi;
			_poliklinik.hastane.HastaneAdi = poliklinik.hastane.HastaneAdi;
			_context.Update(_poliklinik);
			_context.SaveChanges();
			return Ok(_poliklinik);
		}

		// DELETE api/<HastaneApiController>/5
		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			var poliklinik = _context.Polikliniks.Include(x => x.hastane).FirstOrDefault(x => x.PoliklinikId == id);
			_context.Polikliniks.Remove(poliklinik);
			_context.SaveChanges();
			return Ok(poliklinik);
		}
	}
}