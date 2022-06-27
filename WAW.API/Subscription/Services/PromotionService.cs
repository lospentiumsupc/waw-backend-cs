using WAW.API.Subscription.Domain.Models;
using WAW.API.Subscription.Domain.Repositories;
using WAW.API.Subscription.Domain.Services.Communication;

namespace WAW.API.Subscription.Services;

public class PromotionService: IPromotionService {
  private readonly IPromotionRepository promotionRepository;
  private readonly IUnitOfWork unitOfWork;
  private readonly ISubscriptionPlanRepository subscriptionPlanRepository;

  public PromotionService(IPromotionRepository promotionRepository, IUnitOfWork unitOfWork, ISubscriptionPlanRepository subscriptionPlanRepository) {
    this.promotionRepository = promotionRepository;
    this.unitOfWork = unitOfWork;
    this.subscriptionPlanRepository = subscriptionPlanRepository;
  }

  public async Task<IEnumerable<Promotion>> ListAll() {
    return await promotionRepository.ListAll();
  }

  public async Task<IEnumerable<Promotion>> ListBySubscriptionPlanId(long subscriptionPlanId) {
    return await promotionRepository.FindBySubscriptionPlanId(subscriptionPlanId);
  }

  public async Task<PromotionResponse> Create(Promotion promotion) {
    try {
      await promotionRepository.Add(promotion);
      await unitOfWork.Complete();
      return new PromotionResponse(promotion);
    } catch (Exception e) {
      return new PromotionResponse($"An error occurred while saving the promotion: {e.Message}");
    }
  }

  public async Task<PromotionResponse> Update(long id, Promotion promotion) {
    var current = await promotionRepository.FindById(id);
    if (current == null) {
      return new PromotionResponse("Promotion not found");
    }

    promotion.CopyProperties(current);

    try {
      promotionRepository.Update(current);
      await unitOfWork.Complete();
      return new PromotionResponse(current);
    } catch (Exception e) {
      return new PromotionResponse($"An error occurred while updating the promotion: {e.Message}");
    }
  }

  public async Task<PromotionResponse> Delete(long id) {
    var current = await promotionRepository.FindById(id);
    if (current == null) {
      return new PromotionResponse("Forecast not found");
    }

    try {
      promotionRepository.Remove(current);
      await unitOfWork.Complete();
      return new PromotionResponse(current);
    } catch (Exception e) {
      return new PromotionResponse($"An error occurred while deleting the promotion: {e.Message}");
    }

  }
}
