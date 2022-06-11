namespace WAW.API.Shared.Domain.Repositories;

public interface IUnitOfWork {
  Task Complete();
}
