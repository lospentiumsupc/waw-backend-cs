using WAW.API.Subscription.Domain.Models;

namespace WAW.API.Subscription.Domain.Repositories;

public interface IPromotionRepository {
  Task<IEnumerable<Promotion>> ListAll();
  Task Add(Promotion promotion);
  Task<Promotion?> FindById(long id);
  void Update(Promotion promotion);
  void Remove(Promotion promotion);
  Task<IEnumerable<Promotion>> FindBySubscriptionPlanId(long id);

}
