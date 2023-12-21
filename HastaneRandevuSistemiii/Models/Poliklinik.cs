using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HastaneRandevuSistemiii.Models
{
    public class Poliklinik
    {
        public int PoliklinikId { get; set; }
        [Required]
        [MaxLength(100)]
        public string? PoliklinikAdi { get; set; }
        [ForeignKey("HastaneId")]
        [Required]
        public int HastaneId { get; set; }

        ICollection<Doktor>? Doktorlar { get; set; }
    }
}
