using WAW.API.Auth.Domain.Models;
using WAW.API.Shared.Domain.Model;

namespace WAW.API.Chat.Domain.Models;

public class ChatRoom : BaseModel {
  public DateTime Date { get; set; }

  //Relationship
  public IList<Message> Messages { get; set; } = new List<Message>();
  public IList<User> Users { get; set; } = new List<User>();
}
