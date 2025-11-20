using IrteyaTestTask.UI.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace IrteyaTestTask.UI.Infrastructure;

public class WeatherDbContext : DbContext
{
    public DbSet<WeatherForecast> Weather { get; set; } = null!;

    public WeatherDbContext() { }

    public WeatherDbContext(DbContextOptions<WeatherDbContext> options)
        : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlite("Data Source=weather.db");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<WeatherForecast>().HasKey(x => x.Date);
        modelBuilder.Entity<WeatherForecast>().Property(x => x.Summary).HasMaxLength(100);
    }
}
