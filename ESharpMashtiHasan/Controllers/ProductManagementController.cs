using ESharpMashtiHasan.ViewModel.Products;
using FramWork.DTOS;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Shapping.DomainModel.BusinessModel.Category;
using Shapping.DomainModel.BusinessModel.Product;
using Shapping.DomainModel.Models;
using Shopping.ApplicationServiceContract.Services;
using FramWork;
using ESharpMashtiHasan.Utility;

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
		private readonly IWebHostEnvironment env;
		public ProductManagementController(ISupplierApplication ISupplierApp, ICategoryApplication ICategoryApp, IProductApplication IProductApp , IWebHostEnvironment env)
		{
			this.ISupplierApp = ISupplierApp;
			this.ICategoryApp = ICategoryApp;
			this.IProductApp = IProductApp;
			this.env = env;
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
		public IActionResult AddNew(ProductAddAndEditViewModel prod)//in AddNew Be hamrahe Amniant Saghte Shodeh (Amozesh Amniat)
		{
			if(!prod.Image.FileName.IsValidFileName())
			{
                TempData["ErrorMessage"] = "Invalid File Name";
                return RedirectToAction("Index", "ProductManagement");
            }
			if(!prod.Image.IsValidImageSize(1))
			{
				TempData["ErrorMessage"] = "File Size Must be between 40960 And 2097152";
				return RedirectToAction("Index" , "ProductManagement");
			}
			string fn = prod.Image.FileName.ToUniqueFileName();
			string dbFileName = $"~/ProductImages/{fn}";// in daghel data base zakhire mishe 
			var path = $"{env.ContentRootPath}/ProductImages/{fn}";// in adderss image in wwwroot hast ke be in migan Address Fiziki ke nesbat be reshe site sangideh mishavad ke be name relative gofteh mishavad
			FileStream fs = new FileStream(path, FileMode.Create);
			prod.ImagUrl = dbFileName;
			ProductAddEditModel model = new ProductAddEditModel
			{
				CategoryID = prod.CategoryID,
				Description = prod.Description,
				ImagUrl = dbFileName,
				JSONLDInformation= prod.JSONLDInformation,
				MataDescription= prod.MataDescription,
				MetaKeyWord= prod.MetaKeyWord,
				PageTitle= prod.PageTitle,
				ProductName = prod.ProductName,
				Slup = prod.Slup,
				SupplierID = prod.SupplierID,
				UnitPrice = prod.UnitPrice,
			};
			IProductApp.Register(model);
			prod.Image.CopyTo(fs);//in ja jaii ke file gharare copy beshe
			return RedirectToAction("Index" , "ProductManagement");
		}
	}
}
