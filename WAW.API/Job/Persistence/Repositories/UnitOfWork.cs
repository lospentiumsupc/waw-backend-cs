using WAW.API.Job.Domain.Repositories;
using WAW.API.Job.Persistence.Contexts;

namespace WAW.API.Job.Persistence.Repositories;

public class UnitOfWork : IUnitOfWork{
  private readonly AppDbContext context;

  public UnitOfWork(AppDbContext context) {
    this.context = context;
  }

  public async Task Complete() {
    await context.SaveChangesAsync();
  }
}
