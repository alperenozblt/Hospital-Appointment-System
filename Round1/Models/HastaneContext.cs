using Microsoft.EntityFrameworkCore;
using System.Transactions;

namespace Round1.Models
{
	public class HastaneContext : DbContext
	{
		public DbSet<Hastane> Hastanes { get; set; }
		public DbSet<AnaBilimDali> AnaBilimDalis { get; set; }
		public DbSet<Poliklinik> Polikliniks { get; set; }
		public DbSet<Doktor> Doktors { get; set; }
		public DbSet<Hasta> Hastas { get; set; }
		public DbSet<Randevu> Randevus { get; set; }
		public DbSet<Admin> Admins { get; set; }
		public DbSet<DoktorIzinGunu> DoktorIzinGunus { get; set; }
		
		protected override void	OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;
						    Database=HastaneRS; Trusted_Connection = True;");
		}


	}
}
