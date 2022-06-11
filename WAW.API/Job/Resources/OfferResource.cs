using Swashbuckle.AspNetCore.Annotations;

namespace WAW.API.Job.Resources;

public class OfferResource {
  [SwaggerSchema("Job offer identifier", ReadOnly = true)]
  public long Id { get; set; }

  [SwaggerSchema("Job offer title", Nullable = false)]
  public string Title { get; set; } = string.Empty;

  [SwaggerSchema("Job offer image URL", Nullable = true)]
  public string? Image { get; set; }

  [SwaggerSchema("Job offer description", Nullable = false)]
  public string Description { get; set; } = string.Empty;

  [SwaggerSchema("Job offer salary range", Nullable = false)]
  public string SalaryRange { get; set; } = string.Empty;

  [SwaggerSchema("Job offer status", Nullable = false)]
  public bool Status { get; set; }
}
