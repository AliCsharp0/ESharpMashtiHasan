﻿using Microsoft.AspNetCore.Mvc;
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
			return View(employees);
		}
	}
}
