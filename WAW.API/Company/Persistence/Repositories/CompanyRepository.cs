using Microsoft.EntityFrameworkCore;
using WAW.API.Company.Domain.Repositories;
using WAW.API.Shared.Persistence.Contexts;
using WAW.API.Shared.Persistence.Repositories;

namespace WAW.API.Company.Persistence.Repositories;

using Domain.Models;

public class CompanyRepository : BaseRepository, ICompanyRepository {
  public CompanyRepository(AppDbContext context) : base(context) {}

  public async Task<IEnumerable<Company>> ListAll() {
    return await context.Companies.ToListAsync();
  }

  public async Task Add(Company company) {
    await context.Companies.AddAsync(company);
  }

  public async Task<Company?> FindById(long id) {
    return await context.Companies.FindAsync(id);
  }

  public async Task<Company?> FindByName(string name) {
    return await context.Companies.FirstOrDefaultAsync(p => p.Name == name);
  }

  public void Update(Company company) {
    context.Companies.Update(company);
  }

  public void Remove(Company company) {
    context.Companies.Remove(company);
  }
}
