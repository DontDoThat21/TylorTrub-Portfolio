using Microsoft.AspNetCore.Mvc;
using TylorTrubPortfolio.Server.BL.Repository;
using TylorTrubPortfolio.Server.BL.Repository.IRepository;
using TylorTrubPortfolio.DTO;

namespace TylorTrubPortfolio.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class GamesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public GamesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public IActionResult Index()
        {
            List<Game> games = _unitOfWork.Games.GetAll().ToList();
            return View(games);
        }

        public IActionResult Hangman()
        {
            return View();
        }

        public IActionResult SimonSays(SimonSays says)
        {
            if (TempData["test"] is null)
            {
                TempData["test"] = 1;
            }
            else
            {
                TempData["test"] = (int)TempData["test"] + 1;
            }
            TempData.Keep();
            List<SimonSays> simons = new List<SimonSays>()
            {
                new SimonSays { Id = 0, currentColor =  "green" },
                new SimonSays { Id = 1, currentColor =  "red" },
                new SimonSays { Id = 2, currentColor =  "orange" },
                new SimonSays { Id = 3, currentColor =  "cyan" }
            };

            // feed id through db.
            return View(simons);
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
 