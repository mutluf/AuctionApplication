using AuctionApp.Application.DTOs.Requests.AppUserAuctionRequest;
using AuctionApp.Application.DTOs.Requests.AuctionRequests;
using AuctionApp.Application.DTOs.Requests.OfferRequests;
using AuctionApp.Application.DTOs.Responses.AuctionResponses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AuctionApp.Web.Controllers
{
    public class AuctionController : Controller
	{
		private readonly IMediator _mediator;

        public AuctionController(IMediator mediator)
        {
            _mediator = mediator;  
        }

        public async Task<IActionResult> Index(GetAllAuctionsRequest request)
		{
			GetAllAuctionsResponse response = await _mediator.Send(request);

			return View(response.Auctions);
		}

        [HttpGet]
        public async Task<IActionResult> AuctionDetail(GetAuctionByIdRequest request)
        {
            GetAuctionByIdResponse response = await _mediator.Send(request);
          return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Offer(CreateOfferRequest request)
        {
            request.UserId = 1;
            await _mediator.Send(request);
            return View("Index");
        }

        [HttpPost]
        public async Task<IActionResult> RegisterAuction(RegisterUserAuctionRequest request )
        {            
            await _mediator.Send(request);
            return RedirectToAction("AuctionDetail", request);
        }
    }
}
