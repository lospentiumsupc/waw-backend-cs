using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WAW.API.Subscription.Domain.Models;
using WAW.API.Subscription.Domain.Services;
using WAW.API.Subscription.Resource;

namespace WAW.API.Subscription.Controllers;


[ApiController]
[Route("[controller]")]
public class SubscriptionPlanController: ControllerBase {
  private readonly ISubscriptionPlanService _subscriptionPlanService;
  private readonly IMapper _mapper;
  public SubscriptionPlanController(ISubscriptionPlanService subscriptionPlanService, IMapper mapper) {
    _subscriptionPlanService = subscriptionPlanService;
    _mapper = mapper;
  }

  [HttpGet]
  public async Task<IEnumerable<SubscriptionPlanResource>> GetAll() {
    var subscriptionPlans = await _subscriptionPlanService.ListAll();
    return _mapper.Map<IEnumerable<SubscriptionPlan>, IEnumerable<SubscriptionPlanResource>>(subscriptionPlans);
  }

  [HttpDelete("{id:int}")]
  public async Task<IActionResult> DeleteAsync(int id) {
    var result = await _subscriptionPlanService.Delete(id);
    return result.ToResponse<SubscriptionPlanResource>(this, _mapper);
  }




}
