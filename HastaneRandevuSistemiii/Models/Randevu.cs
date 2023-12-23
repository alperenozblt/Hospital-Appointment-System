using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HastaneRandevuSistemiii.Models
{
    public class Randevu
    {
        public int RandevuID { get; set; }

        [ForeignKey("DoktorId")]
        public int DoktorId { get; set; }

        [ForeignKey("KullaniciId")]
        public int KullaniciId { get; set; }
        [ForeignKey("HastaneId")]
        public int HastaneId { get; set; }
        [ForeignKey("PoliklinikId")]
        public int PoliklinikId { get; set; }

        [DataType(DataType.Date), Display(Name = "Randevu Tarihi"), DisplayFormat(DataFormatString = "{0:dd-MM-yyyy HH:mm}", ApplyFormatInEditMode = true)]
        [Required]
        public DateTime RandevuTarih { get; set; }
    }
}
