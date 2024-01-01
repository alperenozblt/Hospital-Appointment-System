using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace HastaneRandevuSistemiii.Models
{
    public class Poliklinik
    {
        public int PoliklinikId { get; set; }
        [Required]
        [MaxLength(100)]
        public string? PoliklinikAdi { get; set; }
        
        public int HastaneId { get; set; }

        [JsonIgnore]
        public Hastane? hastane { get; set; }

		public List<Doktor>? Doktor { get; set; }

	}
}
