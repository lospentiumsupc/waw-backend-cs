using AutoMapper;
using WAW.API.Employers.Resources;

namespace WAW.API.Employers.Mapping;

using Domain.Models;

public static class CompanyModelToResourceProfile {
  public static void Register(IProfileExpression profile) {
    profile.CreateMap<Company, CompanyResource>();
  }
}
