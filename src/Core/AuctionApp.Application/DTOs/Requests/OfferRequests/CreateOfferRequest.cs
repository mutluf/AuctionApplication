using AuctionApp.Application.DTOs.Responses.OfferResponses;
using MediatR;

namespace AuctionApp.Application.DTOs.Requests.OfferRequests
{
    public class CreateOfferRequest:IRequest<CreateOfferResponse>
    {
        public int OfferPrice { get; set; }
        public int AuctionId { get; set; }
        public int UserId { get; set; }
        public int lastOfferPrice { get; set; }
        public int beginPrice { get; set; }
    }
}
