using IrteyaTestTask.UI.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace IrteyaTestTask.UI.Infrastructure;

public class WeatherDbContext : DbContext
{
    public DbSet<WeatherForecast> Weather { get; set; } = null!;

    public WeatherDbContext() { }

    public WeatherDbContext(DbContextOptions<WeatherDbContext> options)
        : base(options) { Database.EnsureCreated(); }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlite("Data Source=weather.db");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // фиксированное зерно
        var rnd = new Random(1234);

        var data = Enumerable.Range(1, 5).Select(i => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.UtcNow.AddDays(i)),
            TemperatureC = rnd.Next(-20, 35),
            Summary = "Sunny"
        }).ToList();

        modelBuilder.Entity<WeatherForecast>().HasKey(x => x.Date);
        modelBuilder.Entity<WeatherForecast>().Property(x => x.Summary).HasMaxLength(100);

        modelBuilder.Entity<WeatherForecast>().HasData(data);
    }
}
