using Swashbuckle.AspNetCore.Annotations;

namespace WAW.API.Auth.Resources;

public class UserResource {
  [SwaggerSchema("User identifier", Nullable = false, ReadOnly = true)]
  public long Id { get; set; }

  [SwaggerSchema("User fullname", Nullable = false)]
  public string FullName { get; set; } = string.Empty;

  [SwaggerSchema("User preferred name to use in the app", Nullable = false)]
  public string PreferredName { get; set; } = string.Empty;

  [SwaggerSchema("User email", Nullable = false)]
  public string Email { get; set; } = string.Empty;

  [SwaggerSchema("User location", Nullable = true)]
  public string? Location { get; set; }

  [SwaggerSchema("User profile view count", Nullable = false)]
  public int ProfileViews { get; set; }

  [SwaggerSchema("User biography", Nullable = true)]
  public string? Biography { get; set; }

  [SwaggerSchema("User abstract", Nullable = true)]
  public string? About { get; set; }

  [SwaggerSchema("User birthdate", Nullable = false)]
  public DateTime Birthdate { get; set; }

  [SwaggerSchema("User cover picture", Nullable = true)]
  public ExternalImageResource? Cover { get; set; }

  [SwaggerSchema("User profile picture", Nullable = true)]
  public ExternalImageResource? Picture { get; set; }
}
