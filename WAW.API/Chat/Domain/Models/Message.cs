using System.Text.Json.Serialization;
using WAW.API.Auth.Domain.Models;
using WAW.API.Shared.Domain.Model;

namespace WAW.API.Chat.Domain.Models;

public class Message : BaseModel {
  public string Content { get; set; } = string.Empty;
  public DateTime Date { get; set; }

  //Relationships
  public long SenderId { get; set; }
  [JsonIgnore]
  public User? Sender { get; set; }

  public long ChatRoomId { get; set; }
  [JsonIgnore]
  public ChatRoom? ChatRoom { get; set; }
}
