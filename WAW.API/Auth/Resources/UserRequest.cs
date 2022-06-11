using System.ComponentModel.DataAnnotations;

namespace WAW.API.Auth.Resources;

public class UserRequest {
  [Required]
  public string FullName { get; set; }

  [Required]
  public string PreferredName { get; set; }

  [Required]
  public string Email { get; set; }

  [Required]
  public DateOnly Birthdate { get; set; }

  [Required]
  public string Location { get; set; }

  public string Biography { get; set; }
  public string About { get; set; }
}
