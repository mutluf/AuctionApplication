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
        private readonly IProductRepository _productRepository;
        public CreateAuctionHandler(IMapper mapper, IAuctionRepository auctionRepository, IProductRepository productRepository)
        {
            _mapper = mapper;
            _auctionRepository = auctionRepository;
            _productRepository = productRepository;
        }

        public async Task<Unit> Handle(CreateAuctionRequest request, CancellationToken cancellationToken)
        {
            Auction auction = _mapper.Map<Auction>(request);

            await _auctionRepository.AddAysnc(auction);
            await _auctionRepository.SaveAysnc();
            var product = await _productRepository.GetByIdAysnc(request.ProductId.ToString());
            product.IsInAuction = true;
            _productRepository.Update(product);
            await _productRepository.SaveAysnc();

            return Unit.Value;
        }
    }
}
