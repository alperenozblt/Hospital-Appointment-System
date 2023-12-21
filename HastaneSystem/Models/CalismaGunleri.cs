using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HastaneSystem.Models
{
    public class CalismaGunleri
    {
       
            [Key]
            public int CalismaGünüId { get; set; }
            [Required]
            [MaxLength(7)]
            public string Günler { get; set; } //enum kullan
            [Required]
            public string Saatler { get; set; }

            [ForeignKey("DoktorId")]
            [Required]
            public int DoktorId { get; set; }
            

        
    }
}
