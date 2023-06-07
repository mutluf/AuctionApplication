using AuctionApp.Application.DTOs.Requests.ProductRequests;
using AuctionApp.Application.Repositories;
using AuctionApp.Domain.Entities;
using MediatR;

namespace AuctionApp.Application.Features.Commands.ProductCommands
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductRequest>
    {
        private readonly IProductRepository _productRepository;

        public DeleteProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Unit> Handle(DeleteProductRequest request, CancellationToken cancellationToken)
        {
            Product product = await _productRepository.GetByIdAysnc(request.Id.ToString());
            _productRepository.Delete(product);

            await _productRepository.SaveAysnc();

            return Unit.Value;
        }
    }
}
