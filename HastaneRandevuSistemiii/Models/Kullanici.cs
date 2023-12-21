using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace HastaneRandevuSistemiii.Models
{
    public class Kullanici:IdentityUser
    {
    ICollection<Randevu>? Randevular { get; set; }
    }
}
