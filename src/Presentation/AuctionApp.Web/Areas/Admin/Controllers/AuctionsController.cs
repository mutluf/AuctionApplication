using Microsoft.AspNetCore.Mvc;

namespace AuctionApp.Web.Areas.Admin.Controllers
{
	public class AuctionsController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
