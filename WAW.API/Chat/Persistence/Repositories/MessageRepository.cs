using Microsoft.EntityFrameworkCore;
using WAW.API.Chat.Domain.Models;
using WAW.API.Chat.Domain.Repositories;
using WAW.API.Shared.Persistence.Contexts;
using WAW.API.Shared.Persistence.Repositories;

namespace WAW.API.Chat.Persistence.Repositories;

public class MessageRepository : BaseRepository, IMessageRepository {
  public MessageRepository(AppDbContext context) : base(context) {}

  public async Task<IEnumerable<Message>> ListAll() {
    return await context.Messages.ToListAsync();
  }

  public async Task Add(Message message) {
    await context.Messages.AddAsync(message);
  }

  public async Task<Message?> FindById(long id) {
    return await context.Messages.FindAsync(id);
  }

  public void Delete(Message message) {
    context.Messages.Remove(message);
  }
}
