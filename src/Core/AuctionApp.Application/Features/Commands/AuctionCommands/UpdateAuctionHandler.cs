using AuctionApp.Application.DTOs.Requests.AuctionRequests;
using AuctionApp.Application.DTOs.Responses.AuctionResponses;
using AuctionApp.Application.Repositories;
using AuctionApp.Domain.Entities;
using AutoMapper;
using MediatR;


namespace AuctionApp.Application.Features.Commands.AuctionCommands
{
    public class UpdateAuctionHandler : IRequestHandler<UpdateAuctionRequest, UpdateAuctionResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAuctionRepository _auctionRepository;

        public UpdateAuctionHandler(IMapper mapper, IAuctionRepository auctionRepository)
        {
            _mapper = mapper;
            _auctionRepository = auctionRepository;
        }

        public async Task<UpdateAuctionResponse> Handle(UpdateAuctionRequest request, CancellationToken cancellationToken)
        {
            Auction auction = _mapper.Map<Auction>(request);    
             _auctionRepository.Update(auction);
            await _auctionRepository.SaveAysnc();

            return new()
            {

            };
        }
    }
}
