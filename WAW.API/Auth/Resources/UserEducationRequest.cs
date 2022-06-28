using System.ComponentModel.DataAnnotations;

namespace WAW.API.Auth.Resources;

public class UserEducationRequest {
  [Required]
  public string? University { get; set; }

  [Required]
  public string? Description { get; set; }

  [Required]
  public int? StartYear { get; set; }

  [Required]
  public int? EndYear { get; set; }

  public ExternalImageRequest? Image { get; set; }
}
