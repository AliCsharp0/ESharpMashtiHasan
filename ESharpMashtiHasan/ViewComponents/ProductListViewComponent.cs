using ESharpMashtiHasan.Models;
using Microsoft.AspNetCore.Mvc;
using Shapping.DomainModel.BusinessModel.Product;
using Shopping.ApplicationServiceContract.Services;

namespace ESharpMashtiHasan.ViewComponents
{
	[ViewComponent(Name = "ProductList")]
	public class ProductListViewComponent : ViewComponent
	{
		private readonly IProductApplication IProductApp;
        public ProductListViewComponent(IProductApplication IProductApp)
        {
            this.IProductApp = IProductApp;
        }
		public IViewComponentResult Invoke(ProductSearchModel sm)
		{
			int rc = 0;
			var products = IProductApp.Search(sm, out rc);
			Models.ProductListAndSearchModel psm = new Models.ProductListAndSearchModel { sm = sm, productListItems = products };
			sm.RecordCount = rc;
			if (sm.PageSize == 0)
			{
				sm.PageSize = 5;
			}
			if (sm.RecordCount % sm.PageSize == 0)
			{
				sm.PageCount = sm.RecordCount / sm.PageSize;
			}
			else
			{
				sm.PageCount = sm.RecordCount / sm.PageSize + 1;
			}
			return View(psm);
		}
	}
}
