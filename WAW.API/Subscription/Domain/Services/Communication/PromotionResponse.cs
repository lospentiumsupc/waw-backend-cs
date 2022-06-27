using WAW.API.Shared.Domain.Service.Communication;
using WAW.API.Subscription.Domain.Models;

namespace WAW.API.Subscription.Domain.Services.Communication;

public class PromotionResponse: BaseResponse<Promotion> {
  public PromotionResponse(string message) : base(message) {}
  public PromotionResponse(Promotion resource) : base(resource) {}
}
