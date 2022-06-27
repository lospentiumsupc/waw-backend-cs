using AutoMapper;
using WAW.API.Chat.Domain.Models;
using WAW.API.Chat.Resources;

namespace WAW.API.Chat.Mapping;

public static class ChatModelToResourceProfile {
  public static void Register(IProfileExpression profile) {
    profile.CreateMap<ChatRoom, ChatRoomResource>();
    profile.CreateMap<Message, MessageResource>();
  }
}
