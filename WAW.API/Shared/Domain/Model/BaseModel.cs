using System.Reflection;

namespace WAW.API.Shared.Domain.Model;

public class BaseModel {
  public long Id { get; set; }

  public void CopyFrom(object? source) {
    CopyProperties(source, this);
  }

  public void CopyFrom(object? source, string[] ignoredKeys) {
    CopyProperties(source, this, ignoredKeys);
  }

  public void CopyTo(BaseModel destination) {
    CopyProperties(this, destination);
  }

  public void CopyTo(BaseModel destination, string[] ignoredKeys) {
    CopyProperties(this, destination, ignoredKeys);
  }

  private static void CopyProperties(object? source, object? destination) {
    CopyProperties(source, destination, new[] {"Id",});
  }

  // Adapted from https://stackoverflow.com/a/8724150/15040387
  private static void CopyProperties(object? source, object? destination, string[] ignoredKeys) {
    if (source is null || destination is null) {
      throw new Exception("The source and/or destination objects are null");
    }

    var typeDest = destination.GetType();
    var typeSrc = source.GetType();
    var srcProps = typeSrc.GetProperties();
    foreach (var srcProp in srcProps) {
      if (ignoredKeys != null && ignoredKeys.Contains(srcProp.Name)) continue;
      if (!srcProp.CanRead) continue;
      var targetProp = typeDest.GetProperty(srcProp.Name);
      if (targetProp is null) continue;
      if (!targetProp.CanWrite) continue;
      var method = targetProp.GetSetMethod(true);
      if (method != null && method.IsPrivate) continue;
      if (method != null && (method.Attributes & MethodAttributes.Abstract) != 0) continue;
      if (!targetProp.PropertyType.IsAssignableFrom(srcProp.PropertyType)) continue;
      // Passed all tests, lets set the value
      targetProp.SetValue(destination, srcProp.GetValue(source, null), null);
    }
  }
}
