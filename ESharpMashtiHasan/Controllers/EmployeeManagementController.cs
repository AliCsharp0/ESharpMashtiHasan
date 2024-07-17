using FramWork.DTOS;
using Microsoft.AspNetCore.Mvc;
using Shapping.DomainModel.BusinessModel.Employee;
using Shopping.ApplicationServiceContract.Services;

namespace ESharpMashtiHasan.Controllers
{
	public class EmployeeManagementController : Controller
	{
		private readonly IEmployeeApplication IEmpApp;
        public EmployeeManagementController(IEmployeeApplication IEmpApp)
        {
            this.IEmpApp = IEmpApp;
        }

        public IActionResult Index(EmployeeSearchModel sm )
		{
			return View(sm);
		}
		[HttpPost]
		public JsonResult Delete(int id)
		{
			OperationResult op = IEmpApp.Remove(id);
			return Json(op);
		}
		public IActionResult Search(EmployeeSearchModel sm)
		{
			return ViewComponent("EmployeeList", sm);
		}
        public IActionResult AddNew()
        {
            return View();
        }
		[HttpPost]
        public IActionResult AddNew(EmployeeAddEditModel emp)
        {

            return View();
        }
    }
}
