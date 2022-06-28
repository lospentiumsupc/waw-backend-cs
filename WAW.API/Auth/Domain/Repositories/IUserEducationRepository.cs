using WAW.API.Auth.Domain.Models;

namespace WAW.API.Auth.Domain.Repositories;

public interface IUserEducationRepository {
  Task<UserEducation?> GetById(long id);

  Task<IList<UserEducation>> ListByUserId(long userId);

  Task Add(UserEducation userEducation);

  void Update(UserEducation userEducation);

  void Remove(UserEducation userEducation);
}
