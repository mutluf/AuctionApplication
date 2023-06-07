using AuctionApp.Domain.Entities;

namespace AuctionApp.Application.DTOs.Responses.AuctionResponses
{
    public class GetAllAuctionsResponse
    {
        public IEnumerable<AuctionDTO> Auctions{ get; set; }
    }
}
