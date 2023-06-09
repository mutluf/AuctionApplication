using AuctionApp.Application.DTOs.Requests.AuctionRequests;
using AuctionApp.Application.DTOs.Requests.ProductRequests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AuctionApp.Web.Areas.Admin.Controllers
{
	[Area("admin")]
	public class AuctionsController : Controller
	{
		private readonly IMediator _mediator;

        public AuctionsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index(GetAllAuctionsRequest request)
		{			
			var auctions = await _mediator.Send(request);
			return View(auctions.Auctions);
		}
		[HttpGet]
		public async Task<IActionResult> CreateAuction()
		{
			GetIsNotInAuctionProductRequest requestProduct = new();
			var products = await _mediator.Send(requestProduct);
			ViewBag.Products = products.Products;
			return PartialView();
		}
        [HttpPost]
        public async Task<IActionResult> CreateAuction(CreateAuctionRequest request)
        {
            
            var response = await _mediator.Send(request);			           
            return RedirectToAction("Index");
        }
		[HttpGet]
		public async Task<IActionResult> UpdateAuction(GetAuctionByIdRequest request)
		{
			var response = await _mediator.Send(request);
            GetAllProductRequest requestProduct = new();
            var products = await _mediator.Send(requestProduct);
            ViewBag.Products = products.Products;
            return PartialView(response);
		}
		[HttpPost]
		public async Task<IActionResult> UpdateAuction(UpdateAuctionRequest request)
		{
			var response = await _mediator.Send(request);
			return RedirectToAction("Index");
		}
    }
}
