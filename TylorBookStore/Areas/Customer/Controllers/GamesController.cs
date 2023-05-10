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

        public IActionResult SimonSays(SimonSays simon)
        {
            // feed id through db.
            return View(simon);
        }

        [HttpGet]
        public IActionResult SimonBeginPlay(SimonSays says)
        {
            says.sequenceCounter += 1;
            return View(says);
        }
    }
}
