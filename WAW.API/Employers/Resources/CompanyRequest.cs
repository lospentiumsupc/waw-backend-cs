using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;

namespace WAW.API.Employers.Resources;

public class CompanyRequest {
  [SwaggerSchema("Category name")]
  [Required]
  public string Name { get; set; } = string.Empty;

  [SwaggerSchema("Category address")]
  public string? Address { get; set; }

  [Required]
  [SwaggerSchema("Category email")]
  public string Email { get; set; } = string.Empty;
}
