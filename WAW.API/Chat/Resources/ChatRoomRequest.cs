using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;
using WAW.API.Auth.Domain.Models;
using WAW.API.Chat.Domain.Models;

namespace WAW.API.Chat.Resources;

public class ChatRoomRequest {
  [SwaggerSchema("Chat room creation date", Nullable = false)]
  [Required]
  public IList<User> Participants { get; set; } = new List<User>();
  [SwaggerSchema("Chat room creation date", Nullable = false)]
  [Required]
  public IList<Message> Messages { get; set; } = new List<Message>();
}
