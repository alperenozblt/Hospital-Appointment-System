using System.ComponentModel.DataAnnotations;

namespace Round1.Models
{
	public class Hastane
	{
		public int Id { get; set; }
		[Required]
		public string Adı { get; set; }
		public string Adresi { get; set; }
		[Phone(ErrorMessage ="Geçerli bir numara giriniz. ")]
		public string TelefonNumarası { get; set; }

		ICollection<AnaBilimDali> AnaBilimDali { get;set; }
	}


}
