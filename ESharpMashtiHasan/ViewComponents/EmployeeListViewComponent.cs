using Microsoft.AspNetCore.Mvc;
using Shapping.DomainModel.BusinessModel.Employee;
using Shapping.DomainModel.BusinessModel.Product;
using Shopping.ApplicationServiceContract.Services;

namespace ESharpMashtiHasan.ViewComponents
{
	[ViewComponent(Name = "EmployeeList")]
	public class EmployeeListViewComponent : ViewComponent
	{
		public readonly IEmployeeApplication RepoEmp;
        public EmployeeListViewComponent(IEmployeeApplication RepoEmp)
        {
            this.RepoEmp = RepoEmp;	
        }

        public IViewComponentResult Invoke(EmployeeSearchModel sm)
		{
			int rc = 0;
			var employees = RepoEmp.Search(sm , out rc);
			Models.EmployeeListAndSearchModel psm = new Models.EmployeeListAndSearchModel
			{
				sm = sm,
				employeeListItems = employees,
			};
			sm.RecordCount = rc;
			if(sm.PageSize == 0)
			{
				sm.PageSize = 5;
			}
			if(sm.RecordCount % sm .PageSize  == 0)
			{
				sm.PageCount = sm.RecordCount / sm .PageSize; 
			}
			else
			{
				sm.PageCount = sm.RecordCount / sm.PageSize + 1;

			}
			return View(psm );
		}
	}
}
