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

            //if (@Model.sequenceCounter == -1)
            //{
            //    // new game
            //    simon.sequenceCounter++;
            //}
            //else
            //{

            //}

            if (TempData["test"] is null)
            {
                TempData["test"] = 1;
            }
            else
            {
                TempData["test"] = (int)TempData["test"] + 1;
            }

            SimonSays simon = new SimonSays{
                sequenceCounter = (int)TempData["test"]
            };

            // feed id through db.
            return View(simon);
        }

        //[HttpGet]
        //public IActionResult SimonBeginPlay(SimonSays says)
        //{
        //    says.sequenceCounter += 1;
        //    //return View(says);
        //    return RedirectToAction("SimonSays");
        //}
    }
}
