using WAW.API.Auth.Domain.Models;

namespace WAW.API.Auth.Resources;

public interface IUserService {
  Task<IEnumerable<User>> ListAll();
  Task<UserResponse> Create(User user);
  Task<UserResponse> Update(long id, User user);
  Task<UserResponse> Delete(long id);
}
