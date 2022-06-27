using System.Net.Mime;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WAW.API.Subscription.Domain.Models;
using WAW.API.Subscription.Domain.Services.Communication;
using WAW.API.Subscription.Resource;

namespace WAW.API.Subscription.Controllers;

[ApiController]
[Route("/api/v1/subscriptionplans/{subscriptionPlanId}/promotions")]
[Produces(MediaTypeNames.Application.Json)]
public class SubscriptionPlanPromotionController {
  private readonly IPromotionService promotionService;
  private readonly IMapper mapper;


  public SubscriptionPlanPromotionController(IPromotionService promotionService, IMapper mapper) {
    this.promotionService = promotionService;
    this.mapper = mapper;
  }

  [HttpGet]
  public async Task<IEnumerable<PromotionResource>> GetAllBySubscriptionPlanIdAsync(long subscriptionPlanId)
  {
    var promotions = await promotionService.ListBySubscriptionPlanId(subscriptionPlanId);
    var resources = mapper.Map<IEnumerable<Promotion>, IEnumerable<PromotionResource>>(promotions);
    return resources;
  }


}
