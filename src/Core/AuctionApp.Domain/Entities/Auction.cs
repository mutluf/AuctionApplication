using AuctionApp.Domain.Entities.Common;

namespace AuctionApp.Domain.Entities
{
    public class Auction:BaseEntity
    {
        public Auction()
        {
            AppUserAuctions = new HashSet<AppUserAuction>();
        }

        public string Title { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public DateTime ExpirationTime { get; set; }
        public ICollection<AppUserAuction> AppUserAuctions { get; set; }
        public ICollection<Offer> Offers { get; set; }  
    }
}
