using WAW.API.Employers.Resources;

namespace WAW.API.Auth.Resources;

public class UserExperienceResource {
  public long Id { get; set; }
  public string Title { get; set; } = string.Empty;
  public string Location { get; set; } = string.Empty;
  public DateTime StartDate { get; set; }
  public DateTime EndDate { get; set; }
  public string TimeDiff { get; set; } = string.Empty;
  public string Description { get; set; } = string.Empty;
  public ExternalImageResource? Image { get; set; }
  public CompanyResource? Company { get; set; }
}
