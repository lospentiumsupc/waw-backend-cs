using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WAW.API.Auth.Domain.Models;
using WAW.API.Auth.Resources;
using WAW.API.Shared.Extensions;

namespace WAW.API.Auth.Controllers;

[ApiController]
[Route("[controller]")]

public class UserController: ControllerBase {
  private readonly IUserService service;
  private readonly IMapper mapper;

  public UserController(IUserService service, IMapper mapper) {
    this.service = service;
    this.mapper = mapper;
  }

[HttpGet]
public async Task<IEnumerable<UserResource>> GetAll() {
  var users = await service.ListAll();
  return mapper.Map<IEnumerable<User>, IEnumerable<UserResource>>(users);
}
[HttpPost]
public async Task<IActionResult> Post([FromBody] UserRequest resource) {
  if (!ModelState.IsValid) {
    return BadRequest(ModelState.GetErrorMessages());
  }

  var user = mapper.Map<UserRequest, User>(resource);
  var result = await service.Create(user);
  return result.ToResponse<UserResource>(this, mapper);
}
[HttpDelete("{id:int}")]
public async Task<IActionResult> DeleteAsync(int id) {
  var result = await service.Delete(id);
  return result.ToResponse<UserResource>(this, mapper);
}

}
