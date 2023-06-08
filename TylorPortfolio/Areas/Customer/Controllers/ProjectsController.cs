using Microsoft.AspNetCore.Mvc;
using TylorTrubPortfolio.DataAccess.Repository.IRepository;
using TylorTrubPortfolio.Models;

namespace TylorTrubPortfolio.Areas.Customer.Controllers
{
    [Area("Customer")]

    public class ProjectsController : Controller

    {

        private readonly IUnitOfWork _unitOfWork;

        public ProjectsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            List<Project> projects = _unitOfWork.Projects.GetAll().ToList();
            return View(projects);
        }

        public IActionResult AngularEmployeeManager() 
        {
            return View(new Project());
        }
    }
}
