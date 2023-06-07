using AuctionApp.Application.DTOs.Requests.ProductRequests;
using AuctionApp.Application.DTOs.Responses.ProductResponses;
using AuctionApp.Application.Repositories;
using AuctionApp.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AuctionApp.Web.Areas.Admin.Controllers
{
    [Area("admin")]
    public class ProductController : Controller
    {
        private readonly IMediator _mediator;
        public ProductController(IMediator mediator  )
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index(GetAllProductRequest request)
        {
            GetAllProductsResponse response = await _mediator.Send(request);
            
            return View(response.Products);
        }

        [HttpGet]
        public IActionResult CreateProduct()
        {
            return PartialView();
        }


        [HttpPost]
        public IActionResult CreateProduct(CreateProductRequest request)
        {
            _mediator.Send(request);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<IActionResult> UpdateProduct(GetProductByIdRequest request)
        {
            var response = await _mediator.Send(request);
            return PartialView(response);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductRequest request)
        {

            await _mediator.Send(request);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> DeleteProduct(DeleteProductRequest request)
        {
            await _mediator.Send(request);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> ProductDetail(GetProductByIdRequest request)
        {
            GetProductByIdResponse response = await _mediator.Send(request);
            return View(response);
        }
    }
}
