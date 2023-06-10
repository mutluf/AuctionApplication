using AuctionApp.Application.DTOs;
using AuctionApp.Application.DTOs.Requests.ProductRequests;
using AuctionApp.Application.DTOs.Responses.ProductResponses;
using AuctionApp.Application.Repositories;
using AuctionApp.Domain.Entities;
using AutoMapper;
using MediatR;

namespace AuctionApp.Application.Features.Queries.ProductQueries
{
    public class GetIsNotInAuctionHandler : IRequestHandler<GetIsNotInAuctionProductRequest, GetIsNotInAuctionProductResponse>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetIsNotInAuctionHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<GetIsNotInAuctionProductResponse> Handle(GetIsNotInAuctionProductRequest request, CancellationToken cancellationToken)
        {
            //List<Product> products = _productRepository.GetWhere(p => DateTime.Compare(p.BeginDate, DateTime.Now) == 1).ToList();
            List<Product> products = _productRepository.GetWhere(product => product.IsInAuction == false).ToList();
            var response = _mapper.Map<IEnumerable<ProductDTO>>(products);

            return new()
            {
                Products = response,
            };
        }
    }
}
