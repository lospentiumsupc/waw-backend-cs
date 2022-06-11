using AutoMapper;
using WAW.API.Chat.Domain.Models;
using WAW.API.Chat.Resources;

namespace WAW.API.Chat.Mapping;

public class ResourceToModelProfile : Profile{
  public ResourceToModelProfile() {
    CreateMap<ChatRoomRequest, ChatRoom>();
    CreateMap<MessageRequest, Message>();
  }
}
