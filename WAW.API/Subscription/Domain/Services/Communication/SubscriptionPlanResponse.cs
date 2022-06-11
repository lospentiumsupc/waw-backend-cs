using WAW.API.Shared.Domain.Service.Communication;
using WAW.API.Subscription.Domain.Models;

namespace WAW.API.Subscription.Domain.Services.Communication;

public class SubscriptionPlanResponse : BaseResponse<SubscriptionPlan> {
  public SubscriptionPlanResponse(string message) : base(message) {}
  public SubscriptionPlanResponse(SubscriptionPlan resource) : base(resource) {}
}
