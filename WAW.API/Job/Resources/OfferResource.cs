using Swashbuckle.AspNetCore.Annotations;

namespace WAW.API.Job.Resources;

public class OfferResource {
  [SwaggerSchema("Job offer identifier", ReadOnly = true)]
  public long Id { get; set; }

  [SwaggerSchema("Job offer title")]
  public string Title { get; set; } = string.Empty;

  [SwaggerSchema("Job offer image URL")]
  public string? Image { get; set; }

  [SwaggerSchema("Job offer description")]
  public string Description { get; set; } = string.Empty;

  [SwaggerSchema("Job offer salary range")]
  public string SalaryRange { get; set; } = string.Empty;

  [SwaggerSchema("Job offer status")]
  public bool Status { get; set; }
}
