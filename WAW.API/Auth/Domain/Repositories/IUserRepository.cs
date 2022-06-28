using WAW.API.Auth.Domain.Models;

namespace WAW.API.Auth.Domain.Repositories;

public interface IUserRepository {
  Task<IEnumerable<User>> ListAll();

  Task<IList<UserEducation>?> ListEducationByUser(long userId);

  Task<IList<UserExperience>?> ListExperienceByUser(long userId);

  Task<IList<UserProject>?> ListProjectsByUser(long userId);

  Task Add(User user);

  Task<User?> FindById(long id);

  Task<User?> FindByEmail(string email);

  bool ExistsByEmail(string email);

  void Update(User user);
}
