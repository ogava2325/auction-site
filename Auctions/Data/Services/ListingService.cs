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

    public async Task<Listing> GetById(int? id)
    {
        var listing = await _context.Listings
            .Include(l => l.User)
            .Include(l => l.Comments)
            .Include(l => l.Bids)
            .ThenInclude(l => l.User)
            .FirstOrDefaultAsync(m => m.Id == id);
        return listing;
    }

    public async Task SaveChanges()
    {
        await _context.SaveChangesAsync();
    }
}