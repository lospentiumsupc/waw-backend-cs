using AutoMapper;
using WAW.API.Job.Domain.Models;
using WAW.API.Job.Resources;

namespace WAW.API.Job.Mapping;

public class ResourceToModelProfile : Profile {
  public ResourceToModelProfile() {
    CreateMap<OfferRequest, Offer>();
  }
}
