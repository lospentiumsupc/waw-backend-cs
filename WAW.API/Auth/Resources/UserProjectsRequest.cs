using System.ComponentModel.DataAnnotations;

namespace WAW.API.Auth.Resources;

public class UserProjectsRequest {
  [Required]
  public string? Title { get; set; }
  [Required]
  public string? Summary { get; set; }
  [Required]
  public DateTime? Date { get; set; }

  public ExternalImageRequest? Image { get; set; }
}
