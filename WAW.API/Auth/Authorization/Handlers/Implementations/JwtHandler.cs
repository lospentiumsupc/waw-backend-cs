using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using WAW.API.Auth.Authorization.Handlers.Interfaces;
using WAW.API.Auth.Authorization.Settings;
using WAW.API.Auth.Domain.Models;

namespace WAW.API.Auth.Authorization.Handlers.Implementations;

public class JwtHandler : IJwtHandler {
  private readonly AuthSettings authSettings;

  public JwtHandler(IOptions<AuthSettings> authSettings) {
    this.authSettings = authSettings.Value;
  }

  public string GenerateToken(User user) {
    var key = Encoding.ASCII.GetBytes(authSettings.Secret);
    var tokenDescriptor = new SecurityTokenDescriptor {
      Subject =
        new ClaimsIdentity(
          new[] {new Claim(ClaimTypes.Sid, user.Id.ToString()), new Claim(ClaimTypes.Email, user.Email),}
        ),
      Expires = DateTime.UtcNow.AddDays(7),
      SigningCredentials =
        new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature),
    };
    var tokenHandler = new JwtSecurityTokenHandler();
    var token = tokenHandler.CreateToken(tokenDescriptor);
    return tokenHandler.WriteToken(token);
  }

  public long? ValidateToken(string token) {
    if (string.IsNullOrEmpty(token)) return null;

    var tokenHandler = new JwtSecurityTokenHandler();
    var key = Encoding.ASCII.GetBytes(authSettings.Secret);

    try {
      var parameters = new TokenValidationParameters {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false,
        ClockSkew = TimeSpan.Zero,
      };
      tokenHandler.ValidateToken(token, parameters, out var validatedToken);
      var jwtToken = (JwtSecurityToken) validatedToken;
      var userId = int.Parse(jwtToken.Claims.First(claim => claim.Type == ClaimTypes.Sid).Value);
      return userId;
    } catch (Exception e) {
      Log.Error(e, "An error occurred while validating a token");
      return null;
    }
  }
}
