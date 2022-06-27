using Swashbuckle.AspNetCore.Annotations;

namespace WAW.API.Chat.Resources;

public class MessageResource {
  [SwaggerSchema("Message identifier", ReadOnly = true)]
  public long Id { get; set; }

  [SwaggerSchema("User identifier", Nullable = false)]
  public long UserId { get; set; }

  [SwaggerSchema("Chat room identifier", Nullable = false)]
  public long ChatRoomId { get; set; }

  [SwaggerSchema("Message content", Nullable = false)]
  public string Content { get; set; } = string.Empty;

  [SwaggerSchema("Message date", Nullable = false)]
  public DateTime Date { get; set; }
}
