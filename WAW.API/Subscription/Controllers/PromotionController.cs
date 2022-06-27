using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WAW.API.Subscription.Domain.Models;
using WAW.API.Subscription.Domain.Services.Communication;
using WAW.API.Subscription.Resource;

namespace WAW.API.Subscription.Controllers;

[ApiController]
[Route("[controller]")]
public class PromotionController: ControllerBase {
  private readonly IPromotionService promotionService;
  private readonly IMapper mapper;


  public PromotionController(IPromotionService promotionService, IMapper mapper) {
    this.promotionService = promotionService;
    this.mapper = mapper;
  }

  [HttpGet]
  public async Task<IEnumerable<PromotionResource>> GetAll() {
    var promotions = await promotionService.ListAll();
    return mapper.Map<IEnumerable<Promotion>, IEnumerable<PromotionResource>>(promotions);
  }
  [HttpDelete("{id:int}")]
  public async Task<IActionResult> DeleteAsync(int id) {
    var result = await promotionService.Delete(id);
    return result.ToResponse<PromotionResource>(this, mapper);
  }
}
