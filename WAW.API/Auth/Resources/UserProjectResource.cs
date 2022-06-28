namespace WAW.API.Auth.Resources;

public class UserProjectResource {
  public long Id { get; set; }
  public string Title { get; set; } = string.Empty;
  public string Summary { get; set; } = string.Empty;
  public DateTime Date { get; set; }
  public ExternalImageResource? Image { get; set; }
}
