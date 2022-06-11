using Microsoft.EntityFrameworkCore;
using WAW.API.Auth.Domain.Models;
using WAW.API.Auth.Domain.Repositories;
using WAW.API.Weather.Persistence.Contexts;
using WAW.API.Weather.Persistence.Repositories;

namespace WAW.API.Auth.Persistence.Repositories;

public class UserRepository : BaseRepository, IUserRepository {
  public UserRepository(AppDbContext context) : base(context) {}

  public async Task<IEnumerable<User>> ListAll() {
    return await context.Users.ToListAsync();
  }

  public async Task Add(User user) {
    await context.Users.AddAsync(user);
  }

  public async Task<User?> FindById(long id) {
    return await context.Users.FindAsync(id);
  }

  public void Update(User user) {
    context.Users.Update(user);
  }

  public void Remove(User user) {
    context.Users.Remove(user);
  }
}
