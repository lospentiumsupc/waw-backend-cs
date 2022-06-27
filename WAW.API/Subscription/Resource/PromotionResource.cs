namespace WAW.API.Subscription.Resource;

public class PromotionResource {
  public long Id { get; set; }
  public string Name { get; set; }
  public DateTime Date { get; set; }


  public SubscriptionPlanResource SubscriptionPlan { get; set; }
}
