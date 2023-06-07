using AuctionApp.Application.DTOs.Requests.AppUserAuctionRequest;
using AuctionApp.Application.Repositories;
using AuctionApp.Domain.Entities;
using AutoMapper;
using MediatR;

namespace AuctionApp.Application.Features.Commands
{
    public class CreateAppUserAuctionHandler : IRequestHandler<CreateAppUserAuctionRequest>
    {
        private readonly IMapper _mapper;
        private readonly IAppUserAuctionRepository _appUserAuctionRepository;
        public CreateAppUserAuctionHandler(IMapper mapper, IAppUserAuctionRepository appUserAuctionRepository)
        {
            _mapper = mapper;
            _appUserAuctionRepository = appUserAuctionRepository;
        }

        public async Task<Unit> Handle(CreateAppUserAuctionRequest request, CancellationToken cancellationToken)
        {
            AppUserAuction userAuction = _mapper.Map<AppUserAuction>(request);
            await _appUserAuctionRepository.AddAysnc(userAuction);
            await _appUserAuctionRepository.SaveAysnc();

            return Unit.Value;
        }
    }
}
