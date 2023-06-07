using MediatR;

namespace AuctionApp.Application.DTOs.Requests.AppUserAuctionRequest
{
    public class CreateAppUserAuctionRequest:IRequest
    {
        public int AppUserId { get; set; }
        public int AuctionId { get; set; }
    }
}
