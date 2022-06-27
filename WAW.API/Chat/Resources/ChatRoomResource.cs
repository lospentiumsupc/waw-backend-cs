using Swashbuckle.AspNetCore.Annotations;
using WAW.API.Auth.Domain.Models;
using WAW.API.Chat.Domain.Models;

namespace WAW.API.Chat.Resources;

public class ChatRoomResource {
  [SwaggerSchema("Chat room identifier", ReadOnly = true)]
  public long Id { get; set; }

  [SwaggerSchema("Chat room creation date", Nullable = false)]
  public DateTime CreationDate { get; set; }

  [SwaggerSchema("Chat room last update date", Nullable = false)]
  public DateTime LastUpdateDate { get; set; }

  [SwaggerSchema("Chat room last update date", Nullable = false)]
  public IList<User> Participants { get; set; } = new List<User>();

  [SwaggerSchema("Chat room last update date", Nullable = false)]
  public IList<Message> Messages { get; set; } = new List<Message>();
}
