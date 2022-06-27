using Microsoft.EntityFrameworkCore;
using WAW.API.Subscription.Domain.Models;
using WAW.API.Subscription.Domain.Repositories;
using WAW.API.Subscription.Persistence.Contexts;

namespace WAW.API.Subscription.Persistence.Respositories;

public class PromotionRepository: BaseRepository, IPromotionRepository {
  public PromotionRepository(AppDbContext context) : base(context) {}

  public async Task<IEnumerable<Promotion>> ListAll() {
    return await context.Promotions.Include(p => p.SubscriptionPlan).ToListAsync();
  }

  public async Task Add(Promotion promotion) {
    await context.Promotions.AddAsync(promotion);
  }

  public async Task<Promotion?> FindById(long id) {
    return await context.Promotions.FindAsync(id);
  }

  public void Update(Promotion promotion) {
    context.Promotions.Update(promotion);
  }

  public void Remove(Promotion promotion) {
    context.Promotions.Remove(promotion);
  }

  public async  Task<IEnumerable<Promotion>> FindBySubscriptionPlanId(long id) {
    return await context.Promotions
      .Where(p => p.SubscriptionId == id)
      .Include(p => p.SubscriptionPlan)
      .ToListAsync();
  }




}
