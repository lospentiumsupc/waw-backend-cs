namespace WAW.API.Auth.Resources;

public class UserResource {
  public long Id { get; set; }
  public string FullName { get; set; }
  public string PreferredName { get; set; }
  public string Email { get; set; }
  public DateOnly Birthdate { get; set; }
  public string Location { get; set; }
  public string Biography { get; set; }
  public string About { get; set; }
}
