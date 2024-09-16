using BMW_GarageWebApi.Domain.Enum;
using BMW_GarageWebApi.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BMW_GarageWebApi.DAL.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<CarRecord> CarRecords { get; set; }
        public DbSet<CarRepair> CarRepairs { get; set; }     
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>().Property(x => x.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<CarRecord>().Property(x => x.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<CarRepair>().Property(x => x.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<Employee>().Property(s => s.Gender).HasConversion(v => v.ToString(), v => (Gender)Enum.Parse(typeof(Gender), v.ToString()));
            modelBuilder.Entity<CarRecord>().Property(s => s.StatusCarRecord).HasConversion(v => v.ToString(), v => (StatusCarRecord)Enum.Parse(typeof(StatusCarRecord), v.ToString()));

            modelBuilder.Entity<CarRecord>().HasData(DataForTableDB.CreateCarRecord());
            modelBuilder.Entity<CarRepair>().HasData(DataForTableDB.CreateCarRepair());
            modelBuilder.Entity<Employee>().HasData(DataForTableDB.CreateEmployee());
        }

    }
}
