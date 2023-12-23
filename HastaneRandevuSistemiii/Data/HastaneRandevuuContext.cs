using HastaneRandevuSistemiii.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HastaneRandevuSistemiii.Data
{
    public class HastaneRandevuuContext : IdentityDbContext<Kullanici>
    {

        public HastaneRandevuuContext(DbContextOptions<HastaneRandevuuContext> option) : base(option)
        {

        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb; 
Database=HastaneRandevuu;Trusted_Connection=True;");
        }

        public DbSet<Hastane> Hastanes { get; set; }
        public DbSet<Doktor> Doktors { get; set; }
        public DbSet<Randevu> Randevus { get; set; }
        public DbSet<CalismaGunleri> CalismaGunlerii { get; set; }
      
        public DbSet<Poliklinik> Polikliniks { get; set; }



    }
}
