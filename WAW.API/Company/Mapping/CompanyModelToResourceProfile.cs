using AutoMapper;
using WAW.API.Company.Resources;

namespace WAW.API.Company.Mapping;

using Domain.Models;

public static class CompanyModelToResourceProfile {
  public static void Register(IProfileExpression profile) {
    profile.CreateMap<Company, CompanyResource>();
  }
}
