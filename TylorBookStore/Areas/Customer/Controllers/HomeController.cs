using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TylorTrubPortfolio.DataAccess.Repository.IRepository;
using TylorTrubPortfolio.Models;

namespace TylorTrubPortfolio.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWorkBookstore _unitOfWorkBookstore;

        public HomeController(ILogger<HomeController> logger, IUnitOfWorkBookstore unitOfWorkBookstore)
        {
            _logger = logger;
            _unitOfWorkBookstore = unitOfWorkBookstore;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MVCDemo()
        {
            IEnumerable<Product> productList = _unitOfWorkBookstore.Product.GetAll(includeProperties: "Category");
            return View(productList);
        }

        public IActionResult Details(int id)
        {
            Product product = _unitOfWorkBookstore.Product.Get(u=>u.Id==id, includeProperties: "Category");
            return View(product);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}