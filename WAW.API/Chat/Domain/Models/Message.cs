using WAW.API.Shared.Domain.Model;

namespace WAW.API.Chat.Domain.Models;

public class Message : BaseModel {
  public long UserId { get; set; }
  public long ChatRoomId { get; set; }
  public string MessageContent { get; set; } = string.Empty;
  public DateTime Date { get; set; }
}
