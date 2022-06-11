using Microsoft.EntityFrameworkCore;
using WAW.API.Job.Domain.Models;
using WAW.API.Shared.Extensions;
using WAW.API.Weather.Domain.Models;

namespace WAW.API.Weather.Persistence.Contexts;

public class AppDbContext : DbContext {
  private DbSet<Forecast>? forecasts;
  private DbSet<Offer>? offers;
  public DbSet<Forecast> Forecasts {
    get => GetContext(forecasts);
    set => forecasts = value;
  }

  public DbSet<Offer> Offers {
    get => GetContext(offers);
    set => offers = value;
  }

  public AppDbContext(DbContextOptions options) : base(options) {}

  protected override void OnModelCreating(ModelBuilder builder) {
    base.OnModelCreating(builder);

    var forecastEntity = builder.Entity<Forecast>();
    forecastEntity.ToTable("Forecasts");
    forecastEntity.HasKey(p => p.Id);
    forecastEntity.Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
    forecastEntity.Property(p => p.Date).IsRequired();
    forecastEntity.Property(p => p.TemperatureC).IsRequired();


    var offerEntity = builder.Entity<Offer>();
    offerEntity.ToTable("Offer");
    offerEntity.HasKey(p => p.Id);
    offerEntity.Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
    offerEntity.Property(p => p.Title).IsRequired().HasMaxLength(200);
    offerEntity.Property(p => p.Image).IsRequired().HasMaxLength(500);
    offerEntity.Property(p => p.Description).IsRequired();
    offerEntity.Property(p => p.Status).IsRequired();


    builder.UseSnakeCase();
  }

  private static T GetContext<T>(T? ctx) {
    if (ctx == null) throw new NullReferenceException();
    return ctx;
  }
}
