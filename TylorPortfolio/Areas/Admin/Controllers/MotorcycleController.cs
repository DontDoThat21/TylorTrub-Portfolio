using Microsoft.AspNetCore.Mvc;
using TylorTrubPortfolio.Server.BL.Data;
using TylorTrubPortfolio.Server.BL.Repository.IRepository;
using TylorTrubPortfolio.DTO.Models;
using TylorTrubPortfolio.DTO.ViewModels;

namespace TylorTrubPortfolio.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MotorcycleController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;
        public MotorcycleController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: MotorcycleController
        public ActionResult Index()
        {
            return View();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid == false)
            {
                return View();
            }

            return RedirectToPage("./Index");
        }

        // GET: MotorcycleController/Details/5
        public ActionResult Details(int id)
        {

            TempData["success"] = null;
            if (id == null)
            {
                return NotFound();
            }
            Motorcycle? motorFromDB = _unitOfWork.Motorcycle.Get(u => u.Id == id, "");
            if (motorFromDB == null)
            {
                return NotFound();
            }
            return View(motorFromDB);
        }

        // GET: MotorcycleController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MotorcycleController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MotorcycleController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MotorcycleController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MotorcycleController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MotorcycleController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public IActionResult Collection()
        {
            HomeViewModel homeViewModel = new HomeViewModel()
            {
                MotorcycleVideoList = _unitOfWork.MotorcycleVideos.GetAll().ToList()
            };
            return View(homeViewModel);
        }
        public IActionResult Store()
        {
            List<Motorcycle> motorcycles = _unitOfWork.Motorcycle.GetAll().ToList();
            return View(motorcycles);
        }

        public IActionResult GetAll()
        {
            List<Motorcycle> objMotorcycleList = _unitOfWork.Motorcycle.GetAll().ToList();
            return Json(new { data = objMotorcycleList });
        }
    }
}
