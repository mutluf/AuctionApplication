using AuctionApp.Application.DTOs;
using AuctionApp.Application.DTOs.Requests.AuctionRequests;
using AuctionApp.Application.DTOs.Responses.AuctionResponses;
using AuctionApp.Application.Repositories;
using AuctionApp.Domain.Entities;
using AutoMapper;
using MediatR;

namespace AuctionApp.Application.Features.Queries.AuctionQueries
{
    public class GetLiveAuctionsHandler : IRequestHandler<GetLiveAuctionsRequest, GetLiveAuctionsResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAuctionRepository _auctionRepository;


        public GetLiveAuctionsHandler(IMapper mapper, IAuctionRepository auctionRepository)
        {
            _mapper = mapper;
            _auctionRepository = auctionRepository;
        }

        public async Task<GetLiveAuctionsResponse> Handle(GetLiveAuctionsRequest request, CancellationToken cancellationToken)
        {
            List<Auction> auctions = _auctionRepository.GetWhere(auction => DateTime.Compare(auction.ExpirationTime, DateTime.Now) == 1).ToList();
            var response = _mapper.Map<List<AuctionDTO>>(auctions);

            return new()
            {
                Auctions = response,
            };
        }
    }
}
