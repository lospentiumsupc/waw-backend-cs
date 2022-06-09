namespace WAW.API.Company.Domain.Repositories;

using WAW.API.Company.Domain.Models;

public interface ICompanyRepository {
  Task<IEnumerable<Company>> ListAll();
  Task Add(Company company);
  Task<Company?> FindById(int id);
  Task<Company?> FindByName(string name);
  void Update(Company company);
  void Remove(Company company);
}
