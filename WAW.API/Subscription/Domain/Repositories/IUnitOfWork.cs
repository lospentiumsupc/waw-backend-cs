namespace WAW.API.Subscription.Domain.Repositories;

public interface IUnitOfWork {
  Task Complete();
}
