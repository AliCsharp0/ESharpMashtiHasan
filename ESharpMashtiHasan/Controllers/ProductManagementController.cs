using ESharpMashtiHasan.ViewModel.Products;
using FramWork.DTOS;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Shapping.DomainModel.BusinessModel.Category;
using Shapping.DomainModel.BusinessModel.Product;
using Shapping.DomainModel.Models;
using Shopping.ApplicationServiceContract.Services;

namespace ESharpMashtiHasan.Controllers
{
	public class ProductManagementController : Controller
	{
		#region DataLoader

		private void InflateCategoryDrp()
		{
			var cats = ICategoryApp.GetDrp();
			cats.Insert(0, new FastCatList { CategoryID = -1, CategoryName = "...Please Select..." });
			SelectList categoryDropdown = new SelectList(cats, "CategoryID", "CategoryName");//in ja mgim ke farinkey CategoryID hast va to CategoryName ro neshon bedeh
																							 //کلاس SelectList به شما امکان می دهد لیست های کشویی یا لیست های چندگانه را انتخاب کنید.
			ViewBag.categoryDropdown = categoryDropdown;
		}
		private void InflateSupplierDrp()
		{
			var sups = ISupplierApp.GetAll();
			sups.Insert(0, new Supplier { SupplierID = -1, SupplierName = "...Please Select..." });
			SelectList supplierDropdown = new SelectList(sups, "SupplierID", "SupplierName");//in ja mgim ke farinkey CategoryID hast va to CategoryName ro neshon bedeh
																							 //کلاس SelectList به شما امکان می دهد لیست های کشویی یا لیست های چندگانه را انتخاب کنید.
			ViewBag.supplierDropdown = supplierDropdown;
		}
		#endregion
		private readonly ISupplierApplication ISupplierApp;
		private readonly ICategoryApplication ICategoryApp;
		private readonly IProductApplication IProductApp;
		public ProductManagementController(ISupplierApplication ISupplierApp, ICategoryApplication ICategoryApp, IProductApplication IProductApp)
		{
			this.ISupplierApp = ISupplierApp;
			this.ICategoryApp = ICategoryApp;
			this.IProductApp = IProductApp;
		}
		public IActionResult Index(ProductSearchModel sm)
		{
			InflateCategoryDrp();
			InflateSupplierDrp();
			return View(sm);
		}
		[HttpPost]
		public JsonResult Delete(int ProductID)//int ProductID in mishe sendingDate  JsonResult Delete in mishe sendingUrl
		{
			OperationResult op = IProductApp.Remove(ProductID);
			return Json(op);
		}
		public IActionResult Search(ProductSearchModel sm )
		{
			return ViewComponent("ProductList", sm);
		}
		public IActionResult AddNew()
		{
			InflateCategoryDrp();
			InflateSupplierDrp();
			return View();
		}
		[HttpPost]
		public IActionResult AddNew(ProductAddAndEditViewModel prod)
		{
			return View();
		}
	}
}
