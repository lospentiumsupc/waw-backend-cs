using WAW.API.Auth.Domain.Models;
using WAW.API.Auth.Domain.Services.Communication;

namespace WAW.API.Auth.Domain.Services;

public interface IUserExperienceService {
  Task<IList<UserExperience>> ListByUserId(long userId);

  Task<UserExperienceResponse> Add(UserExperience request);

  Task<UserExperienceResponse> Update(long id, UserExperience request);

  Task<bool> Remove(long id, long userId);
}
