using Microsoft.AspNetCore.Mvc;

namespace TylorBookStore.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
