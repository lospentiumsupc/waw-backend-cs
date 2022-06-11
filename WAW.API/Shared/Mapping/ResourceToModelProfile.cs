using AutoMapper;
using WAW.API.Auth.Mapping;
using WAW.API.Company.Mapping;
using WAW.API.Job.Mapping;

namespace WAW.API.Shared.Mapping;

public class ResourceToModelProfile : Profile {
  public ResourceToModelProfile() {
    AuthResourceToModelProfile.Register(this);
    CompanyResourceToModelProfile.Register(this);
    JobResourceToModelProfile.Register(this);
  }
}
