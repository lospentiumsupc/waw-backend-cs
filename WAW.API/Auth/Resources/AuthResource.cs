namespace WAW.API.Auth.Resources;

public class AuthResource : UserResource {
  public string Token { get; set; } = string.Empty;
}
