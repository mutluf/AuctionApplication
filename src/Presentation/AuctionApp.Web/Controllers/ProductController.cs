using AuctionApp.Application.DTOs.Requests.ProductRequests;
using AuctionApp.Application.DTOs.Responses.ProductResponses;
using AuctionApp.Application.Repositories;
using AuctionApp.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AuctionApp.Web.Controllers
{
	public class ProductController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IProductRepository _productRepository;
        public ProductController(IMediator mediator, IProductRepository productRepository)
        {
            _mediator = mediator;
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            GetIsNotInAuctionProductRequest request = new();
            var products =await _mediator.Send(request);

            return View(products.Products);
        }

        [HttpGet]
        public async Task<IActionResult> ProductDetail(GetProductByIdRequest request)
        {          
            GetProductByIdResponse response = await _mediator.Send(request);
            return View(response);
        }
    }
}
