using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WAW.API.Job.Domain.Models;
using WAW.API.Job.Domain.Services;
using WAW.API.Job.Resources;
using WAW.API.Shared.Extensions;

namespace WAW.API.Job.Controllers;

[ApiController]
[Route("[controller]")]
public class OffersController : ControllerBase {
  private readonly IOfferService service;
  private readonly IMapper mapper;

  public OffersController(IOfferService service, IMapper mapper) {
    this.service = service;
    this.mapper = mapper;
  }

  [HttpGet]
  public async Task<IEnumerable<OfferResource>> GetAll() {
    var offers = await service.ListAll();
    return mapper.Map<IEnumerable<Offer>, IEnumerable<OfferResource>>(offers);
  }

  [HttpPost]
  public async Task<IActionResult> Post([FromBody] OfferRequest resource) {
    if (!ModelState.IsValid) return BadRequest(ModelState.GetErrorMessages());

    var offer = mapper.Map<OfferRequest, Offer>(resource);
    var result = await service.Create(offer);
    return result.ToResponse<OfferResource>(this, mapper);
  }

  [HttpPut("{id:int}")]
  public async Task<IActionResult> Put(int id, [FromBody] OfferRequest resource) {
    if (!ModelState.IsValid) return BadRequest(ModelState.GetErrorMessages());

    var offer = mapper.Map<OfferRequest, Offer>(resource);
    var result = await service.Update(id, offer);
    return result.ToResponse<OfferResource>(this, mapper);
  }

  [HttpDelete("{id:int}")]
  public async Task<IActionResult> DeleteAsync(int id) {
    var result = await service.Delete(id);
    return result.ToResponse<OfferResource>(this, mapper);
  }
}
