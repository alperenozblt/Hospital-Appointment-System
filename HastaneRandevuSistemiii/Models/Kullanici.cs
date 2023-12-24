using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace HastaneRandevuSistemiii.Models
{
    public class Kullanici:IdentityUser
    {
       
        public string KullaniciAd { get; set; }
      
        public string KullaniciSoyad { get; set; }


       
        [RegularExpression("^[1-9]{1}[0-9]{9}[02468]{1}$")]
        public string TcNo { get; set; }
        public ICollection<Randevu>? randevu { get; set; }

    }
}
