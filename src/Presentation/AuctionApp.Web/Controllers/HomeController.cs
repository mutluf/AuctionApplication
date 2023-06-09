using AuctionApp.Application.BackgroundService;
using AuctionApp.Application.DTOs.Requests.AppUserAuctionRequest;
using AuctionApp.Application.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace AuctionApp.Web.Controllers
{
    public class HomeController : Controller
    {
       private readonly IUserBackgroundJob _job;

        public HomeController(IUserBackgroundJob job)
        {
            _job = job;
        }

        public async Task<IActionResult> Index()
        {
            _job.AddEnque(() => Console.WriteLine("selam"));
            return View();
        }


    }
}
