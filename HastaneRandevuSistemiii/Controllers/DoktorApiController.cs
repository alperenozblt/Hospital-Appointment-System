
using HastaneRandevuSistemiii.Data;
using HastaneRandevuSistemiii.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HastaneRandevuSistemiii.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DoktorApiController : ControllerBase
	{
		private readonly HastaneRandevuuContext _context;

		public DoktorApiController(HastaneRandevuuContext context)
		{
			_context = context;
		}
		// GET: api/<DoktorApiController>
		[HttpGet]
		public IEnumerable<Doktor> Get()
		{
			return _context.Doktors.ToList();
		}

		// GET api/<DoktorApiController>/5
		[HttpGet("{id}")]
		public IActionResult Get(int id)
		{
			var doktor = _context.Doktors.Where(x => x.DoktorId == id).FirstOrDefault();
			return Ok(doktor);
		}

		// POST api/<DoktorApiController>
		[HttpPost]
		public IActionResult Post([FromBody] Doktor doktor)
		{
			_context.Doktors.Add(doktor);
			_context.SaveChanges();
			return Ok(doktor);
		}

		// PUT api/<DoktorApiController>/5
		[HttpPut("{id}")]
		public IActionResult Put(int id, [FromBody] Doktor doktor)
		{
			var _doktor = _context.Doktors.FirstOrDefault(x => x.DoktorId == id);
			_doktor.PoliklinikId = doktor.PoliklinikId;
			_doktor.DoktorAdi = doktor.DoktorAdi;
			_doktor.DoktorSoyadi = doktor.DoktorSoyadi;
			_context.Doktors.Update(_doktor);
			_context.SaveChanges();
			return Ok(_doktor);
		}

		// DELETE api/<DoktorApiController>/5
		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			var doktor = _context.Doktors.Where(x => x.DoktorId == id).FirstOrDefault();
			_context.Doktors.Remove(doktor);
			_context.SaveChanges();
			return Ok();
		}
	}
}
