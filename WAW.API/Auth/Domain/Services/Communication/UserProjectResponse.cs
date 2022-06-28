using WAW.API.Auth.Domain.Models;
using WAW.API.Shared.Domain.Service.Communication;

namespace WAW.API.Auth.Domain.Services.Communication;

public class UserProjectResponse : BaseResponse<UserProject> {
  public UserProjectResponse(string message) : base(message) {}
  public UserProjectResponse(UserProject resource) : base(resource) {}
}
