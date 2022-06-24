using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;

namespace WAW.API.Chat.Resources;

public class MessageRequest {
  [SwaggerSchema("Chat room identifier", Nullable = false)]
  [Required]
  public long ChatRoomId { get; set; }

  [SwaggerSchema("Message content", Nullable = false)]
  [Required]
  public string MessageContent { get; set; } = string.Empty;

  [SwaggerSchema("Message date", Nullable = false)]
  [Required]
  public DateTime Date { get; set; }
}
