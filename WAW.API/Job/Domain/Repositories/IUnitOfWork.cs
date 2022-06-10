namespace WAW.API.Job.Domain.Repositories;

public interface IUnitOfWork {
  Task Complete();
}
