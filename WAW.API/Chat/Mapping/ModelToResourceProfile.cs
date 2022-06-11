using AutoMapper;
using WAW.API.Chat.Domain.Models;
using WAW.API.Chat.Resources;

namespace WAW.API.Chat.Mapping;

public class ModelToResourceProfile: Profile{
  public ModelToResourceProfile() {
    CreateMap<ChatRoom, ChatRoomResource>();
    CreateMap<Message, MessageResource>();
  }
}
