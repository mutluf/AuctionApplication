using AuctionApp.Application.Repositories;
using AuctionApp.Domain.Entities;
using AuctionApp.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace AuctionApp.Persistence.Repositories
{
    public class OfferRepository : GenericRepository<Offer>, IOfferRepository
    {
        public OfferRepository(AuctionAppDbContext context) : base(context)
        {
        }

        public async Task<Offer> GetOfferByUserIdAsync(string id)
        {
            var query = Table.AsQueryable().AsNoTracking();
            return await query.FirstOrDefaultAsync(data => data.UserId == int.Parse(id));
        }

    }
}
