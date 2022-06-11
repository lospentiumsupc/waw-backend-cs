using AutoMapper;
using WAW.API.Subscription.Domain.Models;
using WAW.API.Subscription.Resource;

namespace WAW.API.Subscription.Mapping;

public class ModelToResourceProfile: Profile {
  public ModelToResourceProfile() {
    CreateMap<SubscriptionPlan, SubscriptionPlanResource>();
  }
}
