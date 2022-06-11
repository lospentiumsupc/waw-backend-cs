using WAW.API.Employers.Domain.Repositories;
using WAW.API.Employers.Domain.Services;
using WAW.API.Employers.Persistence.Repositories;
using WAW.API.Employers.Services;

namespace WAW.API.Employers.Injection;

public static class CompanyInjections {
  public static void Register(IServiceCollection services) {
    services.AddScoped<ICompanyRepository, CompanyRepository>();
    services.AddScoped<ICompanyService, CompanyService>();
  }
}
