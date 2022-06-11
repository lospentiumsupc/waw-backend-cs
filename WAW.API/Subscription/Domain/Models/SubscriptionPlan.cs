using WAW.API.Shared.Domain.Model;

namespace WAW.API.Subscription.Domain.Models;

public class SubscriptionPlan : BaseModel{
  public long Id { get; set; }
  public string Name { get; set; }
  public float BasePrice { get; set; }

  //relations
  public IList<Promotion> Promotions { get; set; } = new List<Promotion>();

}
