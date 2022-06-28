using WAW.API.Auth.Domain.Models;
using WAW.API.Auth.Domain.Services.Communication;

namespace WAW.API.Auth.Domain.Services;

public interface IUserEducationService {
  Task<IList<UserEducation>> ListByUserId(long userId);

  Task<UserEducationResponse> Add(UserEducation request);

  Task<UserEducationResponse> Update(long id, UserEducation request);

  Task<bool> Remove(long id, long userId);
}
