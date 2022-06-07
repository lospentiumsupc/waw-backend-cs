using AutoMapper;
using WAW.API.Weather.Domain.Models;
using WAW.API.Weather.Resources;

namespace WAW.API.Weather.Mapping;

public class ModelToResourceProfile : Profile {
  public ModelToResourceProfile() {
    CreateMap<Forecast, ForecastResource>();
  }
}
