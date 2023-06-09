using AuctionApp.Domain.Entities;
using AuctionApp.Application.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AuctionApp.Application.Repositories
{
    public interface IOfferRepository:IGenericRepository<Offer>
    {
        public  Task<Offer> GetOfferByUserIdAsync(string id);
       
    }
}
