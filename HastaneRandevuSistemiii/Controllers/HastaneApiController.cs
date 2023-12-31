using HastaneRandevuSistemiii.Data;
using HastaneRandevuSistemiii.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hastane_Randevu_Sistemi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class HastaneApiController : ControllerBase
	{
		private readonly HastaneRandevuuContext _context;

		public HastaneApiController(HastaneRandevuuContext context)
		{
			_context = context;
		}


		// GET: api/<HastaneApiController>
		[HttpGet]
		public IEnumerable<Hastane> Get()
		{
			var hastaneler = _context.Hastanes.ToList();
			return hastaneler;
		}

		// GET api/<HastaneApiController>/5
		[HttpGet("{id}")]
		public IActionResult Get(int id)
		{
			var hastane = _context.Hastanes.Include(x => x.Polikliniks).FirstOrDefault(x => x.HastaneId == id);

			return Ok(hastane);
		}

		// POST api/<HastaneApiController>
		[HttpPost]
		public IActionResult Post([FromBody] Hastane hastane)
		{
			_context.Hastanes.Add(hastane);
			_context.SaveChanges();
			return Ok(hastane);
		}

		// PUT api/<HastaneApiController>/5
		[HttpPut("{id}")]
		public IActionResult Put(int id, [FromBody] Hastane hastane)
		{
			var _hastane = _context.Hastanes.FirstOrDefault(x => x.HastaneId == id);
			_hastane.HastaneAdi = hastane.HastaneAdi;
			_context.Update(_hastane);
			_context.SaveChanges();
			return Ok(_hastane);
		}

		// DELETE api/<HastaneApiController>/5
		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			var hastane = _context.Hastanes.Include(x => x.Polikliniks).FirstOrDefault(x => x.HastaneId == id);
			_context.Hastanes.Remove(hastane);
			_context.SaveChanges();
			return Ok(hastane);
		}
	}
}