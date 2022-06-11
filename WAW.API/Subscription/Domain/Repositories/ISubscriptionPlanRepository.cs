using WAW.API.Subscription.Domain.Models;

namespace WAW.API.Subscription.Domain.Repositories;

public interface ISubscriptionPlanRepository {
  Task<IEnumerable<SubscriptionPlan>> ListAll();
  Task Add(SubscriptionPlan subscriptionPlan);
  Task<SubscriptionPlan?> FindById(long id);
  void Update(SubscriptionPlan subscriptionPlan);
  void Remove(SubscriptionPlan subscriptionPlan);
}
