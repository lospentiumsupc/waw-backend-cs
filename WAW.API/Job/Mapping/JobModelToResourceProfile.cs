using AutoMapper;
using WAW.API.Job.Domain.Models;
using WAW.API.Job.Resources;

namespace WAW.API.Job.Mapping;

public static class JobModelToResourceProfile {
  public static void Register(IProfileExpression profile) {
    profile.CreateMap<Offer, OfferResource>();
  }
}
