using System.ComponentModel.DataAnnotations;

namespace WAW.API.Subscription.Resource;

public class PromotionRequest {
  [Required]
  [MaxLength(20)]
  public string Name { get; set; }
  [Required]
  public DateTime Date { get; set; }
}
