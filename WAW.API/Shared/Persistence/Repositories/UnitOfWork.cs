using WAW.API.Shared.Domain.Repositories;
using WAW.API.Shared.Persistence.Contexts;

namespace WAW.API.Shared.Persistence.Repositories;

public class UnitOfWork : IUnitOfWork {
  private readonly AppDbContext context;

  public UnitOfWork(AppDbContext context) {
    this.context = context;
  }

  public async Task Complete() {
    await context.SaveChangesAsync();
  }
}
