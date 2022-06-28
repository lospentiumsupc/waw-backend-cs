using WAW.API.Shared.Domain.Model;

namespace WAW.API.Auth.Domain.Models;

public class ExternalImage : BaseModel {
  public string Href { get; set; } = string.Empty;
  public string Alt { get; set; } = string.Empty;
}
