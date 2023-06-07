using AuctionApp.Application.DTOs.Requests.ProductRequests;
using AuctionApp.Application.DTOs.Responses.ProductResponses;
using AuctionApp.Application.DTOs;
using AuctionApp.Application.Repositories;
using AuctionApp.Domain.Entities;
using AutoMapper;
using MediatR;

namespace AuctionApp.Application.Features.Queries.ProductQueries
{
    public class GetAllProductsHandler : IRequestHandler<GetAllProductRequest, GetAllProductsResponse>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetAllProductsHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<GetAllProductsResponse> Handle(GetAllProductRequest request, CancellationToken cancellationToken)
        {
            List<Product> products = _productRepository.GetAll();
            var response =_mapper.Map<IEnumerable<ProductDTO>>(products);

            return new()
            {
                Products = response,
            };
        }
    }
}
