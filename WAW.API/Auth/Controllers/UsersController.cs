using System.Net.Mime;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using WAW.API.Auth.Authorization.Attributes;
using WAW.API.Auth.Domain.Models;
using WAW.API.Auth.Domain.Services;
using WAW.API.Auth.Resources;
using WAW.API.Shared.Domain.Service.Communication;
using WAW.API.Shared.Extensions;

namespace WAW.API.Auth.Controllers;

[Authorize]
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
  [ProducesResponseType(typeof(ErrorResponse), 401)]
  [SwaggerResponse(200, "All the stored users were retrieved successfully.", typeof(IEnumerable<UserResource>))]
  [SwaggerResponse(401, "Unauthorized", typeof(ErrorResponse))]
  public async Task<IEnumerable<UserResource>> GetAll() {
    var users = await service.ListAll();
    return mapper.Map<IEnumerable<User>, IEnumerable<UserResource>>(users);
  }

  [HttpGet("{id:long}")]
  [ProducesResponseType(typeof(UserResource), 200)]
  [ProducesResponseType(typeof(ErrorResponse), 401)]
  [ProducesResponseType(typeof(ErrorResponse), 404)]
  [SwaggerResponse(200, "Found user with requested ID.", typeof(UserResource))]
  [SwaggerResponse(401, "Unauthorized", typeof(ErrorResponse))]
  [SwaggerResponse(404, "User couldn't be found", typeof(ErrorResponse))]
  public async Task<IActionResult> FindById(
    [FromRoute] [SwaggerParameter("User identifier", Required = true)] long id
  ) {
    var user = await service.FindById(id);

    if (user is not null) return Ok(user);

    var body = new ErrorResponse($"Unable to find user with ID {id}");
    return NotFound(body);
  }

  [AllowAnonymous]
  [HttpPost("login")]
  [ProducesResponseType(typeof(AuthResource), 200)]
  public async Task<IActionResult> Authenticate([FromBody] AuthRequest request) {
    var response = await service.Authenticate(request);
    return response.ToResponse(this);
  }

  [AllowAnonymous]
  [HttpPost("register")]
  [ProducesResponseType(typeof(UserResource), 200)]
  [ProducesResponseType(typeof(List<string>), 400)]
  [ProducesResponseType(500)]
  [SwaggerResponse(200, "The user was created successfully", typeof(UserResource))]
  [SwaggerResponse(400, "The user data is invalid")]
  public async Task<IActionResult> Register([FromBody] UserCreateRequest resource) {
    if (!ModelState.IsValid) return BadRequest(ModelState.GetErrorMessages());

    var user = mapper.Map<UserCreateRequest, User>(resource);
    var result = await service.Register(user);
    return result.ToResponse<UserResource>(this, mapper);
  }

  [HttpPut("{id:int}")]
  [ProducesResponseType(typeof(UserResource), 200)]
  [ProducesResponseType(typeof(List<string>), 400)]
  [ProducesResponseType(typeof(ErrorResponse), 401)]
  [ProducesResponseType(500)]
  [SwaggerResponse(200, "The user was updated successfully", typeof(UserResource))]
  [SwaggerResponse(400, "The user data is invalid")]
  [SwaggerResponse(401, "Unauthorized", typeof(ErrorResponse))]
  public async Task<IActionResult> UpdateUser(
    [FromRoute] [SwaggerParameter("User identifier", Required = true)] int id,
    [FromBody] UserUpdateRequest resource
  ) {
    if (!ModelState.IsValid) return BadRequest(ModelState.GetErrorMessages());

    var user = mapper.Map<UserUpdateRequest, User>(resource);
    var result = await service.Update(id, user);
    return result.ToResponse<UserResource>(this, mapper);
  }

  [HttpDelete("{id:int}")]
  [ProducesResponseType(typeof(UserResource), 200)]
  [ProducesResponseType(typeof(List<string>), 400)]
  [ProducesResponseType(typeof(ErrorResponse), 401)]
  [ProducesResponseType(500)]
  [SwaggerResponse(200, "The user was deleted successfully", typeof(UserResource))]
  [SwaggerResponse(400, "The selected user to delete does not exist")]
  [SwaggerResponse(401, "Unauthorized", typeof(ErrorResponse))]
  public async Task<IActionResult> DeleteUser(
    [FromRoute] [SwaggerParameter("User identifier", Required = true)] int id
  ) {
    var result = await service.Delete(id);
    return result.ToResponse<UserResource>(this, mapper);
  }
}
