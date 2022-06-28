using WAW.API.Auth.Domain.Models;
using WAW.API.Auth.Domain.Repositories;
using WAW.API.Auth.Domain.Services;
using WAW.API.Auth.Domain.Services.Communication;
using WAW.API.Shared.Domain.Repositories;

namespace WAW.API.Auth.Services;

public class UserEducationService : IUserEducationService {
  private readonly IUserEducationRepository repository;
  private readonly IUnitOfWork unitOfWork;

  public UserEducationService(IUserEducationRepository repository, IUnitOfWork unitOfWork) {
    this.repository = repository;
    this.unitOfWork = unitOfWork;
  }

  public Task<IList<UserEducation>> ListByUserId(long userId) {
    return repository.ListByUserId(userId);
  }

  public async Task<UserEducationResponse> Add(UserEducation request) {
    try {
      await repository.Add(request);
      await unitOfWork.Complete();
      return new UserEducationResponse(request);
    } catch (Exception e) {
      return new UserEducationResponse($"An error occurred while saving the education information: {e.Message}");
    }
  }

  public async Task<UserEducationResponse> Update(long id, UserEducation request) {
    var current = await repository.GetById(id);
    if (current == null) return new UserEducationResponse("Education information not found");

    if (current.UserId != request.UserId) {
      return new UserEducationResponse($"Unauthorized");
    }

    current.CopyFrom(request);

    try {
      repository.Update(current);
      await unitOfWork.Complete();
      return new UserEducationResponse(current);
    } catch (Exception e) {
      return new UserEducationResponse($"An error occurred while saving the education information: {e.Message}");
    }
  }

  public async Task<bool> Remove(long id, long userId) {
    var current = await repository.GetById(id);
    if (current == null) return false;

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
