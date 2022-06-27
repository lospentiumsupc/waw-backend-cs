using WAW.API.Chat.Domain.Repositories;
using WAW.API.Chat.Domain.Services;
using WAW.API.Chat.Persistence.Repositories;
using WAW.API.Chat.Services;

namespace WAW.API.Chat.Injection;

public static class ChatInjections {
  public static void Register(IServiceCollection services) {
    services.AddScoped<IChatRoomRepository, ChatRoomRepository>();
    services.AddScoped<IChatRoomService, ChatRoomService>();
    services.AddScoped<IMessageRepository, MessageRepository>();
    services.AddScoped<IMessageService, MessageService>();
  }
}
