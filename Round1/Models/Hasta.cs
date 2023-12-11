using System.ComponentModel.DataAnnotations;

namespace Round1.Models
{
	public class Hasta
	{
		public int Id { get; set; }
		[Required]
		public string Adı { get; set; }
		[Required]
		public string Soyadi { get; set; }
		[Required]
		[RegularExpression("^[1-9]{1}[0-9]{9}[02468]{1}$")]
		public long TCKimlikNumarası { get; set; }
		[Phone(ErrorMessage = "Geçerli bir telefon numarası giriniz. ")]
		public string TelefonNumarası { get; set; }

		[Required]
		[RegularExpression("^([A-Z0-9_.-@#$%^&()<>/?])([a-z0-9_.-@#$%^&()<>/?])([0-9])*$")]
		public string HastaPassword { get; set; }
		[Required]
		public int DogumYılı { get; set; }

		public ICollection<Randevu> Randevu { get; set; }

	}
}
