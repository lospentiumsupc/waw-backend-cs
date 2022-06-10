using AutoMapper;
using WAW.API.Job.Domain.Models;
using WAW.API.Job.Resources;

namespace WAW.API.Job.Mapping;

public class ModelToResourceProfile: Profile {
  public ModelToResourceProfile() {
    CreateMap<Offer, OfferResource>();
  }
}
