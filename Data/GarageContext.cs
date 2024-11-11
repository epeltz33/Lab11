// GarageContext.cs

using Lab11.Models;
using Microsoft.EntityFrameworkCore;

public class GarageContext : DbContext
{
    private static string DbPath => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "garage.db");

    public DbSet<Vehicle> Vehicles { get; set; }
    public DbSet<Car> Cars { get; set; }
    public DbSet<Motorcycle> Motorcycles { get; set; }
    public DbSet<Bicycle> Bicycles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Using SQLite as the database provider with explicit path
        var connectionString = $"Data Source={DbPath}";
        Console.WriteLine($"Database path: {DbPath}");
        optionsBuilder.UseSqlite(connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure TPH (Table-per-Hierarchy) inheritance
        modelBuilder.Entity<Vehicle>()
            .HasDiscriminator<string>("VehicleType")
            .HasValue<Car>("Car")
            .HasValue<Motorcycle>("Motorcycle")
            .HasValue<Bicycle>("Bicycle");
    }
}