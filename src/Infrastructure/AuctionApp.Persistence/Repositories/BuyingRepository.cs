using AuctionApp.Domain.Entities;
using AuctionApp.Persistence.Context;

namespace AuctionApp.Persistence.Repositories
{
    public class BuyingRepository : GenericRepository<Buying>
    {
        public BuyingRepository(AuctionAppDbContext context) : base(context)
        {
        }
    }
}
