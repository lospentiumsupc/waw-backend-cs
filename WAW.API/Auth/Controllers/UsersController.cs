using System.Net.Mime;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using WAW.API.Auth.Domain.Models;
using WAW.API.Auth.Domain.Services;
using WAW.API.Auth.Resources;
using WAW.API.Shared.Extensions;

namespace WAW.API.Auth.Controllers;

[ApiController]
[Route("[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Create, read, update and delete Users")]
public class UsersController : ControllerBase {
  private readonly IUserService service;
  private readonly IMapper mapper;

  public UsersController(IUserService service, IMapper mapper) {
    this.service = service;
    this.mapper = mapper;
  }

  [HttpGet]
  [ProducesResponseType(typeof(IEnumerable<UserResource>), 200)]
  [SwaggerResponse(200, "All the stored users were retrieved successfully.", typeof(IEnumerable<UserResource>))]
  public async Task<IEnumerable<UserResource>> GetAll() {
    var users = await service.ListAll();
    return mapper.Map<IEnumerable<User>, IEnumerable<UserResource>>(users);
  }

  [HttpPost]
  [ProducesResponseType(typeof(UserResource), 201)]
  [ProducesResponseType(typeof(List<string>), 400)]
  [ProducesResponseType(500)]
  [SwaggerResponse(201, "The user was created successfully", typeof(UserResource))]
  [SwaggerResponse(400, "The user data is invalid")]
  public async Task<IActionResult> Post([FromBody] UserRequest resource) {
    if (!ModelState.IsValid) return BadRequest(ModelState.GetErrorMessages());

    var user = mapper.Map<UserRequest, User>(resource);
    var result = await service.Create(user);
    return result.ToResponse<UserResource>(this, mapper);
  }

  [HttpPut("{id:int}")]
  [ProducesResponseType(typeof(UserResource), 200)]
  [ProducesResponseType(typeof(List<string>), 400)]
  [ProducesResponseType(500)]
  [SwaggerResponse(200, "The user was updated successfully", typeof(UserResource))]
  [SwaggerResponse(400, "The user data is invalid")]
  public async Task<IActionResult> Put(
    [FromRoute] [SwaggerParameter("User identifier", Required = true)] int id,
    [FromBody] UserRequest resource
  ) {
    if (!ModelState.IsValid) return BadRequest(ModelState.GetErrorMessages());

    var user = mapper.Map<UserRequest, User>(resource);
    var result = await service.Update(id, user);
    return result.ToResponse<UserResource>(this, mapper);
  }

  [HttpDelete("{id:int}")]
  [ProducesResponseType(typeof(UserResource), 200)]
  [ProducesResponseType(typeof(List<string>), 400)]
  [ProducesResponseType(500)]
  [SwaggerResponse(200, "The user was deleted successfully", typeof(UserResource))]
  [SwaggerResponse(400, "The selected user to delete does not exist")]
  public async Task<IActionResult> DeleteAsync(
    [FromRoute] [SwaggerParameter("User identifier", Required = true)] int id
  ) {
    var result = await service.Delete(id);
    return result.ToResponse<UserResource>(this, mapper);
  }
}
