using AuctionApp.Application.Repositories;
using AuctionApp.Domain.Entities;
using AuctionApp.Persistence.Context;
using AuctionApp.Persistence.Repositories;

namespace AuctionApp.Persistence.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(AuctionAppDbContext context) : base(context)
        {
        }
    }
}
