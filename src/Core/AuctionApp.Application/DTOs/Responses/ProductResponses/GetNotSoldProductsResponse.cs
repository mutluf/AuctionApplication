using AuctionApp.Domain.Entities;

namespace AuctionApp.Application.DTOs.Responses.ProductResponses
{
    public class GetNotSoldProductsResponse
    {
        public IEnumerable<ProductDTO> Products { get; set; }
    }
}
