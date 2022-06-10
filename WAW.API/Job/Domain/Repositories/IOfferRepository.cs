using WAW.API.Job.Domain.Models;

namespace WAW.API.Job.Domain.Repositories;

public interface IOfferRepository {
  Task<IEnumerable<Offer>> ListAll();

  Task Add(Offer forecast);

  Task<Offer?> FindById(long id);

  void Update(Offer forecast);

  void Remove(Offer forecast);
}
