using AutoMapper;
using WAW.API.Weather.Domain.Models;
using WAW.API.Weather.Resources;

namespace WAW.API.Weather.Mapping;

public class ResourceToModelProfile : Profile {
  public ResourceToModelProfile() {
    CreateMap<ForecastRequest, Forecast>();
  }
}
