using Microsoft.EntityFrameworkCore;
using WAW.API.Job.Domain.Models;
using WAW.API.Shared.Extensions;

namespace WAW.API.Job.Persistence.Contexts;

public class AppDbContext : DbContext{
  private DbSet<Offer>? offer;

  public DbSet<Offer> Offer {
    get => GetContext(offer);
    set => offer = value;
  }

  public AppDbContext(DbContextOptions options) : base(options) {}

  protected override void OnModelCreating(ModelBuilder builder) {
    base.OnModelCreating(builder);

    var offerEntity = builder.Entity<Offer>();
    offerEntity.ToTable("Offer");
    offerEntity.HasKey(p => p.Id);
    offerEntity.Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
    offerEntity.Property(p => p.Title).IsRequired().HasMaxLength(200);
    offerEntity.Property(p => p.Image).HasMaxLength(500);
    offerEntity.Property(p => p.Description).IsRequired();
    offerEntity.Property(p => p.SalaryRange).IsRequired().HasMaxLength(400);
    offerEntity.Property(p => p.Status).IsRequired();

    builder.UseSnakeCase();
  }

  private static T GetContext<T>(T? ctx) {
    if (ctx == null) throw new NullReferenceException();
    return ctx;
  }
}
