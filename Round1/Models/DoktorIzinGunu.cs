
using System.ComponentModel.DataAnnotations;

namespace Round1.Models
{
	public class DoktorIzinGunu
	{
		[Key]
		public int Id { get; set; }

		public DateTime BaslangıcTarih { get; set; }
		public DateTime BitisTarih { get; set; }
		public TimeSpan BaslangıcSaat { get; set; }
		public TimeSpan BitisSaat { get; set; }
	}
}
