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

  [HttpGet("me")]
  [ProducesResponseType(typeof(UserResource), 200)]
  [ProducesResponseType(typeof(ErrorResponse), 401)]
  [SwaggerResponse(200, "Found current user information", typeof(UserResource))]
  [SwaggerResponse(401, "Unauthorized", typeof(ErrorResponse))]
  public UserResource GetMe() {
    var user = (User) HttpContext.Items["User"]!;
    return mapper.Map<UserResource>(user);
  }

  [HttpGet("me/education")]
  public async Task<IEnumerable<UserEducationResource>> GetUserEducation() {
    var user = (User) HttpContext.Items["User"]!;
    var education = await service.ListEducationByUser(user.Id);
    if (education == null) {
      throw new Exception($"Unable to fetch education list for logged in user: {user.Id}");
    }

    return mapper.Map<IEnumerable<UserEducation>, IEnumerable<UserEducationResource>>(education);
  }

  [HttpGet("me/experience")]
  public async Task<IEnumerable<UserExperienceResource>> GetUserExperience() {
    var user = (User) HttpContext.Items["User"]!;
    var experience = await service.ListExperienceByUser(user.Id);
    if (experience == null) {
      throw new Exception($"Unable to fetch experience list for logged in user: {user.Id}");
    }

    return mapper.Map<IEnumerable<UserExperience>, IEnumerable<UserExperienceResource>>(experience);
  }

  [HttpGet("me/projects")]
  public async Task<IEnumerable<UserProjectResource>> GetUserProjects() {
    var user = (User) HttpContext.Items["User"]!;
    var projects = await service.ListProjectsByUser(user.Id);
    if (projects == null) {
      throw new Exception($"Unable to fetch projects list for logged in user: {user.Id}");
    }

    return mapper.Map<IEnumerable<UserProject>, IEnumerable<UserProjectResource>>(projects);
  }

  [HttpPut("me")]
  [ProducesResponseType(typeof(UserResource), 200)]
  [ProducesResponseType(typeof(List<string>), 400)]
  [ProducesResponseType(typeof(ErrorResponse), 401)]
  [ProducesResponseType(500)]
  [SwaggerResponse(200, "The user was updated successfully", typeof(UserResource))]
  [SwaggerResponse(400, "The user data is invalid")]
  [SwaggerResponse(401, "Unauthorized", typeof(ErrorResponse))]
  public async Task<IActionResult> UpdateUser([FromBody] UserUpdateRequest resource) {
    if (!ModelState.IsValid) return BadRequest(ModelState.GetErrorMessages());
    var user = (User) HttpContext.Items["User"]!;
    var id = user.Id;

    var result = await service.Update(id, resource);
    return result.ToResponse<UserResource>(this, mapper);
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
}
