using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HastaneSystem.Models
{
    public class HastaneSystemContext:IdentityDbContext
    {
        public DbSet<Hastane> Hastaneler { get; set; }
        public DbSet<Doktor> Doktorlar {  get; set; }
        public DbSet<Randevu> Randevular { get; set; }
        public DbSet<Admin> Adminler { get; set; }
       
        public DbSet<CalismaGunleri> CalismaGunleris { get; set; }

        public DbSet<Hasta> Hastalar { get; set; }
        public DbSet<Poliklinik> Poliklinik {  get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb; 
Database=HastaneSystem;Trusted_Connection=True;");
        }
       

    }
}
