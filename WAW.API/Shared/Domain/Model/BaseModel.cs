using WAW.API.Shared.Extensions;

namespace WAW.API.Shared.Domain.Model;

public class BaseModel {
  public long Id { get; set; }

  public void CopyProperties(BaseModel destination) {
    var ignoredKeys = new[] {"Id",};
    this.CopyProperties(destination, ignoredKeys);
  }
}
