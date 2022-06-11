using System.Net.Mime;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using WAW.API.Company.Domain.Services;
using WAW.API.Company.Resources;
using WAW.API.Shared.Extensions;

namespace WAW.API.Company.Controllers;

using Domain.Models;

[ApiController]
[Route("[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Create, read, update and delete Companies")]
public class CompanyController : ControllerBase {
  private readonly ICompanyService service;
  private readonly IMapper mapper;

  public CompanyController(ICompanyService service, IMapper mapper) {
    this.service = service;
    this.mapper = mapper;
  }

  [HttpGet]
  [ProducesResponseType(typeof(IEnumerable<CompanyResource>), 200)]
  public async Task<IEnumerable<CompanyResource>> GetAll() {
    var companies = await service.ListAll();
    return mapper.Map<IEnumerable<Company>, IEnumerable<CompanyResource>>(companies);
  }

  [HttpPost]
  [ProducesResponseType(typeof(CompanyResource), 201)]
  [ProducesResponseType(typeof(List<string>), 400)]
  [ProducesResponseType(500)]
  [SwaggerResponse(201, "The company was created successfully", typeof(CompanyResource))]
  [SwaggerResponse(400, "The company data is invalid")]
  public async Task<IActionResult> Post([FromBody] CompanyRequest companyRequest) {
    if (!ModelState.IsValid) return BadRequest(ModelState.GetErrorMessages());

    var company = mapper.Map<CompanyRequest, Company>(companyRequest);
    var result = await service.Create(company);
    return result.ToResponse<CompanyResource>(this, mapper);
  }

  [HttpPut("{id:int}")]
  [ProducesResponseType(typeof(CompanyResource), 200)]
  [ProducesResponseType(typeof(List<string>), 400)]
  [ProducesResponseType(500)]
  [SwaggerResponse(200, "The company was updated successfully", typeof(CompanyResource))]
  [SwaggerResponse(400, "The company data is invalid")]
  public async Task<IActionResult> Put(int id, [FromBody] CompanyRequest companyRequest) {
    if (!ModelState.IsValid) return BadRequest(ModelState.GetErrorMessages());

    var company = mapper.Map<CompanyRequest, Company>(companyRequest);
    var result = await service.Update(id, company);
    return result.ToResponse<CompanyResource>(this, mapper);
  }

  [HttpDelete("{id:int}")]
  [ProducesResponseType(typeof(CompanyResource), 200)]
  [ProducesResponseType(typeof(List<string>), 400)]
  [ProducesResponseType(500)]
  [SwaggerResponse(200, "The company was deleted successfully", typeof(CompanyResource))]
  [SwaggerResponse(400, "The selected company to delete does not exist")]
  public async Task<IActionResult> DeleteAsync(int id) {
    var result = await service.Delete(id);
    return result.ToResponse<CompanyResource>(this, mapper);
  }
}
