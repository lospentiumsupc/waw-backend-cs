using WAW.API.Company.Domain.Repositories;
using WAW.API.Company.Domain.Services;
using WAW.API.Company.Domain.Services.Communication;
using WAW.API.Weather.Domain.Repositories;

namespace WAW.API.Company.Services;

using Domain.Models;

public class CompanyService: ICompanyService {
  private readonly ICompanyRepository repository;
  private readonly IUnitOfWork unitOfWork;

  public CompanyService(ICompanyRepository repository, IUnitOfWork unitOfWork) {
    this.repository = repository;
    this.unitOfWork = unitOfWork;
  }

  public Task<IEnumerable<Company>> ListAll() {
    return repository.ListAll();
  }

  public async Task<CompanyResponse> Create(Company company) {
    /*
    Pending validation

    var existingCompanyWithName = await repository.FindByName(company.Name);

    if (existingCompanyWithName != null) return new CompanyResponse("Company name already exists");
    */
    try {
      await repository.Add(company);
      await unitOfWork.Complete();
      return new CompanyResponse(company);
    } catch (Exception e) {
      return new CompanyResponse($"An error occurred while saving the company: {e.Message}");
    }
  }

  public async Task<CompanyResponse> Update(long id, Company company) {
    /*
    Pending validation

    var existingCompanyWithName = await repository.FindByName(company.Name);

    if (existingCompanyWithName != null) return new CompanyResponse("Company name already exists");
    */

    var currentCompany = await repository.FindById(id);

    if (currentCompany == null) return new CompanyResponse("Company not found.");

    // Modify company fields
    currentCompany.Name = company.Name;
    currentCompany.Address = company.Address;
    currentCompany.Email = company.Email;

    try {
      repository.Update(currentCompany);
      await unitOfWork.Complete();
      return new CompanyResponse(currentCompany);
    } catch (Exception e) {
      return new CompanyResponse($"An error occurred while updating the company: {e.Message}");
    }
  }

  public async Task<CompanyResponse> Delete(long id) {
    // Validate company
    var currentCompany = await repository.FindById(id);

    if (currentCompany == null) return new CompanyResponse("Company not found.");

    try {
      repository.Remove(currentCompany);
      await unitOfWork.Complete();
      return new CompanyResponse(currentCompany);
    } catch (Exception e) {
      return new CompanyResponse($"An error has occurred while deleting the company: {e.Message}");
    }
  }
}
