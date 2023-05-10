using Microsoft.AspNetCore.Mvc;
using TylorTrubPortfolio.Models;

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
            // feed id through db.
            SimonSays simon = new SimonSays();
            return View(simon);
        }
    }
}
