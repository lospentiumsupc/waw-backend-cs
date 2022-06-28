using WAW.API.Auth.Authorization.Middleware;

namespace WAW.API.Auth.Extensions;

public static class JwtMiddlewareExtensions {
  public static IApplicationBuilder UseJwtMiddleware(this IApplicationBuilder builder) {
    return builder.UseMiddleware<JwtMiddleware>();
  }
}
