using WAW.API.Company.Domain.Repositories;
using WAW.API.Company.Domain.Services;
using WAW.API.Company.Persistence.Repositories;
using WAW.API.Company.Services;

namespace WAW.API.Company.Injection;

public static class CompanyInjections {
  public static void Register(IServiceCollection services) {
    services.AddScoped<ICompanyRepository, CompanyRepository>();
    services.AddScoped<ICompanyService, CompanyService>();
  }
}
