using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Data;
using TylorTrubPortfolio.Server.BL.Data;
using TylorTrubPortfolio.Server.BL.Repository.IRepository;
using TylorTrubPortfolio.DTO.Models;
using TylorTrubPortfolio.Client.BL;

namespace TylorTrubPortfolio.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize(Roles = SD.Role_Admin)]
    public class CompanyController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CompanyController(IUnitOfWork db, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = db;
        }

        public IActionResult Index()
        {
            List<Company> companies = _unitOfWork.Company.GetAll().ToList();
            IEnumerable<SelectListItem> CompanyList = _unitOfWork.Category
                .GetAll().Select(c=> new SelectListItem
                {
                    Text = c.Name,
                    Value = c.Id.ToString()
                });
            return View(companies);
        }

        public IActionResult Upsert(int? id)
        {
            if (id == null || id == 0)
            {
                // create
                return View(new Company());
            }
            else
            {
                // update
                Company companyObj = _unitOfWork.Company.Get(u => u.Id == id);
                return View(companyObj);
            }

            
        }

        [HttpPost]
        public IActionResult Upsert(Company CompanyObj)
        {
            if (ModelState.IsValid)
            {

                if (CompanyObj.Id == 0)
                {
                    _unitOfWork.Company.Add(CompanyObj);
                }
                else
                {
                    _unitOfWork.Company.Update(CompanyObj);

                }
                _unitOfWork.Save();
                TempData["success"] = "Company created successfully";
                return RedirectToAction("Index");
            }
            else
            {
                return View(CompanyObj);
            }
        }

        public IActionResult Edit(int? id)
        {
            TempData["success"] = null;
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Company? CompanyFromDB = _unitOfWork.Company.Get(u => u.Id == id);
            if (CompanyFromDB == null)
            {
                return NotFound();
            }
            return View(CompanyFromDB);
        }

        [HttpPost]
        public IActionResult Edit(Company obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Company.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Company updated successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Company> objCompanyList = _unitOfWork.Company.GetAll().ToList();
            return Json(new { data = objCompanyList });
        }

        public IActionResult Delete(int? id)
        {
            var CompanyToBeDeleted = _unitOfWork.Company.Get(u=>u.Id==id);
            if (CompanyToBeDeleted == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }

            _unitOfWork.Company.Remove(CompanyToBeDeleted);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Delete Successful" });
        }

        #endregion
    }
}
