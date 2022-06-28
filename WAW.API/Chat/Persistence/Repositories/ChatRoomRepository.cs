using Microsoft.EntityFrameworkCore;
using WAW.API.Auth.Domain.Models;
using WAW.API.Chat.Domain.Models;
using WAW.API.Chat.Domain.Repositories;
using WAW.API.Shared.Persistence.Contexts;
using WAW.API.Shared.Persistence.Repositories;

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

  public async Task<IEnumerable<Message>?> FindMessagesByChatRoomId(long chatRoomId) {
    var chatRoom = await context.ChatRooms.FindAsync(chatRoomId);
    return chatRoom?.Messages;
  }

  public async Task<IEnumerable<User>?> FindParticipantsByChatRoomId(long chatRoomId) {
    var chatRoom = await context.ChatRooms.FindAsync(chatRoomId);
    return chatRoom?.Participants;
  }

  public void Update(ChatRoom chatRoom) {
    context.ChatRooms.Update(chatRoom);
  }

  public void Remove(ChatRoom chatRoom) {
    context.ChatRooms.Remove(chatRoom);
  }
}
