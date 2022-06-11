using WAW.API.Subscription.Domain.Repositories;
using WAW.API.Subscription.Persistence.Contexts;

namespace WAW.API.Subscription.Persistence.Respositories;

public class UnitOfWork : IUnitOfWork {
  private readonly AppDbContext context;

  public UnitOfWork(AppDbContext context) {
    this.context = context;
  }


  public async Task Complete() {
    await context.SaveChangesAsync();
  }
}
