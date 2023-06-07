using AuctionApp.Application.DTOs.Requests.AuctionRequests;
using AuctionApp.Application.DTOs.Responses.AuctionResponses;
using AuctionApp.Application.Repositories;
using AuctionApp.Domain.Entities;
using MediatR;

namespace AuctionApp.Application.Features.Queries.AuctionQueries
{
    public class GetLiveAuctionsHandler : IRequestHandler<GetLiveAuctionsRequest, GetLiveAuctionsResponse>
    {
        private readonly IProductRepository _productRepository;

        public GetLiveAuctionsHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<GetLiveAuctionsResponse> Handle(GetLiveAuctionsRequest request, CancellationToken cancellationToken)
        {
            List<Product> products = _productRepository.GetWhere(product => product.IsInAuction == true).ToList();
            return new()
            {
                Products = products,
            };
        }
    }
}
