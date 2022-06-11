using WAW.API.Shared.Domain.Model;

namespace WAW.API.Auth.Domain.Models;

public class User : BaseModel {
  public string FullName { get; set; }
  public string PreferredName { get; set; }
  public string Email { get; set; }
  public DateOnly Birthdate { get; set; }
  public string? Location { get; set; }
  public string? Biography { get; set; }
  public string? About { get; set; }
}
