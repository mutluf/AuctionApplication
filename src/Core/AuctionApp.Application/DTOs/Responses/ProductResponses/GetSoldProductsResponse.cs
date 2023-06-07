using AuctionApp.Domain.Entities;

namespace AuctionApp.Application.DTOs.Responses.ProductResponses
{
    public class GetSoldProductsResponse
    {
        public IEnumerable<ProductDTO> Products { get; set; }
    }
}
