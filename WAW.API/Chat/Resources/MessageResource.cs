using Swashbuckle.AspNetCore.Annotations;

namespace WAW.API.Chat.Resources;

public class MessageResource {
  [SwaggerSchema("Message identifier", ReadOnly = true)]
  public long Id { get; set; }

  [SwaggerSchema("Message content", Nullable = false)]
  public string Content { get; set; } = string.Empty;

  [SwaggerSchema("Message date", Nullable = false)]
  public DateTime Date { get; set; }

  [SwaggerSchema("Sender identifier", Nullable = false)]
  public long SenderId { get; set; }

  [SwaggerSchema("Chat room identifier", Nullable = false)]
  public long ChatRoomId { get; set; }
}
