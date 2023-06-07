using AuctionApp.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuctionApp.Domain.Entities
{
    public class AppUserAuction :BaseEntity

    {
        [NotMapped]
        public int Id { get; set; }
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public int AuctionId { get; set; }
        public Auction Auction { get; set; }
    }
}
