namespace WAW.API.Auth.Resources;

public class UserResource {
  public long Id { get; set; }
  public string FullName { get; set; }= string.Empty;
  public string PreferredName { get; set; }= string.Empty;
  public string Email { get; set; }= string.Empty;
  public DateOnly Birthdate { get; set; }
  public string Location { get; set; }= string.Empty;
  public string Biography { get; set; }= string.Empty;
  public string About { get; set; }= string.Empty;
}
