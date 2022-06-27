using WAW.API.Auth.Domain.Models;
using WAW.API.Chat.Domain.Models;

namespace WAW.API.Chat.Domain.Repositories;

public interface IChatRoomRepository {
  Task<IEnumerable<ChatRoom>> ListAll();
  Task Add(ChatRoom chatRoom);
  Task<ChatRoom?> FindById(long id);
  Task<IEnumerable<Message>> FindMessagesByChatRoomId(long chatRoomId);
  Task<IEnumerable<User>> FindParticipantsByChatRoomId(long chatRoomId);
  void Update(ChatRoom chatRoom);
  void Remove(ChatRoom chatRoom);
}
