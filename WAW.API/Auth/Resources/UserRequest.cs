using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;

namespace WAW.API.Auth.Resources;

[SwaggerSchema(Required = new[]{"FullName", "PreferredName", "Email", "Birthdate", "Location",})]
public class UserRequest {
  [SwaggerSchema("User fullname", Nullable = false)]
  [Required]
  public string FullName { get; set; } = string.Empty;

  [SwaggerSchema("User preferred name to use in the app", Nullable = false)]
  [Required]
  public string PreferredName { get; set; } = string.Empty;

  [SwaggerSchema("User email", Nullable = false)]
  [Required]
  public string Email { get; set; } = string.Empty;

  [SwaggerSchema("User birthdate", Nullable = false)]
  [Required]
  public DateOnly Birthdate { get; set; }

  [SwaggerSchema("User location (address, city or country)", Nullable = false)]
  [Required]
  public string Location { get; set; } = string.Empty;

  [SwaggerSchema("User biography", Nullable = true)]
  public string Biography { get; set; } = string.Empty;

  [SwaggerSchema("User abstract", Nullable = true)]
  public string About { get; set; } = string.Empty;
}
