using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WAW.API.Auth.Domain.Models;
using WAW.API.Shared.Domain.Service.Communication;

namespace WAW.API.Auth.Authorization.Attributes;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class AuthorizeAttribute : Attribute, IAuthorizationFilter {
  public void OnAuthorization(AuthorizationFilterContext context) {
    var allowAnonymous = context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any();

    if (allowAnonymous) return;

    var user = (User?) context.HttpContext.Items["User"];
    if (user is not null) return;

    var body = new ErrorResponse("Unauthorized");
    context.Result = new JsonResult(body) {StatusCode = StatusCodes.Status401Unauthorized,};
  }
}
