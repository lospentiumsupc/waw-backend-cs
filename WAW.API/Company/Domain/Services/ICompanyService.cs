using WAW.API.Company.Domain.Services.Communication;

namespace WAW.API.Company.Domain.Services;

using WAW.API.Company.Domain.Models;

public interface ICompanyService {
  Task<IEnumerable<Company>> ListAll();
  Task<CompanyResponse> Create(Company company);
  Task<CompanyResponse> Update(int id, Company company);
  Task<CompanyResponse> Delete(int id);
}
