using Microsoft.EntityFrameworkCore;
using WAW.API.Subscription.Domain.Models;
using WAW.API.Subscription.Domain.Repositories;
using WAW.API.Subscription.Persistence.Contexts;

namespace WAW.API.Subscription.Persistence.Respositories;

public class SubscriptionPlanRepository: BaseRepository,ISubscriptionPlanRepository  {
  public SubscriptionPlanRepository(AppDbContext context) : base(context) {}

  public async Task<IEnumerable<SubscriptionPlan>> ListAll() {
    return await context.SubscriptionPlans.ToListAsync();
  }

  public async Task Add(SubscriptionPlan subscriptionPlan) {
    await context.SubscriptionPlans.AddAsync(subscriptionPlan);
  }

  public async Task<SubscriptionPlan?> FindById(long id) {
    return await context.SubscriptionPlans.FindAsync(id);
  }

  public void Update(SubscriptionPlan subscriptionPlan) {
    context.SubscriptionPlans.Update(subscriptionPlan);
  }

  public void Remove(SubscriptionPlan subscriptionPlan) {
    context.SubscriptionPlans.Remove(subscriptionPlan);
  }
}
