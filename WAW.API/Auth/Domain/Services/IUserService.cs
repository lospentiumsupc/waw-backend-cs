using WAW.API.Auth.Domain.Models;
using WAW.API.Auth.Domain.Services.Communication;
using WAW.API.Auth.Resources;

namespace WAW.API.Auth.Domain.Services;

public interface IUserService {
  Task<AuthResponse> Authenticate(AuthRequest request);
  Task<IEnumerable<User>> ListAll();
  Task<User?> FindById(long id);
  Task<IList<User>?> BatchFindById(IEnumerable<long> ids);
  Task<UserResponse> Register(User user);
  Task<UserResponse> Update(long id, User user);
  Task<UserResponse> Delete(long id);
}
