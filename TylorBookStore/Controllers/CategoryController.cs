using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TylorTrubPortfolio.DataAccess.Data;
using TylorTrubPortfolio.Models;

namespace TylorTrubPortfolio.Controllers
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
                TempData["success"] = "Category created successfully";
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? catFromDB = _bookstore.Categories.Find(id);
            if (catFromDB == null)
            {
                return NotFound();
            }
            return View(catFromDB);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Category? obj = _bookstore.Categories.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _bookstore.Categories.Remove(obj);
            _bookstore.SaveChanges();
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)
        {
            TempData["success"] = null;
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? catFromDB = _bookstore.Categories.Find(id);
            if (catFromDB == null)
            {
                return NotFound();
            }
            return View(catFromDB);
        }

        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _bookstore.Categories.Update(obj);
                _bookstore.SaveChanges();
                TempData["success"] = "Category updated successfully";
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
