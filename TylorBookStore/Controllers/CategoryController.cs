using Microsoft.AspNetCore.Mvc;
using TylorBookStore.Data;
using TylorBookStore.Models;

namespace TylorBookStore.Controllers
{
    public class CategoryController : Controller
    {
        private readonly BookStoreDBContext _bookstore;
        public CategoryController(BookStoreDBContext db)
        {
            _bookstore = db;
        }

        public IActionResult Index()
        {
            List<Category> categories = _bookstore.Categories.ToList();
            return View(categories);
        }
    }
}
