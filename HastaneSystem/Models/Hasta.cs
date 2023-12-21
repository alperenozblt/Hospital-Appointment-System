using System.ComponentModel.DataAnnotations;

namespace HastaneSystem.Models
{
    public class Hasta
    {
        public int HastaId { get; set; }
        [Required]
        [MaxLength(1)]
        public string HastaAdi { get; set; }
        [Required]
        [MaxLength(100)]
        public string HastaSoyadi { get; set; }
        [Required]
        public int DogumYili { get; set; }
        [Required]
        [RegularExpression("^[1-9]{1}[0-9]{9}[02468]{1}$")]
        public string TcNo { get; set; }
        [Required]

        public string Sifre { get; set; }
      

        ICollection<Randevu>? Randevular { get; set; }
    }
}
