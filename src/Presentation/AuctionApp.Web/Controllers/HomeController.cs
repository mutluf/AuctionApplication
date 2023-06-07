using AuctionApp.Application.DTOs.Requests.AppUserAuctionRequest;
using AuctionApp.Application.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AuctionApp.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMediator _mediator;
		private readonly IAuctionRepository _auctionRepository;
		public HomeController(IMediator mediator, IAuctionRepository auctionRepository)
		{
			_mediator = mediator;
			_auctionRepository = auctionRepository;
		}
		public async Task<IActionResult> Index()
        {
			var data = _auctionRepository.Table.Include(p => p.Product).FirstOrDefault(a => a.Id == 2);
			//CreateAppUserAuctionRequest request = new()
			//{
			//    AppUserId = 1,
			//    AuctionId = 2
			//};


			//await _mediator.Send(request);
			return View();
        }


    }
}
