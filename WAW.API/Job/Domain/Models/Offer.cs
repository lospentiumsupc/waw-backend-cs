using WAW.API.Shared.Domain.Model;

namespace WAW.API.Job.Domain.Models;

public class Offer : BaseModel {
  public string Title { get; set; } = string.Empty;
  public string? Image { get; set; }
  public string Description { get; set; } = string.Empty;
  public string SalaryRange { get; set; } = string.Empty;
  public bool Status { get; set; }
}
