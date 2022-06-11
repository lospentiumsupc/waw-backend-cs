using AutoMapper;
using WAW.API.Company.Resources;

namespace WAW.API.Company.Mapping;

using Domain.Models;

public class ModelToResourceProfile : Profile {
  public ModelToResourceProfile() {
    CreateMap<Company, CompanyResource>();
  }
}
