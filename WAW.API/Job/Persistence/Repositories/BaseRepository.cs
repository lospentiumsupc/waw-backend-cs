using WAW.API.Job.Persistence.Contexts;

namespace WAW.API.Job.Persistence.Repositories;

public class BaseRepository {
  protected readonly AppDbContext context;

  public BaseRepository(AppDbContext context) {
    this.context = context;
  }
}
