using AuctionApp.Application.DTOs.Responses.AuctionResponses;
using MediatR;

namespace AuctionApp.Application.DTOs.Requests.AuctionRequests
{
    public class GetLiveAuctionsRequest : IRequest<GetLiveAuctionsResponse>
    {
    }
}
