using AuctionApp.Application.DTOs;
using AuctionApp.Application.DTOs.Requests.ProductRequests;
using AuctionApp.Application.DTOs.Responses.ProductResponses;
using AuctionApp.Application.Repositories;
using AuctionApp.Domain.Entities;
using AutoMapper;
using MediatR;

namespace AuctionApp.Application.Features.Queries.ProductQueries
{
    public class GetNotSoldProductsHandler : IRequestHandler<GetNotSoldProductsRequest, GetNotSoldProductsResponse>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetNotSoldProductsHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<GetNotSoldProductsResponse> Handle(GetNotSoldProductsRequest request, CancellationToken cancellationToken)
        {
            List<Product> products = _productRepository.GetWhere(product => product.IsSold == false).ToList();
            var response = _mapper.Map<IEnumerable<ProductDTO>>(products);

            return new()
            {
                Products = response,
            };
        }
    }
}
