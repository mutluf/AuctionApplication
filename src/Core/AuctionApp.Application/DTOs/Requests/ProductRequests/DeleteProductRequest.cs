using MediatR;

namespace AuctionApp.Application.DTOs.Requests.ProductRequests
{
    public class DeleteProductRequest:IRequest
    {
        public int Id { get; set; }
    }
}
