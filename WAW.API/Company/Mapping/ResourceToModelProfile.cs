using AutoMapper;
using WAW.API.Company.Resources;

namespace WAW.API.Company.Mapping;

using WAW.API.Company.Domain.Models;

public class ResourceToModelProfile: Profile {
  public ResourceToModelProfile() {
    CreateMap<CompanyRequest, Company>();
  }
}
