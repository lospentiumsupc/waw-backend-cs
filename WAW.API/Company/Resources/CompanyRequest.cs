using System.ComponentModel.DataAnnotations;

namespace WAW.API.Company.Resources;

public class CompanyRequest {
  [Required]
  public string? Name { get; set; }

  public string? Address { get; set; }

  [Required]
  public string? Email { get; set; }
}
