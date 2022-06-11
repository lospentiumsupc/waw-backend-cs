using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;

namespace WAW.API.Job.Resources;

[SwaggerSchema(Required = new[]{"Title", "Description", "SalaryRange", "Status",})]
public class OfferRequest {
  [SwaggerSchema("Job offer title",  Nullable = false)]
  [Required]
  public string Title { get; set; } = string.Empty;

  [SwaggerSchema("Job offer image URL", Nullable = false)]
  public string? Image { get; set; }

  [SwaggerSchema("Job offer description", Nullable = false)]
  [Required]
  public string Description { get; set; } = string.Empty;

  [SwaggerSchema("Job offer salary range", Nullable = true)]
  [Required]
  public string SalaryRange { get; set; } = string.Empty;

  [SwaggerSchema("Job offer status", Nullable = false)]
  [Required]
  public bool Status { get; set; }
}
