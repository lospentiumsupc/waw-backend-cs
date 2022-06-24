using WAW.API.Chat.Domain.Models;

namespace WAW.API.Chat.Domain.Repositories;

public interface IMessageRepository {
  Task<IEnumerable<Message>> ListAll();
  Task Add(Message message);
  Task<Message?> FindById(long id);
  void Remove(Message message);
}
