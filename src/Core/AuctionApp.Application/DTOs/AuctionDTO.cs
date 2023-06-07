namespace AuctionApp.Application.DTOs
{
    public class AuctionDTO
    {
        public int Id { get; set; }
        public ProductDTO Product  { get; set; }
        public string Title { get; set; }
        public DateTime ExpirationTime { get; set; }

    }
}
