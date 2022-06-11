using AutoMapper;
using WAW.API.Auth.Domain.Models;
using WAW.API.Auth.Resources;

namespace WAW.API.Auth.Mapping;

public class ResourceToModelProfile : Profile {
  public ResourceToModelProfile() {
    CreateMap<UserRequest, User>();
  }
}
