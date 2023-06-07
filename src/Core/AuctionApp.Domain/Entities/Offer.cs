using AuctionApp.Domain.Entities.Common;
using Microsoft.AspNetCore.Identity;

namespace AuctionApp.Domain.Entities
{
    public class Offer:BaseEntity
    {
        public int OfferPrice { get; set; }
        public Auction Auction { get; set; }
        public int AuctionId { get; set; }
        public AppUser User { get; set; }
        public int UserId { get; set; }
    }
}
