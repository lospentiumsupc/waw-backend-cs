using WAW.API.Shared.Domain.Model;

namespace WAW.API.Subscription.Domain.Models;

public class Promotion: BaseModel {
  public long Id { get; set; }
  public string Name { get; set; }
  public DateTime Date { get; set; }

  //relations
  public long SubscriptionId { get; set; }
  public SubscriptionPlan SubscriptionPlan { get; set; }

}
