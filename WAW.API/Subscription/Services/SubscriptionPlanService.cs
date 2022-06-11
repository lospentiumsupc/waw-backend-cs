using WAW.API.Subscription.Domain.Models;
using WAW.API.Subscription.Domain.Repositories;
using WAW.API.Subscription.Domain.Services;
using WAW.API.Subscription.Domain.Services.Communication;

namespace WAW.API.Subscription.Services;

public class SubscriptionPlanService: ISubscriptionPlanService {
  private readonly ISubscriptionPlanRepository subscriptionPlanRepository;
  private readonly IUnitOfWork unitOfWork;

  public SubscriptionPlanService(ISubscriptionPlanRepository subscriptionPlanRepository, IUnitOfWork unitOfWork) {
    this.subscriptionPlanRepository = subscriptionPlanRepository;
    this.unitOfWork = unitOfWork;
  }

  public async Task<IEnumerable<SubscriptionPlan>> ListAll() {
    return await subscriptionPlanRepository.ListAll();
  }

  public async Task<SubscriptionPlanResponse> Create(SubscriptionPlan subscriptionPlan) {
    try {
      await subscriptionPlanRepository.Add(subscriptionPlan);
      await unitOfWork.Complete();
      return new SubscriptionPlanResponse(subscriptionPlan);
    } catch (Exception e) {
      return new SubscriptionPlanResponse($"An error occurred while saving the subscription plan: {e.Message}");
    }
  }

  public async Task<SubscriptionPlanResponse> Update(long id, SubscriptionPlan subscriptionPlan) {
    var current = await subscriptionPlanRepository.FindById(id);
    if (current == null) {
      return new SubscriptionPlanResponse("Subscription plan not found");
    }

    subscriptionPlan.CopyProperties(current);

    try {
      subscriptionPlanRepository.Update(current);
      await unitOfWork.Complete();
      return new SubscriptionPlanResponse(current);
    } catch (Exception e) {
      return new SubscriptionPlanResponse($"An error occurred while updating the forecast: {e.Message}");
    }
  }

  public async Task<SubscriptionPlanResponse> Delete(long id) {
    var current = await subscriptionPlanRepository.FindById(id);
    if (current == null) {
      return new SubscriptionPlanResponse("Forecast not found");
    }

    try {
      subscriptionPlanRepository.Remove(current);
      await unitOfWork.Complete();
      return new SubscriptionPlanResponse(current);
    } catch (Exception e) {
      return new SubscriptionPlanResponse($"An error occurred while deleting the forecast: {e.Message}");
    }
  }

}
