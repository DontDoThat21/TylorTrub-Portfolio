using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Security.Claims;
using TylorTrubPortfolio.Server.BL.Data;
using TylorTrubPortfolio.Server.BL.Repository.IRepository;
using TylorTrubPortfolio.DTO;
using TylorTrubPortfolio.DTO.ViewModels;
using TylorTrubPortfolio.Client.BL;

namespace TylorTrubPortfolio.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private PortfolioDBContext _context;// = new PortfolioDBContext();

        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork, PortfolioDBContext context)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _context = context;
        }

        public IActionResult Index()
        {
            HomeViewModel homeModel = new HomeViewModel()
            {
                MotorcycleVideoList = _unitOfWork.MotorcycleVideos.GetAll().ToList(),
                PortfolioImageList = _unitOfWork.PortfolioImages.GetAll().ToList()
            };
            return View(homeModel);
        }

        public IActionResult MVCDemo()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            if (claim.Value != null)
            {
                HttpContext.Session.SetInt32(SD.SessionCart,
                    _unitOfWork.ShoppingCart.GetAll(u => u.ApplicationUserId == claim.Value).Count());
            }

            IEnumerable<Product> productList = _unitOfWork.Product.GetAll(includeProperties: "Category,ProductImages");
            return View(productList);
        }

        public IActionResult Details(int productId)
        {
            ShoppingCart cart = new()
            {
                Product = _unitOfWork.Product.Get(u => u.Id == productId, includeProperties: "Category,ProductImages"),
                Count = 1,
                ProductId = productId
            };
            return View(cart);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Details(ShoppingCart shoppingCart)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            shoppingCart.ApplicationUserId = userId;

            ShoppingCart cartFromDb = _unitOfWork.ShoppingCart.Get(u => u.ApplicationUserId == userId &&
            u.ProductId == shoppingCart.ProductId);

            _context.Database.OpenConnection();
            _context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.ShoppingCarts ON");
            _context.SaveChanges();            

            if (cartFromDb != null)
            {
                //shopping cart exists
                cartFromDb.Count += shoppingCart.Count;
                _unitOfWork.ShoppingCart.Update(cartFromDb);
                _unitOfWork.Save();
            }
            else
            {
                //add cart record
                _unitOfWork.ShoppingCart.Add(shoppingCart);                

                try
                {
                    _unitOfWork.Save();

                }
                catch (Exception)
                {
                    _context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.ShoppingCarts OFF");
                    _unitOfWork.Save();

                }
                HttpContext.Session.SetInt32(SD.SessionCart,
                    _unitOfWork.ShoppingCart.GetAll(u => u.ApplicationUserId == userId).Count());
            }
            _context.Database.CloseConnection();
            TempData["success"] = "Cart updated successfully";


            return RedirectToAction(nameof(MVCDemo));
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