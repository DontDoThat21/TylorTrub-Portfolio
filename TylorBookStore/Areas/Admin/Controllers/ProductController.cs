using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TylorTrubPortfolio.DataAccess.Data;
using TylorTrubPortfolio.DataAccess.Repository.IRepository;
using TylorTrubPortfolio.Models;

namespace TylorTrubPortfolio.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductRepository _bookstore;
        public ProductController(IProductRepository db)
        {
            _bookstore = db;
        }

        public IActionResult Index()
        {
            List<Product> categories = _bookstore.GetAll().ToList();
            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product obj)
        {
            if (ModelState.IsValid)
            {
                _bookstore.Add(obj);
                _bookstore.Save();
                TempData["success"] = "Product created successfully";
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
            Product? catFromDB = _bookstore.GetFirstOrDefault(u => u.Id == id);
            if (catFromDB == null)
            {
                return NotFound();
            }
            return View(catFromDB);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Product? obj = _bookstore.GetFirstOrDefault(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _bookstore.Remove(obj);
            _bookstore.Save();
            TempData["success"] = "Product deleted successfully";
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)
        {
            TempData["success"] = null;
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Product? productFromDB = _bookstore.GetFirstOrDefault(u => u.Id == id);
            if (productFromDB == null)
            {
                return NotFound();
            }
            return View(productFromDB);
        }

        [HttpPost]
        public IActionResult Edit(Product obj)
        {
            if (ModelState.IsValid)
            {
                _bookstore.Update(obj);
                _bookstore.Save();
                TempData["success"] = "Product updated successfully";
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
