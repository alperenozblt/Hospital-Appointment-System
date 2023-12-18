using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Round1.Models
{
	public class Poliklinik
	{
		public int Id { get; set; }
		[Required]
		public string Adi { get; set; }
		[ForeignKey("AnaBilimDaliId")]
		public int AnaBilimDaliId { get; set; }
		ICollection<Doktor>? Doktor { get; set;}
	}

}
