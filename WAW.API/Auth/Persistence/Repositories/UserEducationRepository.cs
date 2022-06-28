using Microsoft.EntityFrameworkCore;
using WAW.API.Auth.Domain.Models;
using WAW.API.Auth.Domain.Repositories;
using WAW.API.Shared.Persistence.Contexts;
using WAW.API.Shared.Persistence.Repositories;

namespace WAW.API.Auth.Persistence.Repositories;

public class UserEducationRepository : BaseRepository, IUserEducationRepository {
  public UserEducationRepository(AppDbContext context) : base(context) {}

  public async Task<UserEducation?> GetById(long id) {
    return await context.UserEducation.FindAsync(id);
  }

  public async Task<IList<UserEducation>> ListByUserId(long userId) {
    return await context.UserEducation.Where(x => x.UserId == userId).ToListAsync();
  }

  public async Task Add(UserEducation userEducation) {
    await context.UserEducation.AddAsync(userEducation);
  }

  public void Update(UserEducation userEducation) {
    context.UserEducation.Update(userEducation);
  }

  public void Remove(UserEducation userEducation) {
    context.UserEducation.Remove(userEducation);
  }
}
