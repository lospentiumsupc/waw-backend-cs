using WAW.API.Auth.Domain.Models;
using WAW.API.Auth.Domain.Services.Communication;

namespace WAW.API.Auth.Domain.Services;

public interface IUserProjectService {
  Task<IList<UserProject>> ListByUserId(long userId);

  Task<UserProjectResponse> Add(UserProject request);

  Task<UserProjectResponse> Update(long id, UserProject request);

  Task<bool> Remove(long id, long userId);
}
