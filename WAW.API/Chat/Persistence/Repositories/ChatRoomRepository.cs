using WAW.API.Chat.Domain.Models;
using WAW.API.Chat.Domain.Repositories;
using WAW.API.Shared.Persistence.Contexts;
using WAW.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using WAW.API.Auth.Domain.Models;

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

  public async Task<IEnumerable<Message>> FindMessagesByChatRoomId(long chatRoomId) {
    return await context.Messages.Where(p => p.ChatRoomId == chatRoomId).ToListAsync();
  }

  public async Task<IEnumerable<User>> FindParticipantsByChatRoomId(long chatRoomId) {
    return await context.Users.Where(p => p.ChatRoomId == chatRoomId).ToListAsync();
  }

  public void Update(ChatRoom chatRoom) {
    context.ChatRooms.Update(chatRoom);
  }

  public void Remove(ChatRoom chatRoom) {
    context.ChatRooms.Remove(chatRoom);
  }
}
