using System.ComponentModel.DataAnnotations;

namespace WAW.API.Subscription.Resource;

public class SubscriptionPlanRequest {
  [Required]
  public string Name { get; set; }
  public float BasePrice { get; set; }
}
