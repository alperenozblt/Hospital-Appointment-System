using System.ComponentModel.DataAnnotations;
using static HastaneSystem.Models.CalismaGunleri;
using System.ComponentModel.DataAnnotations.Schema;

namespace HastaneSystem.Models
{
    public class Doktor
    {
        public int DoktorId { get; set; }
        [Required]
        [MaxLength(100)]
        public string DoktorAdi { get; set; }
        [Required]
        [MaxLength(100)]
        public string DoktorSoyadi{ get; set;}

        [Required]
        [ForeignKey("PoliklinikId")]
        public int PoliklinikId { get; set; }
        public bool? IsActive { get; set; }
        ICollection<CalismaGunleri>? CalismaGunu { get; set; }
        ICollection<Randevu>? Randevular { get; set; }


    }
}
