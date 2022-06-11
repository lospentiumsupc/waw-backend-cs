using WAW.API.Company.Domain.Services.Communication;

namespace WAW.API.Company.Domain.Services;

using Models;

public interface ICompanyService {
  Task<IEnumerable<Company>> ListAll();
  Task<CompanyResponse> Create(Company company);
  Task<CompanyResponse> Update(long id, Company company);
  Task<CompanyResponse> Delete(long id);
}
