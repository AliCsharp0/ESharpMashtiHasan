using Microsoft.AspNetCore.Mvc;
using Shapping.DomainModel.BusinessModel.Employee;

namespace ESharpMashtiHasan.Controllers
{
	public class EmployeeManagementController : Controller
	{
		public IActionResult Index(EmployeeSearchModel sm )
		{
			return View(sm);
		}
	}
}
