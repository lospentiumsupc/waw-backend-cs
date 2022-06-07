using WAW.API.Weather.Domain.Repositories;
using WAW.API.Weather.Persistence.Contexts;

namespace WAW.API.Weather.Persistence.Repositories;

public class UnitOfWork : IUnitOfWork {
  private readonly AppDbContext context;

  public UnitOfWork(AppDbContext context) {
    this.context = context;
  }

  public async Task Complete() {
    await context.SaveChangesAsync();
  }
}
