using AuctionApp.Application.Repositories;
using AuctionApp.Domain.Entities;
using AuctionApp.Persistence.Context;

namespace AuctionApp.Persistence.Repositories
{
    public class AuctionRepository : GenericRepository<Auction>, IAuctionRepository
    {
        public AuctionRepository(AuctionAppDbContext context) : base(context)
        {
        }
    }
}
