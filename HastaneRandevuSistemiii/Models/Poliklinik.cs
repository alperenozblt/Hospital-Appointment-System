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
        
        public int HastaneId { get; set; }

        public Hastane? hastane { get; set; }

       
    }
}
