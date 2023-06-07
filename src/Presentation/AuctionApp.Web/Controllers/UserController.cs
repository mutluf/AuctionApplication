using AuctionApp.Application.DTOs.Requests.UserRequests;
using AuctionApp.Application.DTOs.Responses.UserResponses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AuctionApp.Web.Controllers
{
    public class UserController : Controller
    {
        readonly IMediator _mediator;
        readonly IConfiguration _configuration;

        public UserController(IMediator mediator, IConfiguration configuration)
        {
            _mediator = mediator;
            _configuration = configuration;
        }
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest request)
        {
            CreateUserResponse response = await _mediator.Send(request);
            return View();
        }
    }
}
