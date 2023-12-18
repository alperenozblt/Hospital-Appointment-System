using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Round1.Models
{
	public class AnaBilimDali
	{
		[Key]
		public int Id { get; set; }
		[Required]
		public string Adi { get; set; }
		[ForeignKey("HastaneId")]
		public int HastaneId { get; set; }
		public ICollection<Poliklinik>? Poliklinik { get; set; }
	}
}
