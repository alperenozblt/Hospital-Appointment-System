using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace Round1.Models
{

	public class Randevu
	{
		public int Id { get; set; }
		public DateTime Tarih { get; set; }
		public TimeSpan Saat { get; set; }

		[ForeignKey("HastaId")]
		public int HastaId { get; set; }

		[ForeignKey("DoktorId")]
		public int DoktorId { get; set; }

	}

}
