using AutoMapper;
using WAW.API.Auth.Domain.Models;
using WAW.API.Auth.Resources;

namespace WAW.API.Auth.Mapping;

public static class AuthModelToResourceProfile {
  public static void Register(IProfileExpression profile) {
    profile.CreateMap<User, UserResource>();
    profile.CreateMap<User, AuthResource>();
    profile.CreateMap<ExternalImage, ExternalImageResource>();
  }
}
