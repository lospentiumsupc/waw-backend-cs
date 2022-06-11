using WAW.API.Chat.Domain.Models;

namespace WAW.API.Chat.Domain.Repositories;

public interface IChatRoomRepository {
  Task<IEnumerable<ChatRoom>> ListAll();
  Task Add(ChatRoom chatRoom);
  Task<ChatRoom?> FindById(long id);
  void Update(ChatRoom chatRoom);
  void Remove(ChatRoom chatRoom);
}
