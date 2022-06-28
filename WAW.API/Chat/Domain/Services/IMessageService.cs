using WAW.API.Chat.Domain.Models;
using WAW.API.Chat.Domain.Services.Communication;

namespace WAW.API.Chat.Domain.Services;

public interface IMessageService {
  Task<IEnumerable<Message>> ListAll();
  Task<MessageResponse> Create(Message message);
  Task<MessageResponse> Delete(long id);
}
