using WAW.API.Chat.Domain.Models;
using WAW.API.Chat.Domain.Services.Communication;

namespace WAW.API.Chat.Domain.Services;

public interface IChatRoomService {
  Task<IEnumerable<ChatRoom>> ListAll();
  Task<ChatRoomResponse> Create(ChatRoom chatRoom);
  Task<ChatRoomResponse> Update(long id, ChatRoom chatRoom);
  Task<ChatRoomResponse> Delete(long id);
}
