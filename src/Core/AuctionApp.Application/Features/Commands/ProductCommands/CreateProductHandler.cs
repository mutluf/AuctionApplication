using AuctionApp.Application.DTOs.Requests.ProductRequests;
using AuctionApp.Application.DTOs.Responses.ProductResponses;
using AuctionApp.Application.Repositories;
using AuctionApp.Domain.Entities;
using AutoMapper;
using MediatR;

namespace AuctionApp.Application.Features.Commands.ProductCommands
{
    public class CreateProductHandler : IRequestHandler<CreateProductRequest, CreateProductResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;
        public CreateProductHandler(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        async Task<CreateProductResponse> IRequestHandler<CreateProductRequest, CreateProductResponse>.Handle(CreateProductRequest request, CancellationToken cancellationToken)
        {
            Product product= _mapper.Map<Product>(request);

            await _productRepository.AddAysnc(product);
            await _productRepository.SaveAysnc();

            return new()
            {
                Message = "Ürün başarıyla eklendi."
            };
        }
    }
}
