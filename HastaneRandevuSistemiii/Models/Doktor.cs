using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HastaneRandevuSistemiii.Models
{
    public class Doktor
    {
        public int DoktorId { get; set; }
        [Required]
        [MaxLength(100)]
        public string DoktorAdi { get; set; }
        [Required]
        [MaxLength(100)]
        public string DoktorSoyadi { get; set; }

        [Required]
        [ForeignKey("PoliklinikId")]
        public int PoliklinikId { get; set; }
        [Required]
        [ForeignKey("HastaneId")]
        public bool? IsActive { get; set; }
        ICollection<CalismaGunleri>? CalismaGunu { get; set; }
        ICollection<Randevu>? Randevular { get; set; }
    }
}
