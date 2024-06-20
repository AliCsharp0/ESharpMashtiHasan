using FramWork.DTOS;
using Shapping.DomainModel.BusinessModel.Employee;
using Shapping.DomainModel.BusinessModel.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shapping.DomainModel.Models;


namespace Shopping.ApplicationServiceContract.Services
{
	public interface IEmployeeApplication
	{
		EmployeeAddEditModel Get(int id);

		OperationResult Remove(int id);

		OperationResult Update(EmployeeAddEditModel current);

		OperationResult Register(EmployeeAddEditModel current);

		List<EmployeeListItem> Search(EmployeeSearchModel sm, out int RecordCount);
	}
}
