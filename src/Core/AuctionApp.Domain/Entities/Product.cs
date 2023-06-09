using AuctionApp.Domain.Entities.Common;

namespace AuctionApp.Domain.Entities
{
    public class Product:BaseEntity
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; } = "https://loremflickr.com/320/240/art";
		public int BeginPrice { get; set; }
        public bool? IsSold { get; set; } 
        public DateTime BeginDate { get; set; }
        public bool? IsInAuction { get; set; } = false;

        //public Buying? Buying { get; set; }
        //public int BuyingId { get; set; }
    }
}
