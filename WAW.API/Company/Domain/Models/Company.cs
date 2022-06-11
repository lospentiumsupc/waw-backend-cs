using WAW.API.Shared.Domain.Model;

namespace WAW.API.Company.Domain.Models;

public class Company : BaseModel {
  public string Name { get; set; } = string.Empty;
  public string? Address { get; set; }
  public string Email { get; set; } = string.Empty;
}
