using Swashbuckle.AspNetCore.Annotations;

namespace WAW.API.Chat.Resources;

public class ChatRoomResource {
  [SwaggerSchema("Chat room identifier", ReadOnly = true)]
  public long Id { get; set; }

  [SwaggerSchema("Chat room date", Nullable = false)]
  public DateTime Date { get; set; }
}
