using AutoMapper;
using WAW.API.Employers.Resources;

namespace WAW.API.Employers.Mapping;

using Domain.Models;

public static class CompanyResourceToModelProfile {
  public static void Register(IProfileExpression profile) {
    profile.CreateMap<CompanyRequest, Company>();
  }
}
