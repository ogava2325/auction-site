using Auctions.Models;
using Microsoft.EntityFrameworkCore;

namespace Auctions.Data.Services;

public class ListingService : IListingsService
{
    private readonly ApplicationDbContext _context;

    public ListingService(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public IQueryable<Listing> GetAll()
    {
        var applicationDbContext = _context.Listings.Include(l => l.User);
        return applicationDbContext;
    }

    public async Task Add(Listing listing)
    {
        _context.Listings.Add(listing);
        await _context.SaveChangesAsync();
    }
}