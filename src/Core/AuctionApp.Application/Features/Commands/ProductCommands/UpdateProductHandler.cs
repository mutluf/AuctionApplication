using AuctionApp.Application.DTOs.Requests.ProductRequests;
using AuctionApp.Application.Repositories;
using AuctionApp.Domain.Entities;
using AutoMapper;
using MediatR;

namespace AuctionApp.Application.Features.Commands.ProductCommands
{
	public class UpdateProductHandler : IRequestHandler<UpdateProductRequest>
	{
		private readonly IProductRepository _productRepository;
		private readonly IMapper _mapper;
		public UpdateProductHandler(IProductRepository productRepository, IMapper mapper)
		{
			_productRepository = productRepository;
			_mapper = mapper;
		}

		public async Task<Unit> Handle(UpdateProductRequest request, CancellationToken cancellationToken)
		{
			Product product = _mapper.Map<Product>(request);

			_productRepository.Update(product);
			await _productRepository.SaveAysnc();
			return Unit.Value;			
		}
	}
}
