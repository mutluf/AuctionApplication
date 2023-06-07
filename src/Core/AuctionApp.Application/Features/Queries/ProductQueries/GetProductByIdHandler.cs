using AuctionApp.Application.DTOs;
using AuctionApp.Application.DTOs.Requests.ProductRequests;
using AuctionApp.Application.DTOs.Responses.ProductResponses;
using AuctionApp.Application.Repositories;
using AuctionApp.Domain.Entities;
using AutoMapper;
using MediatR;

namespace AuctionApp.Application.Features.Queries.ProductQueries
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdRequest,GetProductByIdResponse>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetProductByIdHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<GetProductByIdResponse> Handle(GetProductByIdRequest request, CancellationToken cancellationToken)
        {
            Product product = await _productRepository.GetByIdAysnc(request.Id.ToString());
            var response = _mapper.Map<GetProductByIdResponse>(product);

            return response;
        }
    }
}
