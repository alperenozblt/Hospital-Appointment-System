using System.ComponentModel.DataAnnotations;

namespace HastaneSystem.Models
{
    public class Admin
    {
        
        public int AdminID { get; set; }
        [Required]
        [StringLength(100)]
        [Display(Name = "Kullanıcı Adı")]
        public string kullaniciAdi { get; set; }
        [Required]
        [MaxLength(50)]
        [MinLength(8)]
        [Display(Name = "Şifre")]
        
        public string sifre { get; set; }
       
    }
}
