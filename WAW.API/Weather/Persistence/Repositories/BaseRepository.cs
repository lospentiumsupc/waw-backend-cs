using WAW.API.Weather.Persistence.Contexts;

namespace WAW.API.Weather.Persistence.Repositories;

public class BaseRepository {
  protected readonly AppDbContext context;

  public BaseRepository(AppDbContext context) {
    this.context = context;
  }
}
