using System.ComponentModel.DataAnnotations;
using WAW.API.Employers.Resources;

namespace WAW.API.Auth.Resources;

public class UserExperienceRequest {
  [Required]
  public string? Title { get; set; }

  [Required]
  public string? Location { get; set; }

  [Required]
  public DateTime? StartDate { get; set; }

  [Required]
  public DateTime? EndDate { get; set; }

  [Required]
  public string? TimeDiff { get; set; }

  [Required]
  public string? Description { get; set; }

  public ExternalImageRequest? Image { get; set; }

  public long? CompanyId { get; set; }
}
