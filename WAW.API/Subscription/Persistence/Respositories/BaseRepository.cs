using WAW.API.Subscription.Persistence.Contexts;

namespace WAW.API.Subscription.Persistence.Respositories;

public class BaseRepository {

    protected readonly AppDbContext context;


    public BaseRepository(AppDbContext context) {
      this.context = context;
    }
}
