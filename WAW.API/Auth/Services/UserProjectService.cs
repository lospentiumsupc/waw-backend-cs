using WAW.API.Auth.Domain.Models;
using WAW.API.Auth.Domain.Repositories;
using WAW.API.Auth.Domain.Services;
using WAW.API.Auth.Domain.Services.Communication;
using WAW.API.Shared.Domain.Repositories;

namespace WAW.API.Auth.Services;

public class UserProjectService : IUserProjectService {
  private readonly IUserProjectRepository repository;
  private readonly IUnitOfWork unitOfWork;

  public UserProjectService(IUserProjectRepository repository, IUnitOfWork unitOfWork) {
    this.repository = repository;
    this.unitOfWork = unitOfWork;
  }

  public Task<IList<UserProject>> ListByUserId(long userId) {
    return repository.ListByUserId(userId);
  }

  public async Task<UserProjectResponse> Add(UserProject request) {
    try {
      await repository.Add(request);
      await unitOfWork.Complete();
      return new UserProjectResponse(request);
    } catch (Exception e) {
      return new UserProjectResponse($"An error occurred while saving the projects information: {e.Message}");
    }
  }

  public async Task<UserProjectResponse> Update(long id, UserProject request) {
    var current = await repository.GetById(id);
    if (current == null) {
      return new UserProjectResponse("Project information not found");
    }

    if (current.UserId != request.UserId) {
      return new UserProjectResponse("Unauthorized");
    }

    current.CopyFrom(request);

    try {
      repository.Update(current);
      await unitOfWork.Complete();
      return new UserProjectResponse(current);
    } catch (Exception e) {
      return new UserProjectResponse($"An error occurred while saving the project information: {e.Message}");
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
