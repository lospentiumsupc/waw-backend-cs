using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;

namespace WAW.API.Chat.Resources;

public class ChatRoomRequest {
  [SwaggerSchema("Chat room participants", Nullable = false)]
  [Required]
  public IList<long>? Participants { get; set; }
}
