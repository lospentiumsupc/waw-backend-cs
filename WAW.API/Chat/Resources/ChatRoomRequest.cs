using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;

namespace WAW.API.Chat.Resources;

public class ChatRoomRequest {
  [SwaggerSchema("Chat room creation date", Nullable = false)]
  [Required]
  public DateTime CreationDate { get; set; }

  [SwaggerSchema("Chat room last update date", Nullable = false)]
  [Required]
  public DateTime LastUpdateDate { get; set; }
}
