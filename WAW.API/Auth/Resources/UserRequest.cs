using System.ComponentModel.DataAnnotations;

namespace WAW.API.Auth.Resources;

public class UserRequest {
  [Required]
  public string FullName { get; set; } = string.Empty;

  [Required]
  public string PreferredName { get; set; } = string.Empty;

  [Required]
  public string Email { get; set; } = string.Empty;

  [Required]
  public DateOnly Birthdate { get; set; }

  [Required]
  public string Location { get; set; } = string.Empty;

  public string Biography { get; set; } = string.Empty;
  public string About { get; set; } = string.Empty;
}
