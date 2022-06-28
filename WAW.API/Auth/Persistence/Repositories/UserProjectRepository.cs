using Microsoft.EntityFrameworkCore;
using WAW.API.Auth.Domain.Models;
using WAW.API.Auth.Domain.Repositories;
using WAW.API.Shared.Persistence.Contexts;
using WAW.API.Shared.Persistence.Repositories;

namespace WAW.API.Auth.Persistence.Repositories;

public class UserProjectRepository : BaseRepository, IUserProjectRepository {
  public UserProjectRepository(AppDbContext context) : base(context) {}

  public async Task<UserProject?> GetById(long id) {
    return await context.UserProject.FindAsync(id);
  }

  public async Task<IList<UserProject>> ListByUserId(long userId) {
    return await context.UserProject.Where(x => x.UserId == userId).Include(x => x.Image).ToListAsync();
  }

  public async Task Add(UserProject userProject) {
    await context.UserProject.AddAsync(userProject);
  }

  public void Update(UserProject userProject) {
    context.UserProject.Update(userProject);
  }

  public void Remove(UserProject userProject) {
    context.UserProject.Remove(userProject);
  }
}
