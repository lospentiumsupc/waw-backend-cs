using WAW.API.Chat.Domain.Models;
using WAW.API.Shared.Domain.Service.Communication;

namespace WAW.API.Chat.Domain.Services.Communication;

public class ChatRoomResponse : BaseResponse<ChatRoom> {
  public ChatRoomResponse(string message) : base(message) {}
  public ChatRoomResponse(ChatRoom resource) : base(resource) {}
}
