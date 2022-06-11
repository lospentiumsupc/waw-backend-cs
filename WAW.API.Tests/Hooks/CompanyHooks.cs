using BoDi;
using Microsoft.AspNetCore.Mvc.Testing;
using WAW.API.Employers.Domain.Repositories;
using WAW.API.Shared.Domain.Repositories;
using WAW.API.Tests.Helpers;

namespace WAW.API.Tests.Hooks;

[Binding]
public class CompanyHooks {
  private readonly IObjectContainer objectContainer;

  public CompanyHooks(IObjectContainer objectContainer) {
    this.objectContainer = objectContainer;
  }

  [BeforeScenario]
  public async Task RegisterServices() {
    var factory = AppFactory.GetWebApplicationFactory();
    await ClearData(factory);
    objectContainer.RegisterInstanceAs(factory);
    var companiesRepository = factory.Services.GetService(typeof(ICompanyRepository)) as ICompanyRepository;
    objectContainer.RegisterInstanceAs(companiesRepository);
    var unitOfWork = factory.Services.GetService(typeof(IUnitOfWork)) as IUnitOfWork;
    objectContainer.RegisterInstanceAs(unitOfWork);
  }

  private static async Task ClearData(WebApplicationFactory<Program> factory) {
    if (factory.Services.GetService(typeof(ICompanyRepository)) is not ICompanyRepository companyRepository) {
      return;
    }

    var entities = await companyRepository.ListAll();
    foreach (var entity in entities) {
      companyRepository.Remove(entity);
    }
  }
}
