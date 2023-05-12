using Microsoft.EntityFrameworkCore;
using ParkDataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkDataLayer;

public class ParkbeheerContext : DbContext
{
    private string connectionString;

    public DbSet<HuisEF> Huizen { get; set; }
    public DbSet<HuurcontractEF> Huurcontracten { get; set; }
    public DbSet<HuurderEF> Huurders { get; set; }
    public DbSet<ParkEF> Parken { get; set; }

    public ParkbeheerContext(string connectionString)
    {
        this.connectionString = connectionString;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(connectionString).LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.Entity<HuisEF>()
        //    .Property(h => h.Id)
        //    .ValueGeneratedOnAdd();
        //modelBuilder.Entity<HuisEF>()
        //    .HasOne(h=>h.Park)
        //    .WithMany(p=>p.Huizen)
        //    .HasForeignKey(h => h.ParkId)
        //    .OnDelete(DeleteBehavior.Restrict);
        //modelBuilder.Entity<HuurderEF>()
        //    .HasMany(h=>h.Huurcontracten)
        //    .WithOne(hc=>hc.Huurder)
        //    .HasForeignKey(h=>h.HuurderId) 
        //    .OnDelete(DeleteBehavior.Restrict);
        //modelBuilder.Entity<HuisEF>()
        //    .HasMany(h=>h.Huurcontracten)
        //    .WithOne(hc=>hc.Huis)
        //    .HasForeignKey(h=>h.HuisId) 
        //    .OnDelete(DeleteBehavior.Restrict);
    }
}
