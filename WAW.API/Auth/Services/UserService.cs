using WAW.API.Auth.Domain.Models;
using WAW.API.Auth.Domain.Repositories;
using WAW.API.Auth.Resources;
using WAW.API.Weather.Domain.Repositories;

namespace WAW.API.Auth.Services;

public class UserService: IUserService {
  private readonly IUserRepository repository;
  private readonly IUnitOfWork unitOfWork;

  public UserService(IUserRepository repository, IUnitOfWork unitOfWork) {
    this.repository = repository;
    this.unitOfWork = unitOfWork;
  }

  public Task<IEnumerable<User>> ListAll() {
    return repository.ListAll();
  }

  public async Task<UserResponse> Create(User user) {
    try {
      await repository.Add(user);
      await unitOfWork.Complete();
      return new UserResponse(user);
    } catch (Exception e) {
      return new UserResponse($"An error occurred while saving the user: {e.Message}");
    }
  }

  public async Task<UserResponse> Update(long id, User user) {
    var current = await repository.FindById(id);
    if (current == null) {
      return new UserResponse("User not found");
    }

    user.CopyProperties(current);

    try {
      repository.Update(current);
      await unitOfWork.Complete();
      return new UserResponse(current);
    } catch (Exception e) {
      return new UserResponse($"An error occurred while updating the user: {e.Message}");
    }
  }

  public async Task<UserResponse> Delete(long id) {
    var current = await repository.FindById(id);
    if (current == null) {
      return new UserResponse("User not found");
    }

    try {
      repository.Remove(current);
      await unitOfWork.Complete();
      return new UserResponse(current);
    } catch (Exception e) {
      return new UserResponse($"An error occurred while deleting the user: {e.Message}");
    }
  }
}
