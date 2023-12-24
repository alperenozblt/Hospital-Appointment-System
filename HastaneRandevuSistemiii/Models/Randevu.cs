using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HastaneRandevuSistemiii.Models
{
    public class Randevu
    {
        public int RandevuID { get; set; }

      
        public int DoktorId { get; set; }

        public int KullaniciId { get; set; }
   
        public int HastaneId { get; set; }
        
        public int PoliklinikId { get; set; }

        [DataType(DataType.Date), Display(Name = "Randevu Tarihi"), DisplayFormat(DataFormatString = "{0:dd-MM-yyyy HH:mm}", ApplyFormatInEditMode = true)]
        [Required]
        public DateTime RandevuTarih { get; set; }
    }
}
