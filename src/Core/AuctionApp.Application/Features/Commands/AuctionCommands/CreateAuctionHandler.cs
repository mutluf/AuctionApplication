using AuctionApp.Application.DTOs.Requests.AuctionRequests;
using AuctionApp.Application.Repositories;
using AuctionApp.Domain.Entities;
using AutoMapper;
using MediatR;

namespace AuctionApp.Application.Features.Commands.AuctionCommands
{
    public class CreateAuctionHandler : IRequestHandler<CreateAuctionRequest>
    {
        private readonly IMapper _mapper;
        private readonly IAuctionRepository _auctionRepository;
        public CreateAuctionHandler(IMapper mapper, IAuctionRepository auctionRepository)
        {
            _mapper = mapper;
            _auctionRepository = auctionRepository;
        }

        public async Task<Unit> Handle(CreateAuctionRequest request, CancellationToken cancellationToken)
        {
            Auction auction = _mapper.Map<Auction>(request);

            await _auctionRepository.AddAysnc(auction);
            await _auctionRepository.SaveAysnc();

            return Unit.Value;
        }
    }
}
