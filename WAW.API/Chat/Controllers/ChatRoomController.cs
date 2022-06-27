using System.Net.Mime;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using WAW.API.Auth.Domain.Models;
using WAW.API.Auth.Domain.Services;
using WAW.API.Auth.Resources;
using WAW.API.Chat.Domain.Models;
using WAW.API.Chat.Domain.Services;
using WAW.API.Chat.Resources;
using WAW.API.Shared.Extensions;

namespace WAW.API.Chat.Controllers;

[ApiController]
[Route("[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Create, read, update and delete ChatRooms")]
public class ChatRoomController : ControllerBase {
  private readonly IChatRoomService chatService;
  private readonly IUserService userService;
  private readonly IMapper mapper;

  public ChatRoomController(IChatRoomService chatService, IUserService userService, IMapper mapper) {
    this.chatService = chatService;
    this.userService = userService;
    this.mapper = mapper;
  }

  [HttpGet]
  [ProducesResponseType(typeof(IEnumerable<ChatRoomResource>), 200)]
  [SwaggerResponse(200, "All the stored chat room were retrieved successfully.", typeof(IEnumerable<ChatRoomResource>))]
  public async Task<IEnumerable<ChatRoomResource>> GetAll() {
    var chatRooms = await chatService.ListAll();
    return mapper.Map<IEnumerable<ChatRoom>, IEnumerable<ChatRoomResource>>(chatRooms);
  }

  [HttpGet("{id:long}/messages")]
  [ProducesResponseType(typeof(IEnumerable<MessageResource>), 200)]
  [ProducesResponseType(404)]
  [SwaggerResponse(200, "All the stored chat room were retrieved successfully.", typeof(IEnumerable<MessageResource>))]
  [SwaggerResponse(404, "Unable to find messages for selected chat room.")]
  public async Task<IActionResult> GetMessagesByChatRoomId(
    [FromRoute] [SwaggerParameter("ChatRoom identifier", Required = true)] long id
  ) {
    var messages = await chatService.ListMessagesByChatRoomId(id);
    if (messages is null) {
      return NotFound();
    }

    var mapped = mapper.Map<IEnumerable<Message>, IEnumerable<MessageResource>>(messages);
    return Ok(mapped);
  }

  [HttpGet("{id:long}/participants")]
  [ProducesResponseType(typeof(IEnumerable<UserResource>), 200)]
  [ProducesResponseType(404)]
  [SwaggerResponse(200, "All the stored chat room were retrieved successfully.", typeof(IEnumerable<UserResource>))]
  [SwaggerResponse(404, "Unable to find participants for selected chat room.")]
  public async Task<IActionResult> GetParticipantsByChatRoomId(
    [FromRoute] [SwaggerParameter("ChatRoom identifier", Required = true)] long id
  ) {
    var participants = await chatService.ListParticipantsByChatRoomId(id);
    if (participants is null) {
      return NotFound();
    }

    var mapped = mapper.Map<IEnumerable<User>, IEnumerable<UserResource>>(participants);
    return Ok(mapped);
  }

  [HttpPost]
  [ProducesResponseType(typeof(ChatRoomResource), 200)]
  [ProducesResponseType(typeof(List<string>), 400)]
  [ProducesResponseType(500)]
  [SwaggerResponse(200, "The chat room was created successfully", typeof(ChatRoomResource))]
  [SwaggerResponse(400, "The chat room data is invalid")]
  public async Task<IActionResult> Post(
    [FromBody] [SwaggerRequestBody("The chat room object about to create", Required = true)] ChatRoomRequest request
  ) {
    if (!ModelState.IsValid) return BadRequest(ModelState.GetErrorMessages());

    var users = await userService.BatchFindById(request.Participants!);
    if (users is null) {
      return BadRequest(new {message = "Unable to find one or more users in the participants list.",});
    }

    var chatRoom = new ChatRoom {Participants = users,};
    var result = await chatService.Create(chatRoom);
    return result.ToResponse<ChatRoomResource>(this, mapper);
  }

  [HttpPut("{id:long}")]
  [ProducesResponseType(typeof(ChatRoomResource), 200)]
  [ProducesResponseType(typeof(List<string>), 400)]
  [ProducesResponseType(500)]
  [SwaggerResponse(200, "The chat room was updated successfully", typeof(ChatRoomResource))]
  [SwaggerResponse(400, "The chat room data is invalid")]
  public async Task<IActionResult> Put(
    [FromRoute] [SwaggerParameter("ChatRoom identifier", Required = true)] long id,
    [FromBody] [SwaggerRequestBody("The chat room object about to update and its changes", Required = true)]
    ChatRoomRequest request
  ) {
    if (!ModelState.IsValid) return BadRequest(ModelState.GetErrorMessages());

    var users = await userService.BatchFindById(request.Participants!);
    if (users is null) {
      return BadRequest(new {message = "Unable to find one or more users in the participants list.",});
    }

    var chatRoom = new ChatRoom {Participants = users,};
    var result = await chatService.Update(id, chatRoom);
    return result.ToResponse<ChatRoomResource>(this, mapper);
  }

  [HttpDelete("{id:long}")]
  [ProducesResponseType(typeof(ChatRoomResource), 200)]
  [ProducesResponseType(typeof(List<string>), 400)]
  [ProducesResponseType(500)]
  [SwaggerResponse(200, "The chat room was deleted successfully", typeof(ChatRoomResource))]
  [SwaggerResponse(400, "The selected chat room to delete does not exist")]
  public async Task<IActionResult> DeleteAsync(
    [FromRoute] [SwaggerParameter("ChatRoom identifier", Required = true)] long id
  ) {
    var result = await chatService.Delete(id);
    return result.ToResponse<ChatRoomResource>(this, mapper);
  }
}
