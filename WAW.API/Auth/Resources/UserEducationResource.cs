namespace WAW.API.Auth.Resources;

public class UserEducationResource {
  public long Id { get; set; }
  public string University { get; set; } = string.Empty;
  public string Description { get; set; } = string.Empty;
  public int StartYear { get; set; }
  public int EndYear { get; set; }
  public ExternalImageResource? Image { get; set; }
}
