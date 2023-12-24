using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HastaneRandevuSistemiii.Models
{
    public class CalismaGunleri
    {
        [Key]
        public int CalismaGünüId { get; set; }
        [Required]
        public string Günler { get; set; } //enum kullan
        [Required]
        public string Saatler { get; set; }

        [ForeignKey("DoktorId")]
        [Required]
        public int DoktorId { get; set; }
        public Doktor Doktor { get; set;}
    }
}
