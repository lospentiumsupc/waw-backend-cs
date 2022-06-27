using WAW.API.Subscription.Domain.Models;

namespace WAW.API.Subscription.Domain.Services.Communication;

public interface IPromotionService {
  Task<IEnumerable<Promotion>> ListAll();
  Task<PromotionResponse> Create(Promotion promotion);
  Task<PromotionResponse> Update(long id, Promotion promotion);
  Task<PromotionResponse> Delete(long id);
  Task<IEnumerable<Promotion>> ListBySubscriptionPlanId(long subscriptionPlanId);
}
