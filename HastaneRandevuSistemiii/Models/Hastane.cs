using System.ComponentModel.DataAnnotations;

namespace HastaneRandevuSistemiii.Models
{
    public class Hastane
    {
        public int HastaneId { get; set; }
        [Required]
        [MaxLength(100)]
        [Display(Name = "Hastane Adı")]
        public string HastaneAdi { get; set; }
		[Required]
		[MaxLength(300)]
		[Display(Name = "Hastane Adresi")]
		public string HastaneAddress { get; set; }
		[Required]
		[RegularExpression(@"^(0)(2|3|4|8|9)([0-9]{2})-([0-9]{3})-([0-9]{2})-([0-9]{2})$", ErrorMessage = "Telefon numarası istenilen formatta değil. Lütfen '0212-333-44-55' gibi girin aralarında tire de kullanılacak")]
		[Display(Name = "Hastane Telefon Numarası")]
		public string HastaneTel { get; set; }



	}
}
