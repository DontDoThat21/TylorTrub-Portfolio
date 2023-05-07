using Microsoft.AspNetCore.Mvc;

namespace TylorTrubPortfolio.Areas.Customer.Controllers
{
    public class GamesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
