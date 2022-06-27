using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;

namespace WAW.API.Auth.Resources;

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
  public DateTime Birthdate { get; set; }

  [SwaggerSchema("User location (address, city or country)", Nullable = true)]
  public string Location { get; set; } = string.Empty;

  [SwaggerSchema("User biography", Nullable = true)]
  public string Biography { get; set; } = string.Empty;

  [SwaggerSchema("User abstract", Nullable = true)]
  public string About { get; set; } = string.Empty;

  [SwaggerSchema("ChatRoom identifier", Nullable = false)]
  public long ChatRoomId { get; set; }
}
