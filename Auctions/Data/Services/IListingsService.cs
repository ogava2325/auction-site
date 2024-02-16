using Auctions.Models;

namespace Auctions.Data.Services;

public interface IListingsService
{
    IQueryable<Listing> GetAll();
    Task Add(Listing listing);
}