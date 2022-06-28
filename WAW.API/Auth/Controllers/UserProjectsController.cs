using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using WAW.API.Auth.Authorization.Attributes;
using WAW.API.Auth.Domain.Models;
using WAW.API.Auth.Domain.Services;
using WAW.API.Auth.Resources;

namespace WAW.API.Auth.Controllers;

[Authorize]
[ApiController]
[Route("users/me/projects")]
[SwaggerTag("Create, read, update and delete the current User projects info")]
public class UserProjectsController : ControllerBase {
  private readonly IUserProjectService service;
  private readonly IMapper mapper;

  public UserProjectsController(IUserProjectService service, IMapper mapper) {
    this.service = service;
    this.mapper = mapper;
  }

  [HttpGet]
  public async Task<IEnumerable<UserProjectResource>> ListAll() {
    var user = (User) HttpContext.Items["User"]!;
    var results = await service.ListByUserId(user.Id);
    return mapper.Map<IEnumerable<UserProject>, IEnumerable<UserProjectResource>>(results);
  }

  [HttpPost]
  public async Task<IActionResult> Create([FromBody] UserProjectRequest request) {
    var user = (User) HttpContext.Items["User"]!;
    var mapped = mapper.Map<UserProjectRequest, UserProject>(request);
    mapped.UserId = user.Id;
    var result = await service.Add(mapped);
    return result.ToResponse<UserProjectResource>(this, mapper);
  }

  [HttpPut("{id:long}")]
  public async Task<IActionResult> Update([FromRoute] long id, [FromBody] UserProjectRequest request) {
    var user = (User) HttpContext.Items["User"]!;
    var mapped = mapper.Map<UserProjectRequest, UserProject>(request);
    mapped.UserId = user.Id;
    var result = await service.Update(id, mapped);
    return result.ToResponse<UserProjectResource>(this, mapper);
  }

  [HttpDelete("{id:long}")]
  public async Task<IActionResult> Delete([FromRoute] long id) {
    var user = (User) HttpContext.Items["User"]!;
    var result = await service.Remove(id, user.Id);
    if (!result) return BadRequest("Unable to remove request entity");
    return NoContent();
  }
}
