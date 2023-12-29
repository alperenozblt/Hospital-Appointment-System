using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HastaneRandevuSistemiii.Models
{
    public class Randevu
    {
        public int RandevuID { get; set; }
  
        public int DoktorId { get; set; }

        public string KullaniciId { get; set; }
   
        public int HastaneId { get; set; }
        
        public int PoliklinikId { get; set; }

        public Doktor? Doktor { get; set;}

        [DataType(DataType.Date), Display(Name = "Randevu Tarihi"), DisplayFormat(DataFormatString = "{0:dd-MM-yyyy HH:mm}", ApplyFormatInEditMode = true)]
        [Required]
        
        public DateTime RandevuTarih { get; set; }

      
    }
}
