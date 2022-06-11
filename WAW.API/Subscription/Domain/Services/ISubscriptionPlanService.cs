using WAW.API.Subscription.Domain.Models;
using WAW.API.Subscription.Domain.Services.Communication;

namespace WAW.API.Subscription.Domain.Services;

public interface ISubscriptionPlanService {
  Task<IEnumerable<SubscriptionPlan>> ListAll();
  Task<SubscriptionPlanResponse> Create(SubscriptionPlan subscriptionPlan);
  Task<SubscriptionPlanResponse> Update(long id, SubscriptionPlan subscriptionPlan);
  Task<SubscriptionPlanResponse> Delete(long id);
}
