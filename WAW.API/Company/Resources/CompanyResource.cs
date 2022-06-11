using Swashbuckle.AspNetCore.Annotations;

namespace WAW.API.Company.Resources;

public class CompanyResource {
  [SwaggerSchema("Company identifier")]
  public long Id { get; set; }

  [SwaggerSchema("Company name")]
  public string? Name { get; set; }

  [SwaggerSchema("Company address")]
  public string? Address { get; set; }

  [SwaggerSchema("Company email")]
  public string? Email { get; set; }
}
