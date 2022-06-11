using WAW.API.Shared.Domain.Service.Communication;

namespace WAW.API.Company.Domain.Services.Communication;

using Models;

public class CompanyResponse : BaseResponse<Company> {
  public CompanyResponse(string message) : base(message) {}
  public CompanyResponse(Company resource) : base(resource) {}
}
