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
        ICollection<Poliklinik>? Poliklinikler { get; set; }
    }
}
