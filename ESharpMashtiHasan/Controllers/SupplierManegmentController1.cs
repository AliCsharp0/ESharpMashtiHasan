using Microsoft.AspNetCore.Mvc;
using Shapping.DomainModel.BusinessModel.Supplier;
using Shapping.DomainModel.Models;
using Shopping.ApplicationServiceContract.Services;
using System.Runtime.CompilerServices;

namespace ESharpMashtiHasan.Controllers
{

	public class SupplierManegmentController1 : Controller
    {
        private readonly ISupplierApplication supplierApplication;
        public SupplierManegmentController1(ISupplierApplication supplierApplication)
        {
            this.supplierApplication = supplierApplication;
        }

		public IActionResult Index()
		{
			var suppliers = supplierApplication.GetAll();
			return View(suppliers);
		}
		public IActionResult AddNew()
		{
			return View();
		}
		[HttpPost]
		public IActionResult AddNew(SupplierAddEditModel supplier)
		{
			if(ModelState.IsValid)//age anotation haie supplieraddeditmodel ro raiat kony isvalid mishe true age raiat nakony mishe false
			{
				var op = supplierApplication.Register(supplier);//in ja supplier ro register mikone
				if(op.Success)//mige age operationResult success az lie Application bagasht 
				{
					return RedirectToAction("Index", "SupplierManegmentController1");//in ja mige ke bro safhe ro refresh kon va az safe add bro biron va be safhe index bro
				}
				else
				{
					TempData["ErrorMessage"] = op.Massage;
					return View(supplier);
				}
			}
			else
			{
				TempData["ErrorMessage"] = "Invalid Supplier Name";
				return View(supplier);
			}
			return View();
		}
		[HttpPost]
		public IActionResult Delete(int id)
		{
		   var op =	supplierApplication.Remove(id);
			if(!op.Success)
			{
				TempData["ErrorMessage"] = op.Massage;
			}
			return Redirect("Index");
		}
		public IActionResult Edit(int id)
		{
			var sup = supplierApplication.Get(id);
			return View();
		}
		[HttpPost]
		public IActionResult Edit(SupplierAddEditModel sup)
		{
			if(ModelState.IsValid)
			{
				var op = supplierApplication.Update(sup);
				if(op.Success)
				{
					return RedirectToAction("Index", "SupplierManegmentController1");
				}
				else
				{
					TempData["ErrorMessage"] = op.Massage;
					return View(sup);
				}
			}
			else
			{
				TempData["ErrorMessage"] = "Invalid Supplier Name";
				return View(sup);
			}
			return View();
		}
	}
}
