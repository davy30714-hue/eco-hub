using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Models;
using Microsoft.EntityFrameworkCore;


namespace Data.Context
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=LAPTOP-1J9VUMO8; Database=DbEcoStation; Integrated Security=True; Encrypt=False;");
            base.OnConfiguring(optionsBuilder);
        }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Employees> Employees => Set<Employees>();
        public DbSet<Equipment> Equipment => Set<Equipment>();
        public DbSet<Locations> Locations => Set<Locations>();
        public DbSet<Expeditions> Expeditions => Set<Expeditions>();
        public DbSet<ExpeditionReports> ExpeditionReports => Set<ExpeditionReports>();
        public DbSet<ExpeditionTeams> ExpeditionTeams => Set<ExpeditionTeams>();
        public DbSet<Measurements> Measurements => Set<Measurements>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Measurements>()
                .HasOne(m => m.Location)
                .WithMany()
                .HasForeignKey(m => m.LocationId)
                .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<Measurements>()
                .HasOne(m => m.Expedition)
                .WithMany()
                .HasForeignKey(m => m.ExpeditionId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Measurements>()
                .HasOne(m => m.Equipment)
                .WithMany()
                .HasForeignKey(m => m.EquipmentId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Measurements>()
                .HasOne(m => m.Employee)
                .WithMany()
                .HasForeignKey(m => m.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Equipment>()
                .HasOne(e => e.Employee)
                .WithMany(emp => emp.Equipment)
                .HasForeignKey(e => e.EmployeeId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
