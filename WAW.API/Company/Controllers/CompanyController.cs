using System.Net.Mime;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WAW.API.Company.Domain.Services;
using WAW.API.Company.Resources;
using WAW.API.Shared.Extensions;

namespace WAW.API.Company.Controllers;

using WAW.API.Company.Domain.Models;

[ApiController]
[Route("[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class CompanyController: ControllerBase {
  private readonly ICompanyService service;
  private readonly IMapper mapper;

  public CompanyController(ICompanyService service, IMapper mapper) {
    this.service = service;
    this.mapper = mapper;
  }

  [HttpGet]
  public async Task<IEnumerable<CompanyResource>> GetAll() {
    var companies = await service.ListAll();
    return mapper.Map<IEnumerable<Company>, IEnumerable<CompanyResource>>(companies);
  }

  [HttpPost]
  public async Task<IActionResult> Post([FromBody] CompanyRequest companyRequest) {
    if (!ModelState.IsValid) {
      return BadRequest(ModelState.GetErrorMessages());
    }

    var company = mapper.Map<CompanyRequest, Company>(companyRequest);
    var result = await service.Create(company);
    return result.ToResponse<CompanyResource>(this, mapper);
  }

  [HttpPut("{id:int}")]
  public async Task<IActionResult> Put(int id, [FromBody] CompanyRequest companyRequest) {
    if (!ModelState.IsValid) {
      return BadRequest(ModelState.GetErrorMessages());
    }

    var company = mapper.Map<CompanyRequest, Company>(companyRequest);
    var result = await service.Update(id, company);
    return result.ToResponse<CompanyResource>(this, mapper);
  }

  [HttpDelete("{id:int}")]
  public async Task<IActionResult> DeleteAsync(int id) {
    var result = await service.Delete(id);
    return result.ToResponse<CompanyResource>(this, mapper);
  }
}
