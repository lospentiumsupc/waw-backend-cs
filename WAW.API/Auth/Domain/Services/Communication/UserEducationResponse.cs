using WAW.API.Auth.Domain.Models;
using WAW.API.Shared.Domain.Service.Communication;

namespace WAW.API.Auth.Domain.Services.Communication;

public class UserEducationResponse : BaseResponse<UserEducation> {
  public UserEducationResponse(string message) : base(message) {}
  public UserEducationResponse(UserEducation resource) : base(resource) {}
}
