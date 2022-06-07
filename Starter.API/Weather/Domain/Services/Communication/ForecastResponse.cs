using WAW.API.Shared.Domain.Service.Communication;
using WAW.API.Weather.Domain.Models;

namespace WAW.API.Weather.Domain.Services.Communication;

public class ForecastResponse : BaseResponse<Forecast> {
  public ForecastResponse(string message) : base(message) {}
  public ForecastResponse(Forecast resource) : base(resource) {}
}
