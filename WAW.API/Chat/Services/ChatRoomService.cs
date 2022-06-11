using WAW.API.Chat.Domain.Models;
using WAW.API.Chat.Domain.Repositories;
using WAW.API.Chat.Domain.Services;
using WAW.API.Chat.Domain.Services.Communication;
using WAW.API.Weather.Domain.Repositories;

namespace WAW.API.Chat.Services;

public class ChatRoomService : IChatRoomService {
  private readonly IChatRoomRepository repository;
  private readonly IUnitOfWork unitOfWork;

  public ChatRoomService(IChatRoomRepository repository, IUnitOfWork unitOfWork) {
    this.repository = repository;
    this.unitOfWork = unitOfWork;
  }

  public Task<IEnumerable<ChatRoom>> ListAll() {
    return repository.ListAll();
  }

  public async Task<ChatRoomResponse> Create(ChatRoom chatRoom) {
    try {
      await repository.Add(chatRoom);
      await unitOfWork.Complete();
      return new ChatRoomResponse(chatRoom);
    } catch (Exception e) {
      return new ChatRoomResponse($"An error occurred while saving the chatroom: {e.Message}");
    }
  }

  public async Task<ChatRoomResponse> Update(long id, ChatRoom chatRoom) {
    var current = await repository.FindById(id);
    if (current == null) return new ChatRoomResponse("Chatroom not found");

    chatRoom.CopyProperties(current);

    try {
      repository.Update(current);
      await unitOfWork.Complete();
      return new ChatRoomResponse(current);
    } catch (Exception e) {
      return new ChatRoomResponse($"An error occurred while updating the chat: {e.Message}");
    }
  }

  public async Task<ChatRoomResponse> Delete(long id) {
    var current = await repository.FindById(id);
    if (current == null) return new ChatRoomResponse("Chatroom not found");

    try {
      repository.Remove(current);
      await unitOfWork.Complete();
      return new ChatRoomResponse(current);
    } catch (Exception e) {
      return new ChatRoomResponse($"An error occurred while deleting the chat: {e.Message}");
    }
  }
}
