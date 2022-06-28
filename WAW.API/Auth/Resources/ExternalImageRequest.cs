using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;

namespace WAW.API.Auth.Resources;

public class ExternalImageRequest {
  [SwaggerSchema("User fullname", Nullable = false)]
  [Required]
  public string? Href { get; set; }

  [SwaggerSchema("Image alternative title", Nullable = true)]
  public string? Alt { get; set; }
}
