using AuctionApp.Application.Repositories;
using AuctionApp.Domain.Entities;
using AuctionApp.Persistence.Context;

namespace AuctionApp.Persistence.Repositories
{
    public class AppUserAuctionRepository : GenericRepository<AppUserAuction>, IAppUserAuctionRepository
    {
        public AppUserAuctionRepository(AuctionAppDbContext context) : base(context)
        {
        }
    }
}
