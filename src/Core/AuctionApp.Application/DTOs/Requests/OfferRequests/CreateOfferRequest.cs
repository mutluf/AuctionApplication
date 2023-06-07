using MediatR;

namespace AuctionApp.Application.DTOs.Requests.OfferRequests
{
    public class CreateOfferRequest:IRequest
    {
        public int OfferPrice { get; set; }
        public int AuctionId { get; set; }
        public int UserId { get; set; }
    }
}
