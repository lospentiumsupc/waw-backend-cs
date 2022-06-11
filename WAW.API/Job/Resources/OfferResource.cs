namespace WAW.API.Job.Resources;

public class OfferResource {
  public long Id { get; set; }
  public string? Title { get; set; }
  public string? Image { get; set; }
  public string? Description { get; set; }
  public string? SalaryRange { get; set; }
  public bool Status { get; set; }
}
