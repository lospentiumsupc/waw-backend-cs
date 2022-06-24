using AutoMapper;
using WAW.API.Auth.Domain.Models;
using WAW.API.Auth.Resources;
using WAW.API.Chat.Domain.Models;
using WAW.API.Chat.Resources;

namespace WAW.API.Auth.Mapping;

public static class AuthResourceToModelProfile {
  public static void Register(IProfileExpression profile) {
    profile.CreateMap<ChatRoomRequest, ChatRoom>();
    profile.CreateMap<MessageRequest, Message>();
  }
}
