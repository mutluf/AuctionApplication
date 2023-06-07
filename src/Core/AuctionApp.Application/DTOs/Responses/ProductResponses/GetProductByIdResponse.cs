using AuctionApp.Domain.Entities;

namespace AuctionApp.Application.DTOs.Responses.ProductResponses
{
    public class GetProductByIdResponse
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; } = "https://loremflickr.com/320/240/art";
        public DateTime BeginDate { get; set; }
        public int BeginPrice { get; set; }
        public bool? IsInAuction { get; set; }
    }
}
