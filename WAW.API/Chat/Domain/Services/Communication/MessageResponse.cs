using WAW.API.Chat.Domain.Models;
using WAW.API.Shared.Domain.Service.Communication;

namespace WAW.API.Chat.Domain.Services.Communication;

public class MessageResponse : BaseResponse<Message> {
  public MessageResponse(string message) : base(message) {}
  public MessageResponse(Message resource) : base(resource) {}
}
