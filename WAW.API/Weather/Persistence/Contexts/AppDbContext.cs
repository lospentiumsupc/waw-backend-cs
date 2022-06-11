using Microsoft.EntityFrameworkCore;
using WAW.API.Auth.Domain.Models;
using WAW.API.Shared.Extensions;
using WAW.API.Weather.Domain.Models;

namespace WAW.API.Weather.Persistence.Contexts;

using WAW.API.Company.Domain.Models;

public class AppDbContext : DbContext {
  private DbSet<Forecast>? forecasts;
  private DbSet<User>? users;
  private DbSet<Company>? companies;

  public DbSet<Forecast> Forecasts {
    get => GetContext(forecasts);
    set => forecasts = value;
  }

  public DbSet<User> Users {
    get => GetContext(users);
    set => users = value;
  }

  public DbSet<Company> Companies {
    get => GetContext(companies);
    set => companies = value;
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

    var userEntity = builder.Entity<User>();
    userEntity.ToTable("Users");
    userEntity.HasKey(p => p.Id);
    userEntity.Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
    userEntity.Property(p => p.FullName).IsRequired().HasMaxLength(256);
    userEntity.Property(p => p.PreferredName).IsRequired().HasMaxLength(256);
    userEntity.Property(p => p.Email).IsRequired().HasMaxLength(256);
    userEntity.Property(p => p.Birthdate).IsRequired();

    var companyEntity = builder.Entity<Company>();
    companyEntity.ToTable("Companies");
    companyEntity.HasKey(p => p.Id);
    companyEntity.Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
    companyEntity.Property(p => p.Name).IsRequired().HasMaxLength(100);
    companyEntity.Property(p => p.Address).HasMaxLength(256);
    companyEntity.Property(p => p.Email).IsRequired().HasMaxLength(256);

    builder.UseSnakeCase();
  }

  private static T GetContext<T>(T? ctx) {
    if (ctx == null) throw new NullReferenceException();
    return ctx;
  }
}
