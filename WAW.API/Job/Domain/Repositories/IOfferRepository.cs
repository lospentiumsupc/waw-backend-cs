using WAW.API.Job.Domain.Models;

namespace WAW.API.Job.Domain.Repositories;

public interface IOfferRepository {
  Task<IEnumerable<Offer>> ListAll();

  Task Add(Offer offer);

  Task<Offer?> FindById(long id);

  void Update(Offer offer);

  void Remove(Offer offer);
}
