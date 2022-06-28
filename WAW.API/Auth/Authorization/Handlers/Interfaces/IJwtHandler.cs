using WAW.API.Auth.Domain.Models;

namespace WAW.API.Auth.Authorization.Handlers.Interfaces;

public interface IJwtHandler {
  string GenerateToken(User user);
  long? ValidateToken(string token);
}
