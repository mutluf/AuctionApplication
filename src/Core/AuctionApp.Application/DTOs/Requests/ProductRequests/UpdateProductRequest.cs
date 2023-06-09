using MediatR;

namespace AuctionApp.Application.DTOs.Requests.ProductRequests
{
	public class UpdateProductRequest:IRequest
	{
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int BeginPrice { get; set; }
        public bool IsSold { get; set; }
    }
}
