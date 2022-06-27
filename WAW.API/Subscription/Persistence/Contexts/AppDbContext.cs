using Microsoft.EntityFrameworkCore;
using WAW.API.Shared.Extensions;
using WAW.API.Subscription.Domain.Models;

namespace WAW.API.Subscription.Persistence.Contexts;

public class AppDbContext: DbContext {

  private DbSet<SubscriptionPlan>? subscriptionPlans;

  public DbSet<SubscriptionPlan> SubscriptionPlans {
    get => GetContext(subscriptionPlans);
    set => subscriptionPlans = value;
  }

  public AppDbContext(DbContextOptions options) : base(options) {}

  protected override void OnModelCreating(ModelBuilder builder) {
    base.OnModelCreating(builder);

    var subscriptionPlanEntity = builder.Entity<SubscriptionPlan>();
    subscriptionPlanEntity.ToTable("Subscription Plan");
    subscriptionPlanEntity.HasKey(p => p.Id);
    subscriptionPlanEntity.Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
    subscriptionPlanEntity.Property(p => p.Name).IsRequired();
    subscriptionPlanEntity.Property(p => p.BasePrice).IsRequired();

    //relations
    subscriptionPlanEntity.HasMany(p => p.Promotions)
      .WithOne(p => p.SubscriptionPlan)
      .HasForeignKey(p => p.SubscriptionId);

    //definition of promotion
    var promotionEntity = builder.Entity<Promotion>();
    promotionEntity.ToTable("Promotion");
    promotionEntity.HasKey(p => p.Id);
    promotionEntity.Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
    promotionEntity.Property(p => p.Name).IsRequired();
    promotionEntity.Property(p => p.Date).IsRequired();


    builder.UseSnakeCase();
  }

  private static T GetContext<T>(T? ctx) {
    if (ctx == null) throw new NullReferenceException();
    return ctx;
  }

}
