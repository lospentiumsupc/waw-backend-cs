using AutoMapper;
using WAW.API.Auth.Domain.Models;
using WAW.API.Auth.Resources;

namespace WAW.API.Auth.Mapping;

public static class AuthResourceToModelProfile {
  public static void Register(IProfileExpression profile) {
    profile.CreateMap<UserCreateRequest, User>();
    profile.CreateMap<UserUpdateRequest, User>();
    profile.CreateMap<ExternalImageRequest, ExternalImage>();
    profile.CreateMap<UserEducationRequest, UserEducation>();
    profile.CreateMap<UserExperienceRequest, UserExperience>();
    profile.CreateMap<UserProjectsRequest, UserProjects>();
  }
}
