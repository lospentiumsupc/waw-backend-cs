using WAW.API.Chat.Domain.Models;
using WAW.API.Chat.Domain.Repositories;
using WAW.API.Shared.Persistence.Contexts;
using WAW.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace WAW.API.Chat.Persistence.Repositories;

public class ChatRoomRepository : BaseRepository, IChatRoomRepository {
  public ChatRoomRepository(AppDbContext context) : base(context) {}

  public async Task<IEnumerable<ChatRoom>> ListAll() {
    return await context.ChatRooms.ToListAsync();
  }

  public async Task Add(ChatRoom chatRoom) {
    await context.ChatRooms.AddAsync(chatRoom);
  }

  public async Task<ChatRoom?> FindById(long id) {
    return await context.ChatRooms.FindAsync(id);
  }

  public void Update(ChatRoom chatRoom) {
    context.ChatRooms.Update(chatRoom);
  }

  public void Remove(ChatRoom chatRoom) {
    context.ChatRooms.Remove(chatRoom);
  }
}
