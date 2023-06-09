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

    public class GetAuctionByIdHandler : IRequestHandler<GetAuctionByIdRequest, GetAuctionByIdResponse>
    {
        private readonly IAuctionRepository _auctionRepository;
        private readonly IMapper _mapper;

        public GetAuctionByIdHandler(IAuctionRepository auctionRepository, IMapper mapper)
        {
            _auctionRepository = auctionRepository;
            _mapper = mapper;
        }

        public async Task<GetAuctionByIdResponse> Handle(GetAuctionByIdRequest request, CancellationToken cancellationToken)
        {
            var auction = _auctionRepository.Table.Include(p => p.Product).Include(o => o.Offers.OrderByDescending(o => o.OfferPrice)).FirstOrDefault(auction => auction.Id == request.Id);
            int maxOffer = 0;
            try
            {
                maxOffer = auction.Offers.Max(o => o.OfferPrice);
            }
            catch (Exception)
            {

                
            }
            var auctionResponse = _mapper.Map<GetAuctionByIdResponse>(auction);
            auctionResponse.OfferPrice = maxOffer;

            return auctionResponse;
        }
    }


}
