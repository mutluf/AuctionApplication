using AuctionApp.Domain.Entities;

namespace AuctionApp.Application.DTOs.Responses.ProductResponses
{
    public class GetAllProductsResponse
    {
        public IEnumerable<ProductDTO> Products{ get; set; }
    }
}
