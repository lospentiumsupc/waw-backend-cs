using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;

namespace WAW.API.Chat.Resources;

public class ChatRoomRequest {
  [SwaggerSchema("Chat room date")]
  [Required]
  public DateTime Date { get; set; }
}
