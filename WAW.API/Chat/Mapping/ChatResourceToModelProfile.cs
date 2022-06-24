using AutoMapper;
using WAW.API.Chat.Domain.Models;
using WAW.API.Chat.Resources;

namespace WAW.API.Chat.Mapping;

public class ChatResourceToModelProfile {
  public static void Register(IProfileExpression profile) {
    profile.CreateMap<ChatRoomRequest, ChatRoom>();
    profile.CreateMap<MessageRequest, Message>();
  }
}
