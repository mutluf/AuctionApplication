namespace AuctionApp.Application.DTOs.Responses.AuctionResponses
{
    public class GetAuctionByIdResponse
    {
        public int Id { get; set; }
        public ProductDTO Product { get; set; }
        public string Title { get; set; }
        public DateTime ExpirationTime { get; set; }
        public int OfferPrice { get; set; }
    }
}
