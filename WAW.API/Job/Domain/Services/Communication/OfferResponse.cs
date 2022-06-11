using WAW.API.Job.Domain.Models;
using WAW.API.Shared.Domain.Service.Communication;

namespace WAW.API.Job.Domain.Services.Communication;

public class OfferResponse : BaseResponse<Offer> {
  public OfferResponse(string message) : base(message) {}
  public OfferResponse(Offer resource) : base(resource) {}
}
