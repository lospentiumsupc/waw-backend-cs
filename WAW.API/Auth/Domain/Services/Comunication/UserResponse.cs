using WAW.API.Auth.Domain.Models;
using WAW.API.Shared.Domain.Service.Communication;

namespace WAW.API.Auth.Resources;

public class UserResponse : BaseResponse<User> {
  public UserResponse(string message) : base(message) {}
  public UserResponse(User resource) : base(resource) {}
}
