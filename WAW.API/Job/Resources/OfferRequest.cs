using System.ComponentModel.DataAnnotations;

namespace WAW.API.Job.Resources;

public class OfferRequest {
  [Required]
  public string? Title { get; set; }

  [Required]
  public string? Image { get; set; }

  [Required]
  public string? Description { get; set; }

  public string? SalaryRange { get; set; }

  [Required]
  public bool? Status { get; set; }
}
