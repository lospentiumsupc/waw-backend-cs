using System.Net.Mime;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
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
  private readonly IChatRoomService service;
  private readonly IMapper mapper;

  public ChatRoomController(IChatRoomService service, IMapper mapper) {
    this.service = service;
    this.mapper = mapper;
  }

  [HttpGet]
  [ProducesResponseType(typeof(IEnumerable<ChatRoomResource>), 200)]
  [SwaggerResponse(200, "All the stored chatRoom were retrieved successfully.", typeof(IEnumerable<ChatRoomResource>))]
  public async Task<IEnumerable<ChatRoomResource>> GetAll() {
    var chatRooms = await service.ListAll();
    return mapper.Map<IEnumerable<ChatRoom>, IEnumerable<ChatRoomResource>>(chatRooms);
  }

  [HttpPost]
  [ProducesResponseType(typeof(ChatRoomResource), 201)]
  [ProducesResponseType(typeof(List<string>), 400)]
  [ProducesResponseType(500)]
  [SwaggerResponse(201, "The chatRoom was created successfully", typeof(ChatRoomResource))]
  [SwaggerResponse(400, "The chatRoom data is invalid")]
  public async Task<IActionResult> Post(
    [FromBody] [SwaggerRequestBody("The chatRoom object about to create", Required = true)] ChatRoomRequest chatRoomRequest
  ) {
    if (!ModelState.IsValid) return BadRequest(ModelState.GetErrorMessages());

    var chatRoom = mapper.Map<ChatRoomRequest, ChatRoom>(chatRoomRequest);
    var result = await service.Create(chatRoom);
    return result.ToResponse<ChatRoomResource>(this, mapper);
  }

  [HttpPut("{id:long}")]
  [ProducesResponseType(typeof(ChatRoomResource), 200)]
  [ProducesResponseType(typeof(List<string>), 400)]
  [ProducesResponseType(500)]
  [SwaggerResponse(200, "The chatRoom was updated successfully", typeof(ChatRoomResource))]
  [SwaggerResponse(400, "The chatRoom data is invalid")]
  public async Task<IActionResult> Put(
    [FromRoute] [SwaggerParameter("ChatRoom identifier", Required = true)] long id,
    [FromBody] [SwaggerRequestBody("The chatRoom object about to update and its changes", Required = true)]
    ChatRoomRequest chatRoomRequest
  ) {
    if (!ModelState.IsValid) return BadRequest(ModelState.GetErrorMessages());

    var chatRoom = mapper.Map<ChatRoomRequest, ChatRoom>(chatRoomRequest);
    var result = await service.Update(id, chatRoom);
    return result.ToResponse<ChatRoomResource>(this, mapper);
  }

  [HttpDelete("{id:long}")]
  [ProducesResponseType(typeof(ChatRoomResource), 200)]
  [ProducesResponseType(typeof(List<string>), 400)]
  [ProducesResponseType(500)]
  [SwaggerResponse(200, "The chatRoom was deleted successfully", typeof(ChatRoomResource))]
  [SwaggerResponse(400, "The selected chatRoom to delete does not exist")]
  public async Task<IActionResult> DeleteAsync(
    [FromRoute] [SwaggerParameter("ChatRoom identifier", Required = true)] long id
  ) {
    var result = await service.Delete(id);
    return result.ToResponse<ChatRoomResource>(this, mapper);
  }
}
