using AuctionApp.Application.DTOs.Requests.AppUserAuctionRequest;
using AuctionApp.Application.DTOs.Requests.AuctionRequests;
using AuctionApp.Application.DTOs.Requests.OfferRequests;
using AuctionApp.Application.DTOs.Responses.AuctionResponses;
using AuctionApp.Domain.Entities;
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
        public async Task<JsonResult> Offer([FromBody]CreateOfferRequest request)
        {                     
            var data = await _mediator.Send(request);
            ViewBag.message = data.Status;
            return Json(new {message=data.Message,status=data.Status});

        }

        [HttpPost]
        public async Task<IActionResult> RegisterAuction(RegisterUserAuctionRequest request)
        {
            if (HttpContext.User?.Identity?.IsAuthenticated==false)
            {
                return RedirectToAction("Login", "Account", new { area = "Identity" });

            }
            await _mediator.Send(request);
            GetAuctionByIdRequest request1 = new() { Id = request.AuctionId };
            return RedirectToAction("AuctionDetail", request1);
        }
    }
}
