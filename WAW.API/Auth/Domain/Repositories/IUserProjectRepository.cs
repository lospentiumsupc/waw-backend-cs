using WAW.API.Auth.Domain.Models;

namespace WAW.API.Auth.Domain.Repositories;

public interface IUserProjectRepository {
  Task<UserProject?> GetById(long id);

  Task<IList<UserProject>> ListByUserId(long userId);

  Task Add(UserProject userProject);

  void Update(UserProject userProject);

  void Remove(UserProject userProject);
}
