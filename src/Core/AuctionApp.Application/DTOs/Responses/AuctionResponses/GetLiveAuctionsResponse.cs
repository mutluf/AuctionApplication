using AuctionApp.Domain.Entities;

namespace AuctionApp.Application.DTOs.Responses.AuctionResponses
{
    public class GetLiveAuctionsResponse
    {
        public List<AuctionDTO> Auctions { get; set; }
    }
}
