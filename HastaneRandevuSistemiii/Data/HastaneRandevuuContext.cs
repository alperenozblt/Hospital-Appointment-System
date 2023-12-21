using HastaneRandevuSistemiii.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HastaneRandevuSistemiii.Data
{
    public class HastaneRandevuuContext : IdentityDbContext
    {

        public HastaneRandevuuContext(DbContextOptions<HastaneRandevuuContext> option) : base(option)
        {

        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb; 
Database=HastaneRandevuu;Trusted_Connection=True;");
        }

        public DbSet<Hastane> Hastaneler { get; set; }
        public DbSet<Doktor> Doktorlar { get; set; }
        public DbSet<Randevu> Randevular { get; set; }
        public DbSet<CalismaGunleri> CalismaGunleris { get; set; }

        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<Poliklinik> Poliklinik { get; set; }



    }
}
