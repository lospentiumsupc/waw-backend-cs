using Microsoft.EntityFrameworkCore;
using WAW.API.Auth.Domain.Models;
using WAW.API.Auth.Domain.Repositories;
using WAW.API.Shared.Persistence.Contexts;
using WAW.API.Shared.Persistence.Repositories;

namespace WAW.API.Auth.Persistence.Repositories;

public class UserExperienceRepository : BaseRepository, IUserExperienceRepository {
  public UserExperienceRepository(AppDbContext context) : base(context) {}

  public async Task<UserExperience?> GetById(long id) {
    return await context.UserExperience.FindAsync(id);
  }

  public async Task<IList<UserExperience>> ListByUserId(long userId) {
    return await context.UserExperience.Where(x => x.UserId == userId).ToListAsync();
  }

  public async Task Add(UserExperience userExperience) {
    await context.UserExperience.AddAsync(userExperience);
  }

  public void Update(UserExperience userExperience) {
    context.UserExperience.Update(userExperience);
  }

  public void Remove(UserExperience userExperience) {
    context.UserExperience.Remove(userExperience);
  }
}
