using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Round1.Models
{
	public class Doktor
	{
		[Key]
		public int Id { get; set; }
		[Required]
		public string Adi { get; set; }
		[Required]
		public string Soyadi { get; set; }

		[ForeignKey("PoliklinikId")]
		public int PoliklinikId { get; set; }
		
		public ICollection<DoktorIzinGunu>? DoktorIzinGunu { get; set; }
		public ICollection<Randevu>? Randevu { get; set; }



		//public DateTimeRange IzinliDonemi { get; set; }
	}

}
