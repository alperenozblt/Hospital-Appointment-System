using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace HastaneRandevuSistemiii.Models
{
    public class Kullanici:IdentityUser<int>
    {
       


        public string KullaniciAdi { get; set; }
        [MaxLength(100)]
        public string KullaniciSoyadi { get; set; }
        public int DogumYili { get; set; }
        [RegularExpression("^[1-9]{1}[0-9]{9}[02468]{1}$")]
        public string TcNo { get; set; }



        ICollection<Randevu>? Randevular { get; set; }
    }
}
