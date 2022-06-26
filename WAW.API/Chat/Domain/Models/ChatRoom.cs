using WAW.API.Auth.Domain.Models;
using WAW.API.Shared.Domain.Model;

namespace WAW.API.Chat.Domain.Models;

public class ChatRoom : BaseModel {
  public DateTime CreationDate { get; set; }
  public DateTime LastUpdateDate { get; set; }

  //Relationship
  public IList<Message> Messages { get; set; } = new List<Message>();
  public IList<User> Participants { get; set; } = new List<User>();
}
