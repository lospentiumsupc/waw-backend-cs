using WAW.API.Auth.Resources;
using WAW.API.Shared.Domain.Service.Communication;

namespace WAW.API.Auth.Domain.Services.Communication;

public class AuthResponse : BaseResponse<AuthResource> {
  public AuthResponse(string message) : base(message) {}
  public AuthResponse(AuthResource resource) : base(resource) {}
}
