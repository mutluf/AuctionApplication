using MediatR;

namespace AuctionApp.Application.DTOs.Requests.AuctionRequests
{
    public class DeleteAuctionRequest:IRequest
    {
        public int Id { get; set; }
    }
}
