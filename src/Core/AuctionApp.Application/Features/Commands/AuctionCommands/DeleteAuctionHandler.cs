using AuctionApp.Application.DTOs.Requests.AuctionRequests;
using AuctionApp.Application.Repositories;
using AuctionApp.Domain.Entities;
using MediatR;

namespace AuctionApp.Application.Features.Commands.AuctionCommands
{
    public class DeleteAuctionHandler : IRequestHandler<DeleteAuctionRequest>
    {
        private readonly IAuctionRepository _auctionRepository;

        public DeleteAuctionHandler(IAuctionRepository auctionRepository)
        {
            _auctionRepository = auctionRepository;
        }

        public async Task<Unit> Handle(DeleteAuctionRequest request, CancellationToken cancellationToken)
        {
            Auction auction = await _auctionRepository.GetByIdAysnc(request.Id.ToString());
            _auctionRepository.Delete(auction);
            await _auctionRepository.SaveAysnc();

            return Unit.Value;            
        }
    }
}
