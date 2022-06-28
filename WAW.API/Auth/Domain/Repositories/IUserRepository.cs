using WAW.API.Auth.Domain.Models;

namespace WAW.API.Auth.Domain.Repositories;

public interface IUserRepository {
  Task<IEnumerable<User>> ListAll();

  Task Add(User user);

  Task<User?> FindById(long id);

  Task<User?> FindByEmail(string email);

  bool ExistsByEmail(string email);

  void Update(User user);

  void Remove(User user);
}
