using Swashbuckle.AspNetCore.Annotations;

namespace WAW.API.Auth.Resources;

public class UserResource {
  [SwaggerSchema("User identifier", ReadOnly = true)]
  public long Id { get; set; }

  [SwaggerSchema("User fullname", Nullable = false)]
  public string FullName { get; set; } = string.Empty;

  [SwaggerSchema("User preferred name to use in the app", Nullable = false)]
  public string PreferredName { get; set; } = string.Empty;

  [SwaggerSchema("User email", Nullable = false)]
  public string Email { get; set; } = string.Empty;

  [SwaggerSchema("User birthdate", Nullable = false)]
  public DateTime Birthdate { get; set; }

  [SwaggerSchema("User location")]
  public string Location { get; set; } = string.Empty;

  [SwaggerSchema("User biography")]
  public string Biography { get; set; } = string.Empty;

  [SwaggerSchema("User abstract")]
  public string About { get; set; } = string.Empty;

  [SwaggerSchema("ChatRoom identifier")]
  public long ChatRoomId { get; set; }
}
