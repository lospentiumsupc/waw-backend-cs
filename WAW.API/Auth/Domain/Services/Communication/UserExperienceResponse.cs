using WAW.API.Auth.Domain.Models;
using WAW.API.Shared.Domain.Service.Communication;

namespace WAW.API.Auth.Domain.Services.Communication;

public class UserExperienceResponse : BaseResponse<UserExperience> {
  public UserExperienceResponse(string message) : base(message) {}
  public UserExperienceResponse(UserExperience resource) : base(resource) {}
}
