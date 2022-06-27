using WAW.API.Auth.Domain.Models;
using WAW.API.Auth.Domain.Services.Communication;

namespace WAW.API.Auth.Domain.Services;

public interface IUserService {
  Task<IEnumerable<User>> ListAll();
  Task<User?> FindById(long id);
  Task<IList<User>?> BatchFindById(IEnumerable<long> ids);
  Task<UserResponse> Create(User user);
  Task<UserResponse> Update(long id, User user);
  Task<UserResponse> Delete(long id);
}
