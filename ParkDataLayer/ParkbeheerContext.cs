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
        //
    }
}
