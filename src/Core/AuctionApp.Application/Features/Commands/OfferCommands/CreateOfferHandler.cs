using AuctionApp.Application.DTOs.Requests.OfferRequests;
using AuctionApp.Application.DTOs.Responses.OfferResponses;
using AuctionApp.Application.Features.Commands.OfferCommands;
using AuctionApp.Application.Repositories;
using AuctionApp.Domain.Entities;
using AutoMapper;
using MediatR;

namespace AuctionApp.Application.Features.Commands.OfferCommands
{
    public class CreateOfferHandler : IRequestHandler<CreateOfferRequest>
    {
        private readonly IMapper _mapper;
        private readonly IOfferRepository _offerRepository;
        public CreateOfferHandler(IMapper mapper, IOfferRepository offerRepository)
        {
            _mapper = mapper;
            _offerRepository = offerRepository;
        }
        public async Task<Unit> Handle(CreateOfferRequest request, CancellationToken cancellationToken)
        {
            Offer offer = _mapper.Map<Offer>(request);

            await _offerRepository.AddAysnc(offer);
            await _offerRepository.SaveAysnc();

            return Unit.Value;
        }
    }
}

