using WAW.API.Auth.Domain.Models;
using WAW.API.Auth.Domain.Repositories;
using WAW.API.Auth.Domain.Services;
using WAW.API.Auth.Domain.Services.Communication;
using WAW.API.Shared.Domain.Repositories;

namespace WAW.API.Auth.Services;

public class UserExperienceService : IUserExperienceService {
  private readonly IUserExperienceRepository repository;
  private readonly IUnitOfWork unitOfWork;

  public UserExperienceService(IUserExperienceRepository repository, IUnitOfWork unitOfWork) {
    this.repository = repository;
    this.unitOfWork = unitOfWork;
  }

  public Task<IList<UserExperience>> ListByUserId(long userId) {
    return repository.ListByUserId(userId);
  }

  public async Task<UserExperienceResponse> Add(UserExperience request) {
    try {
      await repository.Add(request);
      await unitOfWork.Complete();
      return new UserExperienceResponse(request);
    } catch (Exception e) {
      return new UserExperienceResponse($"An error occurred while saving the experience information: {e.Message}");
    }
  }

  public async Task<UserExperienceResponse> Update(long id, UserExperience request) {
    var current = await repository.GetById(id);
    if (current == null) {
      return new UserExperienceResponse("Experience information not found");
    }

    if (current.UserId != request.UserId) {
      return new UserExperienceResponse($"Unauthorized");
    }

    current.CopyFrom(request);

    try {
      repository.Update(current);
      await unitOfWork.Complete();
      return new UserExperienceResponse(current);
    } catch (Exception e) {
      return new UserExperienceResponse($"An error occurred while saving the experience information: {e.Message}");
    }
  }

  public async Task<bool> Remove(long id, long userId) {
    var current = await repository.GetById(id);
    if (current == null) {
      return false;
    }

    if (current.UserId != userId) {
      return false;
    }

    try {
      repository.Remove(current);
      await unitOfWork.Complete();
      return true;
    } catch (Exception) {
      return false;
    }
  }
}
