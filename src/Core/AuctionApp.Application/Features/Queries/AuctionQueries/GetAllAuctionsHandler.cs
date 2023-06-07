using AuctionApp.Application.DTOs;
using AuctionApp.Application.DTOs.Requests.AuctionRequests;
using AuctionApp.Application.DTOs.Responses.AuctionResponses;
using AuctionApp.Application.Repositories;
using AuctionApp.Domain.Entities;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AuctionApp.Application.Features.Queries.AuctionQueries
{
    public class GetAllAuctionsHandler : IRequestHandler<GetAllAuctionsRequest, GetAllAuctionsResponse>
    {
        private readonly IAuctionRepository _auctionRepository;
        private readonly IMapper _mapper;

        public GetAllAuctionsHandler(IAuctionRepository auctionRepository, IMapper mapper)
        {
            _auctionRepository = auctionRepository;
            _mapper = mapper;
        }

        public async Task<GetAllAuctionsResponse> Handle(GetAllAuctionsRequest request, CancellationToken cancellationToken)
        {
            List<Auction> auctions = _auctionRepository.Table.Include(product => product.Product).ToList();
            var auctions1 =_mapper.Map<IEnumerable<AuctionDTO>>(auctions);

            return new()
            {
                Auctions=auctions1
            };
        }
    }
}
