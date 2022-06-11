using WAW.API.Job.Domain.Models;
using WAW.API.Job.Domain.Services.Communication;

namespace WAW.API.Job.Domain.Services;

public interface IOfferService {
  Task<IEnumerable<Offer>> ListAll();
  Task<OfferResponse> Create(Offer offer);
  Task<OfferResponse> Update(long id, Offer offer);
  Task<OfferResponse> Delete(long id);
}
