using Microsoft.AspNetCore.Mvc;

namespace TylorTrubPortfolio.Controllers
{
    public class MotorcycleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Collection()
        {
            return View();
        }
        public IActionResult Store()
        {
            return View();
        }
    }
}
