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

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString()) 
            {
                ModelState.AddModelError("name", "The Display Order cannot exactly match the name.");
            }
            if (obj.Name != null && obj.Name.ToLower() == "test") 
            {
                ModelState.AddModelError("", "Test is an invalid value.");
            }
            if (ModelState.IsValid)
            {
                _bookstore.Categories.Add(obj);
                _bookstore.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category catFromDB = _bookstore.Categories.Find(id);
            if (catFromDB == null)
            {
                return NotFound();
            }
            return View();
        }

        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The Display Order cannot exactly match the name.");
            }
            if (obj.Name != null && obj.Name.ToLower() == "test")
            {
                ModelState.AddModelError("", "Test is an invalid value.");
            }
            if (ModelState.IsValid)
            {
                _bookstore.Categories.Add(obj);
                _bookstore.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
    }
}
