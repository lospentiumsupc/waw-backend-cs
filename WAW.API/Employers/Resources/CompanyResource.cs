using Swashbuckle.AspNetCore.Annotations;

namespace WAW.API.Employers.Resources;

public class CompanyResource {
  [SwaggerSchema("Company identifier", ReadOnly = true)]
  public long Id { get; set; }

  [SwaggerSchema("Company name", Nullable = false)]
  public string Name { get; set; } = string.Empty;

  [SwaggerSchema("Company address")]
  public string? Address { get; set; }

  [SwaggerSchema("Company email", Nullable = false)]
  public string Email { get; set; } = string.Empty;
}
