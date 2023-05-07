using Microsoft.AspNetCore.Mvc;

namespace TylorTrubPortfolio.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class GamesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Hangman()
        {
            return View();
        }

        public IActionResult SimonSays()
        {
            return View();
        }
    }
}
